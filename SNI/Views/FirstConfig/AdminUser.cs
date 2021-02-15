using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.FirstConfig
{
    public partial class AdminUser : UserControl
    {
        public AdminUser()
        {
            InitializeComponent();
        }
        public Form parent;
        private void accept_button_Click(object sender, EventArgs e)
        {
            if(UserController.AddUser(username_txt.Text, password_txt.Text, name_txt.Text, email_txt.Text, sdt_txt.Text,"Admin"))
            {
                MessageBox.Show("Thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileConfig.config.connectsuccess = true;
                FileConfig.WriteFile();
                parent.Close();
            }
            else
            {
                MessageBox.Show("Thất bại!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void close_button_Click(object sender, EventArgs e)
        {
            parent.Close();
        }
    }
}
