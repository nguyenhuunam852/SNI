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
        List<Models.Health> listWithout = new List<Models.Health>();

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
            loadDataGridView();
            dataGridView1.CellClick += DataGridView1_CellClick;
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

            if (textBox1.Text == "" || textBox1.Text.Length <= 3)
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = CustomerController.getListCustomer();
            }
            else
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = CustomerController.FindByValue(textBox1.Text);

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
        string selected_customer = "";
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
               
                Panel pn = Module.createMytab(tag.name, tag.healthid.ToString(), lb);
                flowLayoutPanel1.Controls.Add(pn);
            }
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
            CustomerInformation ci = new CustomerInformation();
            ci.idcustomer = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
            if(ci.ShowDialog()==DialogResult.OK)
            {
                loadDataGridView();
            }

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            RecoveryCustomer rc = new RecoveryCustomer();
            if(rc.ShowDialog()==DialogResult.OK)
            {
            
                loadDataGridView();
            }
        }
    }
}
