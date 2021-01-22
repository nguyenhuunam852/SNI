using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.Service
{
    public partial class CustomerFind : Form
    {
        public CustomerFind()
        {
            InitializeComponent();
        }

        private void CustomerFind_Load(object sender, EventArgs e)
        {
            textBox1.Location = new Point(0, 0);
            comboBox1.Location = new Point(0, 0);

            textBox1.Size = new Size(this.Size.Width, textBox1.Size.Height);
            comboBox1.Size = new Size(this.Size.Width, comboBox1.Size.Height);
            
            this.AutoSize = true;
            this.BackColor = Color.Azure;
            this.Controls.SetChildIndex(textBox1, 0);


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
