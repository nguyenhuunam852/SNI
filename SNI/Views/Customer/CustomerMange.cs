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
    }
}
