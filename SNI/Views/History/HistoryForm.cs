using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.History
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }
        public DateTime dt;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
      
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime a = e.Start;
            label1.Text = Module.addzero(a.Day) + "/" + Module.addzero(a.Month) + "/" + a.Year.ToString();
            DataTable dtb = SNI.Controllers.HistoryController.GetListHistoryinDay(a);
            dataGridView1.DataSource = dtb;
            dataGridView2.DataSource = ReportController.getTypeReport(a);

            amount_lb.Text = ReportController.getamountofday(a).ToString();
            new_lb.Text = ReportController.getnewamountofday(a).ToString();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            dataGridView2 = Module.MydataGridView(dataGridView2);
            dataGridView1 = Module.MydataGridView(dataGridView1);

            monthCalendar1.SelectionStart = dt;
            label1.Text = Module.addzero(dt.Day) + "/" + Module.addzero(dt.Month)+"/" + dt.Year.ToString();
            Models.Reports rp = Controllers.ReportController.getReportbyDay(dt);
            amount_lb.Text = rp.amountofactivecustomer.ToString();
            new_lb.Text = rp.amountofnewcustomer.ToString();


            dataGridView1.DataSource = HistoryController.GetListHistoryinDay(monthCalendar1.SelectionStart);
            dataGridView2.DataSource = ReportController.getTypeReport(dt);

        }
    }
}
