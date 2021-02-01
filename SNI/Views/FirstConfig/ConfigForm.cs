using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.FirstConfig
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Config.CreateConnect(servername_txt.Text, username_txt.Text, password_txt.Text, database_txt.Text);
            if(Config.testConnect())
            {
                MessageBox.Show("Connect thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Config.CheckDatabase())
                {
                    MessageBox.Show("Tạo Database Thành Công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Tạo Database Thất Bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Connect thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
