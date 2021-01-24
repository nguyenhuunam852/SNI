using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;
using SNI.Models;

namespace SNI.Views.Customer
{
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                button1.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            
            idtext.Text = Config.MaChiNhanh + RandomString(4);
            gioitinhcbbox = Module.loadComboBox(gioitinhcbbox);
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
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
