using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.User
{
    public partial class UserAddForm : Form
    {
        public UserAddForm()
        {
            InitializeComponent();
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            if(UserController.AddUser(username_txt.Text,password_txt.Text,name_txt.Text,email_txt.Text,sdt_txt.Text,"Staff"))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
