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
        public int signal = 0;
        private void CommonForm_Load(object sender, EventArgs e)
        {
            if (signal == 0)
            {
                DatabaseConfig dtc = new DatabaseConfig();
                dtc.parent = this;
                panel1.Controls.Add(dtc);
            }
            else
            {
                AdminUser au = new AdminUser();
                au.parent = this;
                panel1.Controls.Add(au);
            }

        }
    }
}
