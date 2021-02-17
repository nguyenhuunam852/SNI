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
    public partial class CustomerHistory : Form
    {
        public CustomerHistory()
        {
            InitializeComponent();
        }
        public string idcustomer;
        private void CustomerHistory_Load(object sender, EventArgs e)
        {
            label1.Text = idcustomer;
            dt_history = Module.MydataGridView(dt_history);
            dt_history.DataSource = HistoryController.getHistorybyCustomerId(idcustomer);
            Models.Customers cus = CustomerController.getinformation(idcustomer);
            label2.Text = cus.name;
            label3.Text = cus.phone;
            label4.Text = cus.address;

        }
    }
}
