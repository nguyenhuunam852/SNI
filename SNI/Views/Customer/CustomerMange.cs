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
            
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
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
            if(CustomerController.RemoveCustomer(selectid))
            {
                MessageBox.Show("Xóa thành công!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Thất bại!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ci.ShowDialog();
        }
    }
}
