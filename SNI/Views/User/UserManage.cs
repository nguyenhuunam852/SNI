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
    public partial class UserManage : Form
    {
        public UserManage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAddForm uaf = new UserAddForm();
            if(uaf.ShowDialog()==DialogResult.OK)
            {
                panel_control(false);
                loadDataGridView();
            }
        }

        private void loadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            dataGridView1 = Module.MydataGridView(dataGridView1);
            
            DataTable dt = UserController.getListUSer();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                showinfor(Convert.ToInt16(dataGridView1.Rows[0].Cells["id"].Value.ToString()));
                dataGridView1.Columns["id"].Visible = false;
            }

            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "delete";
            testButtonColumn.Text = "Xóa";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;

            int columnIndex = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(columnIndex, testButtonColumn);
        }
        private void panel_control(bool signal)
        {
            foreach(Control ctr in panel1.Controls)
            {
                if(ctr is TextBox)
                {
                    ctr.Enabled = signal;
                }
            }
            add_bt.Enabled = !signal;
            update_bt.Enabled = !signal;
            recovery_bt.Enabled = !signal;
            close_bt.Enabled = signal;
            save_bt.Enabled = signal;
        }
        private void showinfor(int id)
        {
            Models.Users user = UserController.getinformation(id);
            username_txt.Text = user.username;
            password_txt.Text = user.password;
            name_txt.Text = user.name;
            email_txt.Text = user.email;
            sdt_txt.Text = user.phone;
        }

        private void email_txt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            panel_control(false);
            loadDataGridView();

        }

        private void update_bt_Click(object sender, EventArgs e)
        {
            panel_control(true);
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            panel_control(false);
            loadDataGridView();

        }

        private void save_bt_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showinfor(Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString()));
        }
    }
}
