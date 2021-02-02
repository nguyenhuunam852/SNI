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
                selected = Convert.ToInt16(dataGridView1.Rows[0].Cells["id"].Value.ToString());
                showinfor(selected);
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
        int selected = 0;

        private void save_bt_Click(object sender, EventArgs e)
        {
            if (UserController.UpdateUser(selected, username_txt.Text, password_txt.Text, name_txt.Text, email_txt.Text, sdt_txt.Text, "Staff"))
            {
                panel_control(false);
                loadDataGridView();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {
                    if (UserController.RemoveUser(selected) == true)
                    {
                        loadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                showinfor(selected);
            }
        }

        private void recovery_bt_Click(object sender, EventArgs e)
        {
            RecoveryForm rf = new RecoveryForm();
            if(rf.ShowDialog()==DialogResult.OK)
            {
                panel_control(false);
                loadDataGridView();
            }
        }
    }
}
