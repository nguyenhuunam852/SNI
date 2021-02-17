using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.Health
{
    public partial class AddHealthForm : Form
    {
        public AddHealthForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(HealthController.addHealth(textBox1.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                button1.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void AddHealthForm_Load(object sender, EventArgs e)
        {

        }
    }
}
