using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNI.Views.User
{
    public partial class PersonalForm : Form
    {
        public PersonalForm()
        {
            InitializeComponent();
        }
        private void controller(bool check)
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Enabled = check;
                }
            }
            button1.Enabled = !check;
            accept_button.Enabled = check;
            close_button.Enabled = check;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            controller(true);
        }
        private void load()
        {
            username_txt.Text = UserController.current.username;
            password_txt.Text = UserController.current.password;
            name_txt.Text = UserController.current.name;
            sdt_txt.Text = UserController.current.phone;
            email_txt.Text = UserController.current.email;
            controller(false);
        }
        private void PersonalForm_Load(object sender, EventArgs e)
        {
            load();
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            if(UserController.UpdateUser(UserController.current.userid, username_txt.Text, password_txt.Text, name_txt.Text,sdt_txt.Text, email_txt.Text))
            {
                MessageBox.Show("Thành Công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
            }
            else
            {
                load();
            }

        }
    }
}
