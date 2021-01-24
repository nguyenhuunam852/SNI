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
        private void button1_Click(object sender, EventArgs e)
        {
            AddCustomerForm acf = new AddCustomerForm();
            if(acf.ShowDialog()==DialogResult.OK)
            {
                loadDataGridView();
            }
        }
        private void CustomerMange_Load(object sender, EventArgs e)
        {
            
            loadDataGridView();
            dataGridView1.CellClick += DataGridView1_CellClick;

        }
        private void loadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            if (textBox1.Text == "" || textBox1.Text.Length <= 3)
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = CustomerController.getListCustomer();
            }
            else
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = CustomerController.FindByValue(textBox1.Text);

            }
            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "delete";
            testButtonColumn.Text = "Xóa";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;

            int columnIndex = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(columnIndex, testButtonColumn);
         
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {

                    string id = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
                    if (CustomerController.RemoveCustomer(id) == true)
                    {
                        loadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            loadDataGridView();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerInformation ci = new CustomerInformation();
            ci.idcustomer = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
            if(ci.ShowDialog()==DialogResult.OK)
            {
                loadDataGridView();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RecoveryCustomer rc = new RecoveryCustomer();
            if(rc.ShowDialog()==DialogResult.OK)
            {
            
                loadDataGridView();
            }
        }
    }
}
