using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.Machine
{
    public partial class NameMachine : Form
    {
        public NameMachine()
        {
            InitializeComponent();
        }
        public string nameofmachine = "";
        private void button1_Click(object sender, EventArgs e)
        {
            nameofmachine = textBox1.Text;
            this.DialogResult = DialogResult.OK;
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

        private void NameMachine_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
