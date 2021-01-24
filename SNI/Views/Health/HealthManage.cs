using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.Health
{
    public partial class HealthManage : Form
    {
        public HealthManage()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AddHealthbyExcelForm abef = new AddHealthbyExcelForm();
            if (abef.ShowDialog() == DialogResult.OK)
            {
                loadDataGridView();
            }
        }
        private void loadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            if (textBox1.Text == "" || textBox1.Text.Length<=3)
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = HealthController.getListHealth();
            }
            else
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = HealthController.FindHealth(textBox1.Text);
            }
            dataGridView1.Columns[0].Visible = false;
         

            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "delete";
            testButtonColumn.Text = "Xóa";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;

            int columnIndex = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(columnIndex, testButtonColumn);
         

        }
        private void HealthManage_Load(object sender, EventArgs e)
        {
            loadDataGridView();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
                    if (HealthController.RemoveHealth(Convert.ToInt16(id)) == true)
                    {
                        loadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            loadDataGridView();
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddHealthForm ahf = new AddHealthForm();
            if(ahf.ShowDialog()==DialogResult.OK)
            {
                loadDataGridView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecoveryHealth rh = new RecoveryHealth();
            if(rh.ShowDialog()==DialogResult.OK)
            {
                loadDataGridView();
            }
        }
    }
}
