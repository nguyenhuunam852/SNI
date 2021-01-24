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
    public partial class RecoveryHealth : Form
    {
        public RecoveryHealth()
        {
            InitializeComponent();
        }

        private void RecoveryHealth_Load(object sender, EventArgs e)
        {
            DataTable dt = HealthController.getRemovedHealth();
            dataGridView1 = Module.MydataGridView(dataGridView1);
            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "recovery";
            testButtonColumn.Text = "Khôi phục";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;

            dataGridView1.DataSource = dt;

            int columnIndex = dataGridView1.Columns.Count;
            if (dataGridView1.Columns["recovery"] == null)
            {
                dataGridView1.Columns.Insert(columnIndex, testButtonColumn);
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.CellClick += DataGridView1_CellClick; ;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["recovery"].Index)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
                if (HealthController.Recovery(Convert.ToInt32(id)) == true)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
