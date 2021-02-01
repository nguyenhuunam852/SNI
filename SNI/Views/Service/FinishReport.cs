using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.Service
{
    public partial class FinishReport : Form
    {
        public FinishReport()
        {
            InitializeComponent();
        }
        public DateTime dt;
        private string addZero(int a)
        {
            if(a<10)
            {
                return "0" + a.ToString();
            }
            return a.ToString();
        }
        private void FinishReport_Load(object sender, EventArgs e)
        {
            lb_date.Text = "Ngày " + addZero(dt.Day) + "/" + addZero(dt.Month) + "/" + addZero(dt.Year);
            lb_amountofcustomers.Text = ReportController.getamountofday(dt).ToString();
            lb_newcustomers.Text = ReportController.getnewamountofday(dt).ToString();
            dataGridView1 = Module.MydataGridView(dataGridView1);
            dataGridView1.DataSource = ReportController.getTypeReport(dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ReportController.AddnewReport(DateTime.Now))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
