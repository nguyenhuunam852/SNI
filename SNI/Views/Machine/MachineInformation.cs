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
    public partial class MachineInformation : Form
    {
        public MachineInformation()
        {
            InitializeComponent();
        }

        public string machinesname = "";
        private void loadComboBox()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("display");
            dt.Columns.Add("value");

            DataRow dtr = dt.NewRow();
            DataRow dtr1 = dt.NewRow();

            dtr["display"] = "Bảo trì";
            dtr["value"] = 0;
            dtr1["display"] = "Hoạt động";
            dtr1["value"] = 1;

            dt.Rows.Add(dtr);
            dt.Rows.Add(dtr1);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "display";
            comboBox1.ValueMember = "value";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void MachineInformation_Load(object sender, EventArgs e)
        {
            Models.Machines mach = MachineController.getinfor(machinesname);
            textBox1.Text = mach.name;
            numericUpDown1.Value = mach.locationx;
            numericUpDown2.Value = mach.locationy;
            loadComboBox();
            comboBox1.SelectedValue = mach.status;
            label8.Text =mach.dayadd.Hour.ToString()+":"+mach.dayadd.Minute.ToString() +"  "+ mach.dayadd.Day+"/"+mach.dayadd.Month+"/"+mach.dayadd.Year;
            label9.Text = mach.dayupdate.Hour.ToString() + ":" + mach.dayupdate.Minute.ToString() + "  "+ mach.dayupdate.Day + "/" + mach.dayupdate.Month + "/" + mach.dayupdate.Year;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                button1.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MachineController.updateMachine(machinesname, textBox1.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
            this.DialogResult = DialogResult.OK;

        }
    }
}
