using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.Customer
{
    public partial class CustomerMange : Form
    {
        public CustomerMange()
        {
            InitializeComponent();
        }
        private string selectid = ""; 
        private void button1_Click(object sender, EventArgs e)
        {
            AddCustomerForm acf = new AddCustomerForm();
            if(acf.ShowDialog()==DialogResult.OK)
            {
                LoadDataGridView();
            }
        }
        private void LoadDataGridView()
        {
            DataTable dt = CustomerController.getListCustomer();
            dataGridView1 = Module.MydataGridView(dataGridView1);
            dataGridView1.DataSource = dt;
            if (dataGridView1.Rows.Count > 0)
            {
                selectid = dataGridView1.Rows[0].Cells["Mã Số"].Value.ToString();
            }
        }
        private void CustomerMange_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectid = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
            if(selectid!="")
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlr == DialogResult.Yes)
            {
                if (CustomerController.RemoveCustomer(selectid))
                {
                    MessageBox.Show("Xóa thành công!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Thất bại!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if(txb.Text.Length%3==0)
            {
                dataGridView1.DataSource = CustomerController.FindByValue(txb.Text);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerInformation ci = new CustomerInformation();
            ci.idcustomer = selectid;
            if(ci.ShowDialog()==DialogResult.OK)
            {
                LoadDataGridView();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RecoveryCustomer rc = new RecoveryCustomer();
            if(rc.ShowDialog()==DialogResult.OK)
            {
                LoadDataGridView();
            }
        }
    }
}
