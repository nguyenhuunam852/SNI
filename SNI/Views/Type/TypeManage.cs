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
    public partial class TypeManage : Form
    {
        public TypeManage()
        {
            InitializeComponent();
        }
        private void loadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            if (textBox1.Text == "" || textBox1.Text.Length <= 3)
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                DataTable dt = TypeController.getListType();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = TypeController.getListType();
                    dataGridView1.Columns[0].Visible = false;
                }
            }
            else
            {
                dataGridView1 = Module.MydataGridView(dataGridView1);
                dataGridView1.DataSource = TypeController.FindType(textBox1.Text);
            }
            

            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "delete";
            testButtonColumn.Text = "Xóa";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;

            int columnIndex = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(columnIndex, testButtonColumn);
        }

        private void TypeManage_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTypeForm atf = new AddTypeForm();
            if (atf.ShowDialog() == DialogResult.OK)
            {
                loadDataGridView();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dlr == DialogResult.Yes)
                    {
                        string id = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
                        if (TypeController.RemoveType(Convert.ToInt16(id)) == true)
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecoveryTypeForm rtf = new RecoveryTypeForm();
            if (rtf.ShowDialog() == DialogResult.OK)
            {
                loadDataGridView();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            loadDataGridView();

        }
    }
}
