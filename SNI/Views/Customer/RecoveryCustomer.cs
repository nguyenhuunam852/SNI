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
            dt_history = Module.MydataGridView(dt_history);
            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "recovery";
            testButtonColumn.Text = "Khôi phục";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;

            dt_history.DataSource = dt;

            int columnIndex = dt_history.Columns.Count;
            if (dt_history.Columns["recovery"] == null)
            {
                dt_history.Columns.Insert(columnIndex, testButtonColumn);
            }
            dt_history.CellClick += DataGridView1_CellClick;
           
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dt_history.Columns["recovery"].Index)
            {
                string id = dt_history.Rows[e.RowIndex].Cells["Mã Số"].Value.ToString();
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
