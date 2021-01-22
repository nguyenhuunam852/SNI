using SNI.Controllers;
using SNI.Views.Machine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views
{
    public partial class MachineManage : Form
    {
        public MachineManage()
        {
            InitializeComponent();
        }
        private Point MouseDownLocation;
        private Point PanelMouseLocation;
        double scalew = 0;
        double scaleh = 0;
        Models.Machines machineob;

        List<Models.Machines> saveList = new List<Models.Machines>();
        private void setupArea()
        {
            panel1.Controls.Clear();
            Models.Machines[] save = new Models.Machines[100];
            MachineController.tempmachine.CopyTo(save);
            saveList = save.ToList();
            foreach(Models.Machines mch in MachineController.tempmachine )
            {
                if (mch.status != 3)
                {
                    Label lb = createLabel(mch.name, mch.status, Convert.ToInt32(mch.locationx / scalew), Convert.ToInt32(mch.locationy / scaleh));
                    panel1.Controls.Add(lb);
                }
            }

            ContextMenu cm = new ContextMenu();
            MenuItem item = cm.MenuItems.Add("Thêm ghế tại đây");
            item.Click += Item_Click1;
            panel1.ContextMenu = cm ;

            panel1.MouseMove += Panel1_MouseMove;
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            PanelMouseLocation = e.Location;
        }
        private void Item_Click1(object sender, EventArgs e)
        {
            NameMachine nm = new NameMachine();
            if (nm.ShowDialog() == DialogResult.OK)
            {
                string nameofstring = nm.nameofmachine;
                int countmachine = MachineController.tempmachine.FindAll(machine => machine.name.Trim() == nameofstring.Trim()).Count;
                if (countmachine == 0)
                {
                    Label lb = createLabel(nameofstring, 1, PanelMouseLocation.X,PanelMouseLocation.Y);
                    panel1.Controls.Add(lb);
                    var machine = new Models.Machines
                    {
                        name = nm.nameofmachine,
                        locationx = Convert.ToInt32(PanelMouseLocation.X * scalew),
                        locationy = Convert.ToInt32(PanelMouseLocation.Y * scaleh),
                        status = 1
                    };
                    MachineController.tempmachine.Add(machine);

                }
                else
                {
                    MessageBox.Show("Máy này đã tồn tại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void setPanelSize(int pwidth,int pheight)
        {
            scalew = (double)pwidth/(double)panel1.Size.Width;
            scaleh = (double)pheight / (double)panel1.Size.Height;
        }
        private void MachineManage_Load(object sender, EventArgs e)
        {
            MachineController.removemachine = new List<Models.Machines>();
            setupArea();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MachineController.RemoveAllMachine() == true)
                {
                    if (MachineController.SaveAllMachine() == true)
                    {
                        
                        this.DialogResult = DialogResult.OK;
                       
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Label createLabel(String name,int status,int locationx,int locationy)
        {
            Label lb = new Label();
            //Thêm thuộc tính
            if (status == 1)
                lb.BackColor = Color.FromArgb(135, 206, 250);
            else
                lb.BackColor = Color.FromArgb(240, 128, 128);
            lb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            lb.Location = new System.Drawing.Point(Convert.ToInt32(locationx),Convert.ToInt32(locationy));
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lb.Text = name;
            lb.Size = new Size(panel1.Size.Width / 10, panel1.Size.Height / 10);
            //Thêm sự kiện
            lb.MouseDown += Lb_MouseDown;
            lb.MouseMove += Lb_MouseMove;
            lb.MouseUp += Lb_MouseUp;
            lb.DoubleClick += Lb_DoubleClick;
            return lb;
        }
        private void Lb_DoubleClick(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            MachineInformation mi = new MachineInformation();
            mi.machinesname = lb.Text;
            if(mi.ShowDialog()==DialogResult.OK)
            {
                MachineManage_Load(sender, e);
            }
        }
        private void Lb_MouseUp(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;

            int xarea1 = panel1.Location.X;
            int yarea1 = panel1.Location.Y;
            int xareawidth1 = panel1.Size.Width;
            int xareaheight1 = panel1.Size.Height;


            int lablex = lbl.Location.X;
            int labley = lbl.Location.Y;
            int countmachine = MachineController.tempmachine.FindAll(mch => mch.name == lbl.Text).Count;
            var machine = MachineController.tempmachine.Find(mch => mch.name == lbl.Text);
            if (machine != null)
            {
                machine.locationx = Convert.ToInt32(lbl.Location.X * scalew);
                machine.locationy = Convert.ToInt32(lbl.Location.Y * scaleh);
            }
        }
        private string selectmachine;
        private void Lb_MouseDown(object sender, MouseEventArgs e)
        {
            Label lb = sender as Label;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                ContextMenu cm = new ContextMenu();
                selectmachine = lb.Text;
                machineob = MachineController.getinfor(selectmachine);
                MenuItem item = cm.MenuItems.Add("Xóa ghế");
                item.Click += Item_Click;

                if (machineob.status == 1)
                {

                    MenuItem item1 = cm.MenuItems.Add("Bảo trì");
                    item1.Click += Item1_Click;
                }
                else
                {
                    MenuItem item2 = cm.MenuItems.Add("Hoạt động");
                    item2.Click += Item2_Click;
                }
                lb.ContextMenu = cm;
            }
        }

        private void Item2_Click(object sender, EventArgs e)
        {
            if (MachineController.NotRepairedMachine(machineob))
            {
                setupArea();
            }
        }

        private void Item1_Click(object sender, EventArgs e)
        {
            if(MachineController.RepairedMachine(machineob))
            {
                setupArea();
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var smachine = MachineController.tempmachine.Find(machine => machine.name.Trim() == selectmachine.Trim());
            if (smachine.machineid != 0)
            {
                MachineController.tempmachine.Remove(smachine);
                MachineController.removemachine.Add(smachine);
            }
            else
            {
                MachineController.tempmachine.Remove(smachine);
            }

            panel1.Controls.Clear();
            setupArea();
        }
        private void Lb_MouseMove(object sender, MouseEventArgs e)
        {
           Label lbl = sender as Label;
           if (e.Button == System.Windows.Forms.MouseButtons.Left)
           {
               lbl.Left = e.X + lbl.Left - MouseDownLocation.X;
               lbl.Top = e.Y + lbl.Top - MouseDownLocation.Y;
           }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }   
        void removeAllMachine()
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Nếu bạn muốn tạo nhanh phải xóa các trạng thái cũ !!!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(dlr==DialogResult.OK)
            {
                AmountOfMachines aom = new AmountOfMachines();
                if(aom.ShowDialog()==DialogResult.OK)
                {
                    foreach(Models.Machines machine in MachineController.tempmachine)
                    {
                        MachineController.removemachine.Add(machine);
                    }
                    MachineController.tempmachine.Clear();
                    panel1.Controls.Clear();
                    int nextmachinex = 20;
                    int nextmachiney = 20;
                    for(int i=0;i<aom.numofmachines;i++)
                    {
                        string name = "ghe " + (i+1).ToString();

                        Label lb = createLabel(name, 1, nextmachinex, nextmachiney);
                        MachineController.AddnewMachineTemp(name,Convert.ToInt32((double)nextmachinex*(double)scalew),Convert.ToInt32((double)nextmachiney*(double)scaleh),1);

                        nextmachinex = nextmachinex + lb.Size.Width + 20;
                        if (nextmachinex > panel1.Size.Width)
                        {
                            nextmachinex = 20;
                            nextmachiney = nextmachiney + lb.Size.Height + 20;
                        }
                        panel1.Controls.Add(lb);

                    }
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            RecoveryFormMachine rfm = new RecoveryFormMachine();
            if(rfm.ShowDialog()==DialogResult.OK)
            {
                setupArea();
            }
        }
    }
}
