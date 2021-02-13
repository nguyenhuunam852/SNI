using Newtonsoft.Json;
using SNI.Config;
using SNI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.Setting
{

    public partial class UpdaterForm : Form
    {
        public UpdaterForm()
        {
            InitializeComponent();
        }

        WebClient wc;
        BackgroundWorker background;
        string tempfile;
        string md5;

        private void UpdaterForm_Load(object sender, EventArgs e)
        {
            downloadfile(Updater.ready[0]);
        }

        private void downloadfile(XMLreader xMLreader)
        {
            wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Wc_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Wc_DownloadFileCompleted);

            background = new BackgroundWorker();
            background.DoWork += new DoWorkEventHandler(Background_DoWork);
            background.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Background_RunWorkerCompleted);

            tempfile = Path.GetTempFileName();
            md5 = xMLreader.MD5;

            try { wc.DownloadFileAsync(new Uri(FileConfig.config.updateapi+@"/" + xMLreader.Uri), tempfile); }
            catch { this.DialogResult = DialogResult.No; this.Close(); }
        }
        DataTable dtb = new DataTable();

        private void Background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataRow dtr = dtb.NewRow();
            dtr["File cật nhật"] = Updater.ready[0].FilePath;
            dtr["File lưu tạm thời"] = tempfile;
            dtb.Rows.Add(dtr);
            dataGridView1.DataSource = dtb;

            Updater.ready.RemoveAt(0);
            if (Updater.ready.Count > 0)
            {
                downloadfile(Updater.ready[0]);
            }
            else
            {

                MessageBox.Show("Thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.progressBar.Style = ProgressBarStyle.Blocks;
                preocess_label.Text = "thành công";
                List<TempFile> temps = new List<TempFile>();

                foreach (DataRow row in dtb.Rows)
                {
                    TempFile temp = new TempFile();
                    temp.filename = row["File cật nhật"].ToString();
                    temp.tempfile = row["File lưu tạm thời"].ToString();
                    temp.type = 0;
                    temps.Add(temp);
                }
                foreach (LocalSystemCheck lsc in Updater.delete)
                {
                    TempFile temp = new TempFile();
                    temp.filename = lsc.filepath;
                    temp.tempfile = "";
                    temp.type = 1;
                    temps.Add(temp);
                }

                string json = JsonConvert.SerializeObject(temps.ToArray());
                System.IO.File.WriteAllText(FileConfig.config.defaultFolder+"//temp.json", json);
                Process.Start("updater.exe");
                this.Close();
            }
        }

        private void Background_DoWork(object sender, DoWorkEventArgs e)
        {
            string file = ((string[])e.Argument)[0];
            string updateMD5 = ((string[])e.Argument)[1];

            // Hash the file and compare to the hash in the update xml
            if (Hasher.HashFile(file, HashType.MD5).ToUpper() != updateMD5.ToUpper())
                e.Result = DialogResult.No;
            else
                e.Result = DialogResult.OK;
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Lỗi trong quá trình Download", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Show the "Hashing" label and set the progressbar to marquee
                this.preocess_label.Text = "Verifying Download...";
                this.progressBar.Style = ProgressBarStyle.Marquee;

                // Start the hashing
                background.RunWorkerAsync(new string[] { tempfile, this.md5 });
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.preocess_label.Text = string.Format("Downloaded {0} of {1}", FormatBytes(e.BytesReceived, 1, true), FormatBytes(e.TotalBytesToReceive, 1, true));
            this.progressBar.Value = e.ProgressPercentage;
        }

        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = "B";

            // Check if best size in KB
            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                // Check if best size in MB
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                // Best size in GB
                newBytes /= 1073741824;
                byteType = "GB";
            }

            // Show decimals
            if (decimalPlaces > 0)
                formatString += ":0.";

            // Add decimals
            for (int i = 0; i < decimalPlaces; i++)
                formatString += "0";

            // Close placeholder
            formatString += "}";

            // Add byte type
            if (showByteType)
                formatString += byteType;

            return string.Format(formatString, newBytes);
        }
    }
}
