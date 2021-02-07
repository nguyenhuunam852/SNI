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
    public partial class BranchSetting : UserControl
    {
        public BranchSetting()
        {
            InitializeComponent();
        }
        public Form parent;
        Panel Panel;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Config.SaveBranch(branchid_txt.Text))
            {
                MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ApiSettings apis = new ApiSettings();
                apis.parent = parent;
                Panel.Controls.Clear();
                Panel.Controls.Add(apis);
            }
            else
            {
                MessageBox.Show("Nhập đúng Format!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BranchSetting_Load(object sender, EventArgs e)
        {
            foreach (Control ctr in parent.Controls)
            {
                if (ctr is Panel)
                {
                    Panel = (Panel)ctr;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parent.Close();
        }
    }
}
