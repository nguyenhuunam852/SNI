using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(BackupController.BackupDatabase(textBox1.Text)>=-1)
            {
                MessageBox.Show("Backup thành công !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
