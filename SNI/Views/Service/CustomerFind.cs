using SNI.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;
using SNI.Views.Customer;
namespace SNI.Views.Service
{
    public partial class CustomerFind : Form
    {
        public CustomerFind()
        {
            InitializeComponent();
        }

        private void CustomerFind_Load(object sender, EventArgs e)
        {
           
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            textBox1.Text = "";
            textBox1.Visible = true;
            comboBox1.Visible = true;
            button2.Visible = true;
            textBox1.Location = new Point(0, 0);
            comboBox1.Location = new Point(0, 0);
            

            textBox1.Size = new Size(this.Size.Width-30, textBox1.Size.Height);
            comboBox1.Size = new Size(this.Size.Width-40, comboBox1.Size.Height);
            button2.Size = new Size(this.Size.Width - textBox1.Size.Width, textBox1.Size.Height);
            button2.Location = new Point(textBox1.Location.X + textBox1.Size.Width, 0);
            comboBox1.DisplayMember = "Họ Tên";
            comboBox1.ValueMember = "Mã Số";
            panel1.Visible = false;
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(this.Size.Width, 225);
            
            this.AutoSize = true;
            this.BackColor = Color.Azure;
            this.Controls.SetChildIndex(textBox1, 0);
            textBox1.Focus();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private Models.Customers selected_customer;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text.Length % 3 == 0)
            {
                if (txb.Text != "")
                {
                    comboBox1.Enabled = true;
                    comboBox1.DataSource = CustomerController.FindByValue(txb.Text);
                    comboBox1.DroppedDown = true;

                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    comboBox1.Enabled = false;
                }
            }
        }
        private void showInfor()
        {
            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            button2.Visible = false;
            textBox1.Visible = false;
            panel1.Visible = true;
            namelabel.Text = selected_customer.name;
            sdtlabel.Text = selected_customer.phone;
            string gt="";
            if (selected_customer.gender == 0)
            {
                gt = "Nam";
            }
            else if (selected_customer.gender == 1)
            {
                gt = "Nữ";
            }
            else if( selected_customer.gender ==2 )
            {
                gt = "Khác";
            }
            gioitinhlabel.Text = gt;
            dclabel.Text = selected_customer.address;
            tuoilabel.Text = selected_customer.age.ToString();
            button1.Focus();

        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                selected_customer = CustomerController.getinformation(comboBox1.SelectedValue.ToString());
                showInfor();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up)
            {
                if(comboBox1.SelectedIndex>0)
                {
                    comboBox1.SelectedIndex -= 1;
                }
            }
            if(e.KeyCode == Keys.Down)
            {
                if(comboBox1.SelectedIndex<comboBox1.Items.Count-1)
                {
                    comboBox1.SelectedIndex += 1;
                }
            }
            if(e.KeyCode == Keys.Enter)
            {
                selected_customer = CustomerController.getinformation(comboBox1.SelectedValue.ToString());
                showInfor();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerFind_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCustomerForm acf = new AddCustomerForm();
            if(acf.ShowDialog()==DialogResult.OK)
            {
                selected_customer = CustomerController.addedCustomer;
                showInfor();
            }

        }
    }
}
