using SNI.Controllers;
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
    public partial class ChangeMachineForm : Form
    {
        public ChangeMachineForm()
        {
            InitializeComponent();
        }
        double scalew = 0;
        double scaleh = 0;
        public int oldid;
        private Label createLabel(int id, String name, int status, int locationx, int locationy)
        {
            Label lb = new Label();
            //Thêm thuộc tính
            if (status == 1)
                lb.BackColor = Color.FromArgb(135, 206, 250);
            else
                lb.BackColor = Color.FromArgb(240, 128, 128);
            lb.Name = id.ToString();
            lb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            lb.Location = new System.Drawing.Point(Convert.ToInt32(locationx), Convert.ToInt32(locationy));
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lb.Text = name;
            lb.Size = new Size(panel1.Size.Width / 10, panel1.Size.Height / 10);
            lb.DoubleClick += Lb_DoubleClick;
            return lb;
        }

        private void Lb_DoubleClick(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            int newid = Convert.ToInt32(lb.Name);
            if(ServiceController.ChangeMachine(oldid, newid))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        public void setPanelSize(int pwidth, int pheight)
        {
            scalew = (double)pwidth / (double)panel1.Size.Width;
            scaleh = (double)pheight / (double)panel1.Size.Height;
        }
        private void setupArea()
        {
            panel1.Controls.Clear();
            Models.Machines[] save = new Models.Machines[100];
            
            foreach (Models.Machines mch in MachineController.getAllDtbMachine())
            {
                if (mch.status != 3)
                {
                    Label lb = createLabel(mch.machineid, mch.name, mch.status, Convert.ToInt32(mch.locationx / scalew), Convert.ToInt32(mch.locationy / scaleh));
                    panel1.Controls.Add(lb);
                }
            }
         
        }
        private void ChangeMachineForm_Load(object sender, EventArgs e)
        {
            setupArea();
        }
    }
}
