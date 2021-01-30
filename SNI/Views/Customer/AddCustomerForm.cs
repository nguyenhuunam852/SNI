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
using SNI.Views.Health;
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
            idlabel.Text = Config.config.MaChiNhanh + RandomString(4);
            gioitinhcbbox = Module.loadComboBox(gioitinhcbbox);
            loaiCombobox = Module.LoadComboboxLoai(loaiCombobox);
            //LoadDataGridView();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadTag()
        {
            suckhoetext.Text = "";
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
            bool check =  CustomerController.AddCustomer(idlabel.Text, nametext.Text, sdttext.Text,int.Parse(loaiCombobox.SelectedValue.ToString()), int.Parse(gioitinhcbbox.SelectedValue.ToString()),Convert.ToInt32(tuoinumber.Value), diachirichtext.Text,listWithout);
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
            if (txb.Text.Length>= 3)
            {
                if (txb.Text != "")
                {
                    comboBox1.Enabled = true;
                    DataTable dt = HealthController.FindHealthWithoutselected(txb.Text,listWithout);
                    if (dt.Rows.Count > 0)
                    {
                        comboBox1.DataSource = dt;
                        comboBox1.DroppedDown = true;
                        comboBox1.DisplayMember = "Bệnh";
                        comboBox1.ValueMember = "Mã Số";
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        comboBox1.DroppedDown = false;
                        comboBox1.DataSource = null;
                    }
                    comboBox1.SelectedIndex = -1;
                }
            }

        }
        int show = 0;
        Models.Health selected_health;
        private void createNotExistTag()
        {
            var listname = listWithout.Select(o => o.name);
            if (!listname.Contains(suckhoetext.Text))
            {
                show = 1;
                DialogResult dlt = MessageBox.Show("Bạn có muốn tạo mới không!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlt == DialogResult.Yes)
                {
                    if (HealthController.addHealth(suckhoetext.Text))
                    {
                        if (!listWithout.Contains(HealthController.addedhealth) && suckhoetext.Text != "")
                        {
                            listWithout.Add(HealthController.addedhealth);
                            loadTag();
                            suckhoetext.Text = "";
                        }
                    }
                }
                show = 0;
            }
            else
            {
                MessageBox.Show("Bệnh này đã được thêm !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void suckhoetext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (comboBox1.SelectedIndex >= 0)
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
                if (comboBox1.Items.Count>0 && comboBox1.DroppedDown == true)
                {
                    if (suckhoetext.Text != "")
                    {
                        acceptChoose();
                    }
                }
                else
                {
                    try
                    {
                        if (suckhoetext.Text != "")
                        {
                            createNotExistTag();
                        }
                        comboBox1.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }
            }
        }
        private void createTag()
        {
            selected_health = HealthController.getinformation(Convert.ToInt16(comboBox1.SelectedValue.ToString()));
            listWithout.Add(selected_health);
            loadTag();
        }
        private void acceptChoose()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                createTag();
            }
            else
            {
                bool check = HealthController.checkExist(suckhoetext.Text);
                if(check==true)
                {
                    createTag();
                }
                else
                {
                    createNotExistTag();
                }
            }
            comboBox1.DroppedDown = false;
            suckhoetext.Text = "";
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            
        }

        List<Models.Health> listWithout = new List<Models.Health>();
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (suckhoetext.Text != "" && comboBox1.SelectedIndex != -1 && show==0)
            {
                acceptChoose();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
