using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.Type
{
    public partial class RecoveryTypeForm : Form
    {
        public RecoveryTypeForm()
        {
            InitializeComponent();
        }

        private void RecoveryTypeForm_Load(object sender, EventArgs e)
        {
            DataTable dt = TypeController.getRemovedType();
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
            dataGridView1.CellClick += DataGridView1_CellClick; 
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == dataGridView1.Columns["recovery"].Index)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
                    if (TypeController.Recovery(Convert.ToInt32(id)) == true)
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
}
