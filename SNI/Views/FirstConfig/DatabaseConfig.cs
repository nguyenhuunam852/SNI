using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.FirstConfig
{
    public partial class DatabaseConfig : UserControl
    {
        public DatabaseConfig()
        {
            InitializeComponent();
        }
        public Form parent;
        
        private void button1_Click(object sender, EventArgs e)
        {
            Config.CreateConnect(servername_txt.Text, username_txt.Text, password_txt.Text, database_txt.Text,1);
           
                MessageBox.Show("Connect thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Config.CheckDatabase())
                {
                    MessageBox.Show("Tạo Database Thành Công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Panel.Controls.Clear();
                    ActiveVariablesUC avuc = new ActiveVariablesUC();
                    avuc.parent = parent;
                    Panel.Controls.Add(avuc);

                }
                else
                {
                    MessageBox.Show("Tạo Database Thất Bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parent.Close();
        }
        Panel Panel;
        private void DatabaseConfig_Load(object sender, EventArgs e)
        {
            foreach(Control ctr in parent.Controls)
            {
                if(ctr is Panel)
                {
                    Panel = (Panel)ctr;
                }
            }
        }

        private void DatabaseConfig_Load_1(object sender, EventArgs e)
        {
            foreach (Control ctr in parent.Controls)
            {
                if (ctr is Panel)
                {
                    Panel = (Panel)ctr;
                }
            }
        }
    }
}
