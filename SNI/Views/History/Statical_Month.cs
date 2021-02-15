using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SNI.Views.History
{
    public partial class Statical_Month : Form
    {
        public Statical_Month()
        {
            InitializeComponent();
        }
        DataTable dtb = new DataTable();
        private void ChangeChart(int month,int year)
        {
            dtb = SNI.Controllers.ReportController.getStaticalinMonth(month, year);
           
            foreach (DataRow dtr in dtb.Rows)
            {
                chart1.Series["KH hoạt động"].Points.AddXY(dtr["Ngày"].ToString(),int.Parse(dtr["Khách hàng trong ngày"].ToString()));
                chart1.Series["KH mới"].Points.AddXY(dtr["Ngày"].ToString(), int.Parse(dtr["Khách hàng mới"].ToString()));
            }
        }

        private void Statical_Month_Load(object sender, EventArgs e)
        {

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            var getlist = Module.createMonthComboBox(comboBox1, comboBox2);
            comboBox2 = getlist[0]; // Năm
            comboBox1 = getlist[1]; // Tháng

            comboBox2.SelectedValue = DateTime.Now.Year.ToString();
            comboBox1.SelectedValue = DateTime.Now.Month.ToString();

            ChangeChart(DateTime.Now.Month,DateTime.Now.Year);
          
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
           

        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Series.Points[result.PointIndex].AxisLabel == "1")
                    {
                        MessageBox.Show("Test", "");
                    }
                }
            }
        }
    }
}
