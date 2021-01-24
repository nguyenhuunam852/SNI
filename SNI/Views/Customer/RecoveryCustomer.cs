using System;
using System.Data;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.Customer
{
    public partial class RecoveryCustomer : Form
    {
        public RecoveryCustomer()
        {
            InitializeComponent();
        }

        private void RecoveryCustomer_Load(object sender, EventArgs e)
        {
            DataTable dt = CustomerController.getRemovedListCustomer();
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
            dataGridView1.CellClick += DataGridView1_CellClick;
           
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["recovery"].Index)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
                if(CustomerController.Recovery(id)==true)
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
