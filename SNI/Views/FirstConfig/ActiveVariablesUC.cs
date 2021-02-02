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
    public partial class ActiveVariablesUC : UserControl
    {
        public ActiveVariablesUC()
        {
            InitializeComponent();
        }
        public Form parent;
        Panel Panel;
        private void button1_Click(object sender, EventArgs e)
        {
            var list = activetime_mask.Text.Split(':');
            try
            {
                if (Config.SaveTime(list, reporttime_picker.Value, finishreport_picker.Value))
                {
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BranchSetting bs = new BranchSetting();
                    bs.parent = parent;
                    Panel.Controls.Clear();
                    Panel.Controls.Add(bs);
                }
                else
                {
                    MessageBox.Show("Nhập đúng Format!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhập đúng Format!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parent.Close();
        }

        private void ActiveVariablesUC_Load(object sender, EventArgs e)
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
