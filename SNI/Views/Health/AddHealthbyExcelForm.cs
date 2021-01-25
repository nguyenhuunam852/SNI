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
    public partial class AddHealthbyExcelForm : Form
    {
        public AddHealthbyExcelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void AddHealthbyExcelForm_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.xlsx)|*.xlsx";
            textBox1.Enabled = false;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                button2.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(HealthController.addHealthbyExcel(textBox1.Text)==true)
            {
                MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
