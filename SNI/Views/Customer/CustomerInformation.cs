using System;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.Customer
{
    public partial class CustomerInformation : Form
    {
        public CustomerInformation()
        {
            InitializeComponent();
        }
        public string idcustomer;
        private void CustomerInformation_Load(object sender, EventArgs e)
        {
            button1.Focus();
            var customer = CustomerController.getinformation(idcustomer);
            nametext.Text = customer.name;
            idtext.Text = customer.localid;
            sdttext.Text = customer.phone;
            tuoinumbertext.Value = customer.age;
            gioitinhcombobox = Module.loadComboBox(gioitinhcombobox);
            diachirichtext.Text = customer.address;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
