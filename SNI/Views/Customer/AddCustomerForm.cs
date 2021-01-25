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
      

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {

            this.Controls.SetChildIndex(suckhoetext, 0);
            idtext.Text = Config.MaChiNhanh + RandomString(4);
            gioitinhcbbox = Module.loadComboBox(gioitinhcbbox);
            //LoadDataGridView();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadTag()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach(Models.Health tag in listWithout)
            {
                Label lb = new Label();
                lb.Click += Lb_Click1;
                Panel pn =Module.createMytab(tag.name, tag.healthid.ToString(), lb);
                flowLayoutPanel1.Controls.Add(pn);
               
            }
        }

        private void Lb_Click1(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            var select_health = listWithout.SingleOrDefault(o => o.healthid == Convert.ToInt32(lb.Name));
            listWithout.Remove(select_health);
            loadTag();
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
            bool check =  CustomerController.AddCustomer(idtext.Text, nametext.Text, sdttext.Text, int.Parse(gioitinhcbbox.SelectedValue.ToString()),Convert.ToInt32(tuoinumber.Value), diachirichtext.Text,listWithout);
            if(check==true)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void suckhoetext_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text.Length % 3 == 0)
            {
                if (txb.Text != "")
                {
                    comboBox1.Enabled = true;
                    comboBox1.DataSource = HealthController.FindHealthWithoutselected(txb.Text,listWithout);
                    comboBox1.DroppedDown = true;
                    comboBox1.DisplayMember = "Bệnh";
                    comboBox1.ValueMember = "Mã Số";
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    comboBox1.Enabled = false;
                }
            }

        }
        Models.Health selected_health;
        private void suckhoetext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (comboBox1.SelectedIndex > 0)
                {
                    comboBox1.SelectedIndex -= 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
                {
                    comboBox1.SelectedIndex += 1;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                acceptChoose();
            }
        }
        private void acceptChoose()
        {
            comboBox1.DroppedDown = false;
            selected_health = HealthController.getinformation(Convert.ToInt16(comboBox1.SelectedValue.ToString()));          
            listWithout.Add(selected_health);
            loadTag();
            suckhoetext.Text = "";
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            
        }

        List<Models.Health> listWithout = new List<Models.Health>();
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (suckhoetext.Text != "")
            {
                acceptChoose();
            }
        }
    }
}
