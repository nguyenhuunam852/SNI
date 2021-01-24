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
        DataTable dt = new DataTable();
      

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            this.Controls.SetChildIndex(suckhoetext, 0);
            idtext.Text = Config.MaChiNhanh + RandomString(4);
            gioitinhcbbox = Module.loadComboBox(gioitinhcbbox);
            dataGridView1 = Module.MydataGridView(dataGridView1);

            dt.Columns.Add("id");
            dt.Columns.Add("bệnh");


            dataGridView1.DataSource = dt;
            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "delete";
            testButtonColumn.Text = "Xóa";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns[0].Visible = false;
            int columnIndex = dataGridView1.Columns.Count;

            if (dataGridView1.Columns["delete"] == null)
            {
                dataGridView1.Columns.Insert(columnIndex, testButtonColumn);
            }
            dataGridView1.CellClick += DataGridView1_CellClick;
            //LoadDataGridView();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {

                    string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    DataRow save = null ;
                    foreach(DataRow dtr in dt.Rows)
                    {
                        if(dtr["id"].ToString()==id)
                        {
                            save = dtr;
                        }
                    }
                    if (save != null)
                    {
                        dt.Rows.Remove(save);
                        listWithout.Remove(Convert.ToInt16(id));
                        dataGridView1.DataSource = dt;
                        suckhoetext.Text = "";
                    }
                }
            }

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
                comboBox1.DroppedDown = false;
                selected_health = HealthController.getinformation(Convert.ToInt16(comboBox1.SelectedValue.ToString()));
                DataRow dtr = dt.NewRow();
                listWithout.Add(selected_health.healthid);
                dtr["id"] = selected_health.healthid;
                dtr["bệnh"] = selected_health.name;
                dt.Rows.InsertAt(dtr,0);
              
                dataGridView1.DataSource = dt;
                suckhoetext.Text = "";
            }
        }
        List<int> listWithout = new List<int>();
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (suckhoetext.Text != "")
            {
                comboBox1.DroppedDown = false;
                selected_health = HealthController.getinformation(Convert.ToInt16(comboBox1.SelectedValue.ToString()));
                DataRow dtr = dt.NewRow();
                listWithout.Add(selected_health.healthid);
                dtr["id"] = selected_health.healthid;
                dtr["bệnh"] = selected_health.name;
                dt.Rows.InsertAt(dtr, 0);

                dataGridView1.DataSource = dt;
                suckhoetext.Text = "";


            }
        }
    }
}
