using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        List<Models.Health> listWithout = new List<Models.Health>();
        List<Models.Health> removelist = new List<Models.Health>();

        private void CustomerInformation_Load(object sender, EventArgs e)
        {
            this.Controls.SetChildIndex(suckhoetext, 0);
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
            var listhealth = CustomerController.listHealth(idcustomer);
            foreach(Models.Health health in listhealth)
            {
                listWithout.Add(health);
            }
            loadTag();
        }
        private void loadTag()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Models.Health tag in listWithout)
            {
                Label lb = new Label();
                lb.Click += Lb_Click;
                Panel pn = Module.createMytab(tag.name, tag.healthid.ToString(), lb);
                flowLayoutPanel1.Controls.Add(pn);
            }
        }
        private void Lb_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            var select_health = listWithout.SingleOrDefault(o => o.healthid == Convert.ToInt32(lb.Name));
            listWithout.Remove(select_health);
            var idlist = removelist.Select(o => o.healthid).ToList();
            if(!idlist.Contains(Convert.ToInt32(lb.Name)))
            {
                removelist.Add(select_health);
            }
            loadTag();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int gender = Convert.ToInt16(gioitinhcombobox.SelectedIndex);
            int age = Convert.ToInt16(tuoinumbertext.Value);
            if(CustomerController.UpdateCustomer(idtext.Text, nametext.Text, sdttext.Text, gender, age, diachirichtext.Text,listWithout,removelist)==true)
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

        private void suckhoetext_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text.Length >= 3)
            {
                if (txb.Text != "")
                {
                    comboBox1.Enabled = true;
                    DataTable dt = HealthController.FindHealthWithoutselected(txb.Text, listWithout);
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
                }
            }
        }

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
                if (comboBox1.Items.Count > 0)
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
                        }
                        comboBox1.Enabled = false;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        
        private void acceptChoose()
        {
            comboBox1.DroppedDown = false;
            Models.Health selected_health = HealthController.getinformation(Convert.ToInt16(comboBox1.SelectedValue.ToString()));
            listWithout.Add(selected_health);
            loadTag();
            suckhoetext.Text = "";
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
    }
}
