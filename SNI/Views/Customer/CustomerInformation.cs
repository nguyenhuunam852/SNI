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
        Models.Health selected_health;
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
            loaiCombobox = Module.LoadComboboxLoai(loaiCombobox);
            loaiCombobox.SelectedValue = customer.typeid;
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
            if(CustomerController.UpdateCustomer(idtext.Text, nametext.Text, sdttext.Text,Convert.ToInt16(loaiCombobox.SelectedValue.ToString()), gender, age, diachirichtext.Text,listWithout,removelist)==true)
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
                if (comboBox1.Items.Count > 0 && comboBox1.DroppedDown == true)
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
                        if (comboBox1.Items.Count > 0 && comboBox1.DroppedDown == true)
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
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
            }
        }
        private void createNotExistTag()
        {
            var listname = listWithout.Select(o => o.name);
            if (!listname.Contains(suckhoetext.Text))
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
            else
            {
                MessageBox.Show("Bệnh này đã được thêm !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (check == true)
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
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
         
        }
    }
}
