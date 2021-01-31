using SNI.Controllers;
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
        string selected_customer = "";
        Models.Health selected_health;
        List<Models.Health> listWithout = new List<Models.Health>();
        List<Models.Health> removelist = new List<Models.Health>();

        private void button1_Click(object sender, EventArgs e)
        {
            AddCustomerForm acf = new AddCustomerForm();
            if(acf.ShowDialog()==DialogResult.OK)
            {
                loadDataGridView();
            }
        }
        private void information_panel_control(bool check)
        {
            foreach(Control ctr in information_panel.Controls)
            {
                if(ctr is TextBox || ctr is ComboBox || ctr is RichTextBox || ctr is NumericUpDown || ctr is Button)
                {
                    ctr.Enabled = check;
                }
            }
            close_bt.Enabled = check;
            update_bt.Enabled = !check;
            bt_history.Enabled = !check;
            btn_add.Enabled = !check;
            bt_recovery.Enabled = !check;
            bt_excel.Enabled = !check;
            txt_find.Enabled = !check;
            bt_find.Enabled = !check;
            flowLayoutPanel1.Enabled = check;
        }

        private void information_panel_clear()
        {
            foreach (Control ctr in information_panel.Controls)
            {
                if (ctr is TextBox || ctr is RichTextBox )
                {
                    ctr.Text = "";
                }
            }
            tuoinumbertext.Value = 0;
            gioitinhcombobox.SelectedValue = 0;
            loaiCombobox.SelectedValue = 0;
            flowLayoutPanel1.Controls.Clear();
            
        }
        private void CustomerMange_Load(object sender, EventArgs e)
        {
            suckhoetext.TextChanged += Suckhoetext_TextChanged;
            suckhoetext.KeyDown += Suckhoetext_KeyDown;
            comboBox1.SelectionChangeCommitted += ComboBox1_SelectionChangeCommitted;
            loadDataGridView();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void Suckhoetext_KeyDown(object sender, KeyEventArgs e)
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
        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (suckhoetext.Text != "" && comboBox1.SelectedIndex != -1)
            {
                acceptChoose();
            }
        }
        //
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
            var listname = listWithout.Select(o => o.name);
            if (comboBox1.SelectedValue != null)
            {
                selected_health = HealthController.getinformation(Convert.ToInt16(comboBox1.SelectedValue.ToString()));
                if (!listname.Contains(selected_health.name))
                {
                    listWithout.Add(selected_health);
                    loadTag();
                }
            }
            else
            {
                selected_health = HealthController.getinformationbyName(suckhoetext.Text);
                if (!listname.Contains(selected_health.name))
                {
                    listWithout.Add(selected_health);
                    loadTag();
                }
            }
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
        private void Suckhoetext_TextChanged(object sender, EventArgs e)
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
                    comboBox1.SelectedIndex = -1;
                }
            }

        }
        private void loadDataGridView()
        {
            information_panel_clear();
            information_panel.Controls.SetChildIndex(suckhoetext, 0);
            loaiCombobox = Module.LoadComboboxLoai(loaiCombobox);
            gioitinhcombobox = Module.loadComboBox(gioitinhcombobox);
            information_panel_control(false);

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            if (txt_find.Text == "" || txt_find.Text.Length <= 3)
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = CustomerController.getListCustomer();
            }
            else
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = CustomerController.FindByValue(txt_find.Text);

            }
            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "delete";
            testButtonColumn.Text = "Xóa";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;

            int columnIndex = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(columnIndex, testButtonColumn);

            if (dataGridView1.Rows.Count > 0)
            {
                selected_customer = dataGridView1.Rows[0].Cells["Mã Số"].Value.ToString();
                var customer = CustomerController.getinformation(selected_customer);
                showinfor(customer);
            }
        }
        private void showinfor(Models.Customers customer)
        {
            listWithout.Clear();
            information_panel_clear();
            nametext.Text = customer.name;
            idtext.Text = customer.localid;
            sdttext.Text = customer.phone;
            tuoinumbertext.Value = customer.age;
            gioitinhcombobox.SelectedValue = customer.gender;
            loaiCombobox.SelectedValue = customer.typeid;
            diachirichtext.Text = customer.address;
            adddate_label.Text = customer.dayadd.ToString();
            updatedate_label.Text = customer.dayupdate.ToString();
            
            var listhealth = CustomerController.listHealth(selected_customer);
            foreach (Models.Health health in listhealth)
            {
                listWithout.Add(health);   
            }
            loadTag();
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {

                    string id = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
                    if (CustomerController.RemoveCustomer(id) == true)
                    {
                        loadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                selected_customer = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
                var customer = CustomerController.getinformation(selected_customer);
                showinfor(customer);
            }
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
            if (!idlist.Contains(Convert.ToInt32(lb.Name)))
            {
                removelist.Add(select_health);
            }
            loadTag();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            loadDataGridView();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //CustomerInformation ci = new CustomerInformation();
            //ci.idcustomer = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
            //if(ci.ShowDialog()==DialogResult.OK)
            //{
            //    loadDataGridView();
            //}
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            RecoveryCustomer rc = new RecoveryCustomer();
            if(rc.ShowDialog()==DialogResult.OK)
            {
            
                loadDataGridView();
            }
        }
        private void information_panel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void update_bt_Click(object sender, EventArgs e)
        {
            information_panel_control(true);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int gender = Convert.ToInt16(gioitinhcombobox.SelectedIndex);
            int age = Convert.ToInt16(tuoinumbertext.Value);
            if (CustomerController.UpdateCustomer(idtext.Text, nametext.Text, sdttext.Text, Convert.ToInt16(loaiCombobox.SelectedValue.ToString()), gender, age, diachirichtext.Text, listWithout, removelist) == true)
            {
                MessageBox.Show("Cật nhập thành công!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataGridView();
            }
            else
            {
                MessageBox.Show("Lỗi xảy ra !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            information_panel_control(false);
            loadDataGridView();
        }

        private void bt_history_Click(object sender, EventArgs e)
        {

        }
    }
}
