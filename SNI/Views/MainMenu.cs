using System;
using System.Windows.Forms;
using SNI.Views;
using SNI.Controllers;
using System.Drawing;
using SNI.Views.Service;
using SNI.Views.Customer;
using SNI.Views.Health;
using System.Collections.Generic;

namespace SNI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        double scalew = 1;
        double scaleh = 1;
        private Size startSize;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void removeAllMachine()
        {

        }
        List<Label> wotkinglabel = new List<Label>();
        private void loadState()
        {
            foreach(Models.CustomerMachine cm in ServiceController.getlistworking())
            {
                foreach(Label lb in panel1.Controls)
                {
                    if(Convert.ToInt32(lb.Name)==cm.Machines.machineid)
                    {
                        DateTime now = DateTime.Now;
                        TimeSpan a = new TimeSpan(cm.dayadd.Hour, cm.dayadd.Minute, cm.dayadd.Second);
                        TimeSpan b = new TimeSpan(now.Hour, now.Minute, now.Second);

                        TimeSpan datesub = b-a  ;
                        lb.Text = datesub.Hours.ToString()+":" +datesub.Minutes.ToString()+":"+datesub.Seconds.ToString();
                        wotkinglabel.Add(lb);
                    }
                }
            }
        }

        private Label createLabel(String name,String id, int status, int locationx, int locationy)
        {
            Label lb = new Label();
            //Thêm thuộc tính
            if (status == 1)
                lb.BackColor = Color.FromArgb(135, 206, 250);
            else
                lb.BackColor = Color.FromArgb(240, 128, 128);
            lb.Name = id;
            lb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            lb.Location = new System.Drawing.Point(Convert.ToInt32((double)locationx / scalew), Convert.ToInt32((double)locationy / scaleh));
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lb.Text = name;
            lb.Size = new Size(panel1.Size.Width / 10, panel1.Size.Height / 10);
            lb.DoubleClick += Lb_DoubleClick;
            return lb;
        }
        private void Lb_DoubleClick(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            CustomerFind cf = new CustomerFind();
            cf.selected_machine = Convert.ToInt16(lb.Name);
            if(cf.ShowDialog()==DialogResult.OK)
            {
                loadState();
            }
        }
        private void load()
        {
            foreach (Models.Machines machine in MachineController.tempmachine)
            {
                if (machine.status != 3)
                {
                    Label lb = createLabel(machine.name,machine.machineid.ToString(), machine.status, machine.locationx, machine.locationy);
                    panel1.Controls.Add(lb);
                }
            }

        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            scalew = 1;
            scaleh = 1;
            startSize = panel1.Size;
            MachineController.loadMachine();
            load();
            loadState();
            Timer time = new Timer()
            {
                Interval = 1000
            };


            time.Start();
            time.Tick += Time_Tick; ;
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            foreach (Label lb in wotkinglabel)
            {
                 countdown(lb);
            }
        }
        private void countdown(Label lb)
        {
            string[] time = lb.Text.Split(':');
            int hh = Convert.ToInt32(time[0]);
            int mm = Convert.ToInt32(time[1]);
            int ss = Convert.ToInt32(time[2]);
            if (ss == 0 && mm == 0 && hh == 0) { }
            else
            {
                ss += 1;
                if (ss > 59) { mm += 1; ss = 0; }
                if (mm > 59) { hh += 1; mm = 0; }

                string hour = hh.ToString();
                if (hh < 10) { hour = "0" + hour; }
                string minute = mm.ToString();
                if (mm < 10) { minute = "0" + minute; }
                string second = ss.ToString();
                if (ss < 10)
                {
                    second = "0" + second;
                }

                lb.Text = hour + ":" + minute + ":" + second;
            }

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            Panel pn = sender as Panel;
            scalew = (double)startSize.Width / (double)pn.Size.Width;
            scaleh = (double)startSize.Height / (double)pn.Size.Height;
            panel1.Controls.Clear();

            if (scalew != 0 && scaleh != 0)
            {
                load();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
          
        }

        private void quảnLíGhếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MachineManage machine = new MachineManage();
            machine.setPanelSize(panel1.Size.Width, panel1.Size.Height);
            if (machine.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Lưu thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel1.Controls.Clear();
                MainMenu_Load(sender, e);
            }
            else
            {
                MainMenu_Load(sender, e);
            }
        }

        private void quảnLíKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMange cm = new CustomerMange();
            if (cm.ShowDialog() == DialogResult.OK)
            {
                MainMenu_Load(sender, e);
            }
        }

        private void quảnLíSứcKhỏeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HealthManage hm = new HealthManage();
            hm.ShowDialog();
        }
    }
}
