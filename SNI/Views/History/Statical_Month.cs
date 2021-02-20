using SNI.Controllers;
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
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            var getlist = Module.createMonthComboBox(comboBox1, comboBox2);
            if (getlist != null)
            {
                comboBox2 = getlist[0]; // Năm
                comboBox1 = getlist[1]; // Tháng


                comboBox2.SelectedValue = DateTime.Now.Year.ToString();
                comboBox1.SelectedValue = DateTime.Now.Month.ToString();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
           

        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        int year;
        int month;
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0 && comboBox2.Items.Count > 0)
            {
                try
                {
                    year = int.Parse(comboBox2.SelectedValue.ToString());
                    month = int.Parse(comboBox1.SelectedValue.ToString());
                    ChangeChart(month, year);
                    label3.Text = ReportController.getCustomerActiveinMonth(month, year).ToString();
                    label4.Text = ReportController.getNewCustomerActiveinMonth(month, year).ToString();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0 && comboBox2.Items.Count > 0 )
            {
                try
                {
                    year = int.Parse(comboBox2.SelectedValue.ToString());
                    month = int.Parse(comboBox1.SelectedValue.ToString());
                    ChangeChart(month, year);
                    label3.Text = ReportController.getCustomerActiveinMonth(month, year).ToString();
                    label4.Text = ReportController.getNewCustomerActiveinMonth(month, year).ToString();

                }
                catch (Exception ex)
                { 
                }
            }
        }

        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    int day = int.Parse(result.Series.Points[result.PointIndex].AxisLabel);
                    DateTime date = new DateTime(year, month, day);
                    HistoryForm hf = new HistoryForm();
                    hf.dt = date;
                    hf.ShowDialog();
                }
            }
        }
    }
}
