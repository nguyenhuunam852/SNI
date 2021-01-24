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
            gioitinhcombobox.SelectedValue = customer.gender;
            diachirichtext.Text = customer.address;
            label8.Text = customer.dayadd.ToString();
            label9.Text = customer.dayupdate.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int gender = Convert.ToInt16(gioitinhcombobox.SelectedIndex);
            int age = Convert.ToInt16(tuoinumbertext.Value);
            if(CustomerController.UpdateCustomer(idtext.Text, nametext.Text, sdttext.Text, gender, age, diachirichtext.Text)==true)
            {
                MessageBox.Show("Cật nhập thành công!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Lỗi xảy ra !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
