using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.Machine
{
    public partial class RecoveryFormMachine : Form
    {
        public RecoveryFormMachine()
        {
            InitializeComponent();
        }
        private void loadDataTable()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "Tên máy";
            dataGridView1.Columns[2].Name = "Ngày xóa";
            dataGridView1.Columns[3].Name = "type";

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;

            DataGridViewButtonColumn testButtonColumn = new DataGridViewButtonColumn();
            testButtonColumn.Name = "recovery";
            testButtonColumn.Text = "Khôi phục";
            testButtonColumn.HeaderText = "";
            testButtonColumn.UseColumnTextForButtonValue = true;

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
                int type = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                if (type == 1)
                {
                    if (MachineController.Recovery(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value)) == true)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    if (MachineController.RecoveryTemp(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value)) == true)
                    {
                        this.DialogResult = DialogResult.OK;
                    }

                }
            }
        }

        private void RecoveryFormMachine_Load(object sender, EventArgs e)
        {
            List<Models.Machines> machines = MachineController.getListRemovedMachine();
            List<Models.Machines> tempmachines = MachineController.removemachine;

            loadDataTable();
            foreach (Models.Machines mch in tempmachines)
            {
                dataGridView1.Rows.Add(mch.machineid, mch.name, mch.dayupdate,0);
            }

            foreach (Models.Machines mch in machines)
            {
                dataGridView1.Rows.Add(mch.machineid,mch.name, mch.dayupdate,1);
            }




        }
    }
}
