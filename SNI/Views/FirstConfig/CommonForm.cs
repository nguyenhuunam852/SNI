using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.FirstConfig
{
    public partial class CommonForm : Form
    {
        public CommonForm()
        {
            InitializeComponent();
        }

        private void CommonForm_Load(object sender, EventArgs e)
        {
            DatabaseConfig dtc = new DatabaseConfig();
            dtc.parent = this;
            panel1.Controls.Add(dtc);

        }
    }
}
