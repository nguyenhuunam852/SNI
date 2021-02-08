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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime a = e.Start;
            dataGridView1.DataSource = SNI.Controllers.HistoryController.GetListHistoryinDay(a);
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            dataGridView1 = Module.MydataGridView(dataGridView1);

        }
    }
}
