using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.FirstConfig
{
    public partial class ApiSettings : UserControl
    {
        public ApiSettings()
        {
            InitializeComponent();
        }
        public Form parent;
        Panel Panel;
        private void button1_Click(object sender, EventArgs e)
        {
            if(Config.SaveApi(report_api_txt.Text,update_api_txt.Text))
            {
                MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminUser au = new AdminUser();
                au.parent = parent;
                Panel.Controls.Clear();
                Panel.Controls.Add(au);
            }
            else
            {
                MessageBox.Show("Nhập đúng Format!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parent.Close();
        }

        private void ApiSettings_Load(object sender, EventArgs e)
        {
            foreach (Control ctr in parent.Controls)
            {
                if (ctr is Panel)
                {
                    Panel = (Panel)ctr;
                }
            }
        }
    }
}
