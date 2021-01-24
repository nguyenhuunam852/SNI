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
            acf.ShowDialog();
        }
        private void LoadDataGridView()
        {
            List<Models.Customers> listcus = CustomerController.loadCustomer();
            
            dataGridView1.DataSource = listcus;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

        }
        private void CustomerMange_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

        }
    }
}
