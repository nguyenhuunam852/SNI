using System;
using System.Windows.Forms;
using SNI.Views;
using SNI.Controllers;
using System.Drawing;
using SNI.Views.Service;
using SNI.Views.Customer;
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
        private Label createLabel(String name, int status, int locationx, int locationy)
        {
            Label lb = new Label();
            //Thêm thuộc tính
            if (status == 1)
                lb.BackColor = Color.FromArgb(135, 206, 250);
            else
                lb.BackColor = Color.FromArgb(240, 128, 128);
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
            cf.ShowDialog();
        }
        private void load()
        {
            foreach (Models.Machines machine in MachineController.tempmachine)
            {
                if (machine.status != 3)
                {
                    Label lb = createLabel(machine.name, machine.status, machine.locationx, machine.locationy);
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
            MachineManage machine = new MachineManage();
            machine.setPanelSize(panel1.Size.Width, panel1.Size.Height);
            if(machine.ShowDialog()==DialogResult.OK)
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
        private void label2_Click(object sender, EventArgs e)
        {
            CustomerMange cm = new CustomerMange();
            if(cm.ShowDialog()==DialogResult.OK)
            {
                MainMenu_Load(sender, e);
            }
        }

    }
}
