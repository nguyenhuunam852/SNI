using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;

namespace SNI.Views.Customer
{
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }
        private void loadComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("display");
            dt.Columns.Add("value");

            DataRow dtr = dt.NewRow();
            DataRow dtr1 = dt.NewRow();
            DataRow dtr2 = dt.NewRow();


            dtr["display"] = "Nam";
            dtr["value"] = 0;
            dtr1["display"] = "Nữ";
            dtr1["value"] = 1;
            dtr2["display"] = "Khác";
            dtr2["value"] = 2;

            dt.Rows.Add(dtr);
            dt.Rows.Add(dtr1);
            dt.Rows.Add(dtr2);

            gioitinhcbbox.DataSource = dt;
        }
      
        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            idtext.Text = Config.MaChiNhanh + RandomString(4);
            loadComboBox();
            gioitinhcbbox.DropDownStyle = ComboBoxStyle.DropDownList;
            //LoadDataGridView();

        }

        private static Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check =  CustomerController.AddCustomer(idtext.Text, nametext.Text, sdttext.Text, int.Parse(gioitinhcbbox.SelectedValue.ToString()),Convert.ToInt32(tuoinumber.Value), diachirichtext.Text);
            if(check==true)
            {
                AddCustomerForm_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
