using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.Setting
{
    public partial class BackupFile : Form
    {
        public BackupFile()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = Config.config.defaultFolder;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Config.config.defaultFolder ;
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }

        }
        private string GetDateTime(string a)
        {
            string rstext;
            try
            {
                string[] text = a.Split('_');
                string day = text[0].Substring(0, 2);
                string month = text[0].Substring(2, 2);
                string year = text[0].Substring(4, 4);
                string hour = text[1].Substring(0, 2);
                string minute = text[1].Substring(2, 2);
                string second = text[1].Substring(4, 2);
                rstext = day + '/' + month + '/' + year + ' ' + hour + ':' + minute + ':' + second;
            }
            catch
            {
                return "";
            }
            return rstext;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(BackupController.BackupDatabase(textBox1.Text)>=-1)
            {
                MessageBox.Show("Backup thành công !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        

        private DataTable loadFile()
        {
            string path = textBox1.Text;
            string[] filePaths = Directory.GetFiles(path, "*.bak",
                                         SearchOption.TopDirectoryOnly);
            DataTable dtb = new DataTable();
            dtb.Columns.Add("name", typeof(String));
            dtb.Columns.Add("time", typeof(String));
            foreach (string a in filePaths)
            {
                DataRow dtr = dtb.NewRow();
                string name = Path.GetFileName(a);
                string time = GetDateTime(name);
                if(time!="")
                {
                    dtr["name"] = name;
                    dtr["time"] = time;
                    DataTable dtb1 = BackupController.getDTB(name, path);
                    if (dtb1 != null)
                    {
                        string database = BackupController.getbase(dtb1.Rows[0][1].ToString());
                        dtb.Rows.Add(dtr);
                    }
                }
            }
            return dtb;
        }

        private void BackupFile_Load(object sender, EventArgs e)
        {
            textBox1.Text = Config.config.defaultFolder;
            dataGridView1 = Module.MydataGridView(dataGridView1);
            dataGridView1.DataSource = loadFile();
        }
        int s = 0;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = textBox1.Text;
            DataTable dtb = BackupController.getDTB(dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString(), path);
            string database = BackupController.getbase(dtb.Rows[0][1].ToString());
            if (database != null)
            {
                txtDatabaseName.Text = database;
                s = 1;
            }
            else
            {
                s = 2;
            }
        }
    }
}
