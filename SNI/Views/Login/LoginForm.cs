using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserController.Login(username_txt.Text, password_txt.Text))
            {
                MainMenu mn = new MainMenu();
                mn.parent = this;
                mn.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fload()
        {
            username_txt.Text = "";
            password_txt.Text = "";
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            username_txt.Text = "";
            password_txt.Text = "";
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                button1.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            username_txt.Text = "";
            password_txt.Text = "";
        }

        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            username_txt.Text = "";
            password_txt.Text = "";
        }
    }
}
