using System;
using System.Windows.Forms;
using SNI.Controllers;
namespace SNI.Views.Service
{
    public partial class FinishForm : Form
    {
        public FinishForm()
        {
            InitializeComponent();
        }

        public string idghe;
        Models.Machines mch;
        Models.Customers cus;
        Models.CustomerMachine cm;
        public int time = 0;
        int saveactive = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ServiceController.FinishWork(cus.localid, mch.machineid,cm.customermachineid, cm.dayadd, saveactive))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FinishForm_Load(object sender, EventArgs e)
        {
            mch = MachineController.getinfor(Convert.ToInt32(idghe));
            cus = ServiceController.getcustomerinfbymachine(Convert.ToInt32(idghe));
            machinename.Text = mch.name;
            customername.Text = cus.name;
            cm = ServiceController.getInformation(mch.machineid, cus.localid);
            DateTime now = DateTime.Now;
            DateTime start = cm.dayadd;

            int active =  time;
            int subactive = Config.config.workingtime - active;
            
            if (subactive<=0)
            {
                active = Config.config.workingtime;
            }

            saveactive = active;
            int hour = active / 3600;
            active = active - hour * 3600;
            int minute = active / 60;
            active = active - minute * 60;
            int second = active;
            activetime.Text = addZero(hour) + ":" + addZero(minute) + ":" + addZero(second);
            starttime.Text = cm.dayadd.ToString();

        }
        private string addZero(int num)
        {
            if(num<10)
            {
                return "0" + num.ToString();
            }
            else
            {
                return num.ToString();
            }
        }
    }
}
