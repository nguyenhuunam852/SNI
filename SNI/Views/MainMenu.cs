﻿using System;
using System.Windows.Forms;
using SNI.Views;
using SNI.Controllers;
using System.Drawing;
using SNI.Views.Service;
using SNI.Views.Customer;
using SNI.Views.Health;
using SNI.Views.Type;
using System.Collections.Generic;
using System.Data;
using SNI.Views.User;
using SNI.Views.Setting;


namespace SNI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        double scaleh = 1;
        double scalew = 1;
        double scalewh = 0;
        double scaleww = 0;
        private Size startSize;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void removeAllMachine()
        {

        }
        List<Label> wotkinglabel = new List<Label>();
        List<Label> stoplabel = new List<Label>();
        private string addZero(int num)
        {
            if (num < 10)
            {
                return "0" + num.ToString();
            }
            else
            {
                return num.ToString();
            }
        }
        private TimeSpan convertInttoDateTime(int active)
        {

            int hour = active / 3600;
            active = active - hour * 3600;
            int minute = active / 60;
            active = active - minute * 60;
            int second = active;
            return new TimeSpan(hour, minute, second);
        }
        private int convertDateTimetoInt(DateTime active)
        {
            return active.Hour * 3600 + active.Minute * 60 + active.Second;
        }
        private void loadState()
        {
            wotkinglabel = new List<Label>();
            var getstoplist = ServiceController.GetAllStopWorkingMachine();
            foreach (Models.CustomerMachine cm in ServiceController.getlistworking())
            {
                
                foreach(Label lb in panel1.Controls)
                {
                    if(Convert.ToInt32(lb.Name)==cm.Machines.machineid)
                    {
                        DateTime now = DateTime.Now;
                      
                        int start = convertDateTimetoInt(cm.dayupdate);
                        int space = convertDateTimetoInt(cm.dayadd);
                        int cnow = convertDateTimetoInt(now);

                        int intsub = (cnow - space)-cm.activedtime;
                        TimeSpan datesub = convertInttoDateTime(intsub);
                        lb.Text = addZero(datesub.Hours)+":" +addZero(datesub.Minutes)+":"+addZero(datesub.Seconds);
                        lb.BackColor = Color.LightGreen;
                        if (datesub.Hours*3600+datesub.Minutes*60+datesub.Seconds>= FileConfig.config.workingtime)
                        {
                            lb.Text = "Hết giờ";
                            lb.BackColor = Color.Red;
                        }

                        if (!wotkinglabel.Contains(lb))
                        {                            
                            wotkinglabel.Add(lb);
                        }
                    }
                    
                }
            }
            foreach (int id in getstoplist)
            {
                foreach (Label lb in wotkinglabel)
                {
                    if (Convert.ToInt16(lb.Name) == id)
                    {
                        var getstopmachine = ServiceController.getStopMachinebyMachineid(id);
                        var getcustomermachine = ServiceController.getCustomerMachinebyStopMachineid(getstopmachine.stopmachineid);

                        DateTime smdate = getstopmachine.dayadd;
                        DateTime cmdate = getcustomermachine.dayadd;

                        int smint = convertDateTimetoInt(smdate);
                        int cmint = convertDateTimetoInt(cmdate);

                        int subint = (smint - cmint)-getcustomermachine.activedtime;
                        TimeSpan datesub = convertInttoDateTime(subint);
                        lb.Text = addZero(datesub.Hours) + ":" + addZero(datesub.Minutes) + ":" + addZero(datesub.Seconds);
                        lb.BackColor = Color.LightYellow;
                        stoplabel.Add(lb);
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
            lb.Location = new System.Drawing.Point(Convert.ToInt32((double)locationx / (scalew)), Convert.ToInt32((double)locationy /(scaleh)));
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lb.Text = name;
            lb.BorderStyle = BorderStyle.FixedSingle;

            lb.Size = new Size(panel1.Size.Width / 10, panel1.Size.Height / 10);
            lb.DoubleClick += Lb_DoubleClick;
            lb.MouseDown += Lb_MouseDown;
            lb.Click += Lb_Click;
            return lb;
        }
        private void Lb_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            selected_label = lb;
            if (!repairlist.Contains(lb))
            {
                if (!wotkinglabel.Contains(lb) && !stoplabel.Contains(lb))
                {
                    showname.Text = lb.Text;
                    hidden_machine_id.Text = lb.Name;
                    if (dtshowcustomer_find.DataSource != null)
                    {
                        bt_accept.Enabled = true;
                    }
                    bt_finish.Enabled = false;
                }
                else
                {
                    keycustomerText.Text = "";
                    showname.Text = "###";
                    var select_machine = MachineController.getinfor(Convert.ToInt16(lb.Name));
                    showname.Text = select_machine.name;
                    bt_finish.Enabled = true;
                    bt_accept.Enabled = false;
                    bt_finish.Focus();
                }
            }
            else
            {
                MessageBox.Show("Máy đang bảo trì", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private Label selected_label;
        private void Lb_MouseDown(object sender, MouseEventArgs e)
        {
            Label lb = sender as Label;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
               
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                selected_label = lb;
                if (stoplabel.Contains(lb))
                {
                    ContextMenu cm = new ContextMenu();
                    MenuItem item = cm.MenuItems.Add("Hoạt động");
                    item.Click += Item_Click1;
                  
                    lb.ContextMenu = cm;

                }
                else if (wotkinglabel.Contains(lb))
                {
                    ContextMenu cm = new ContextMenu();
                    MenuItem item = cm.MenuItems.Add("Tạm dừng");
                    item.Click += Item_Click;
                    MenuItem item1 = cm.MenuItems.Add("Đổi Chỗ");
                    item1.Click += Item1_Click;
                    lb.ContextMenu = cm;
                    
                }
               
            }
        }
        List<Label> repairlist = new List<Label>();
        private void Item1_Click(object sender, EventArgs e)
        {
            ChangeMachineForm cmf = new ChangeMachineForm();
            cmf.setPanelSize(startSize.Width, startSize.Height,scaleww,scalewh);
            cmf.oldid = Convert.ToInt16(selected_label.Name);
            if(cmf.ShowDialog()==DialogResult.OK)
            {
                load();
                loadState();
            }
        }
        private void Item_Click1(object sender, EventArgs e)
        {
            if (ServiceController.ActiveWorkingMachine(Convert.ToInt16(selected_label.Name)))
            {
                load();
                loadState();
            }
        }
        private void Item_Click(object sender, EventArgs e)
        {
            if(ServiceController.StopWorkingMachine(Convert.ToInt16(selected_label.Name)))
            {
                load();
                loadState();
            }
        }
        private void FinishWork(Label lb)
        {
            FinishForm ff = new FinishForm();
            ff.idghe = lb.Name;
            if (lb.Text.Contains(":"))
            {
                string[] text = lb.Text.Split(':');
                ff.time = Convert.ToInt16(text[0]) * 3600 + Convert.ToInt16(text[1]) * 60 + Convert.ToInt16(text[2]);
                if (ff.ShowDialog() == DialogResult.OK)
                {
                    load();
                    loadState();
                }
            }
            else
            {
                ff.time = FileConfig.config.workingtime;
                if (ff.ShowDialog() == DialogResult.OK)
                {
                    load();
                    loadState();
                }
            }
        }
        private void Lb_DoubleClick(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (!wotkinglabel.Contains(lb))
            {
                CustomerFind cf = new CustomerFind();
                cf.selected_machine = Convert.ToInt16(lb.Name);
                if (cf.ShowDialog() == DialogResult.OK)
                {
                    loadState();
                }
            }
            else
            {
                FinishWork(lb);
            }
        }
        private void load()
        {
            MachineController.loadMachine();
            dtshowcustomer_find.DataSource = null;
            hidden_machine_id.Text = "";
            bt_finish.Enabled = false;
            bt_accept.Enabled = false;
            keycustomerText.Text = "";
            showname.Text = "###";
            
            panel1.Controls.Clear();
            foreach (Models.Machines machine in MachineController.tempmachine)
            {
                if (machine.status != 3)
                {
                    Label lb = createLabel(machine.name,machine.machineid.ToString(), machine.status, machine.locationx, machine.locationy);
                    panel1.Controls.Add(lb);
                    if(machine.status==0)
                    {
                        repairlist.Add(lb);
                    }
                }
            }
            keycustomerText.Focus();
        }
        public Form parent;
        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.FormClosed += MainMenu_FormClosed;
            if(UserController.current.Roles.name=="Admin")
            {
                settingsToolStripMenuItem1.Visible = true;
                quảnLíUserToolStripMenuItem.Visible = true;
            }
            else
            {
                settingsToolStripMenuItem1.Visible = false;
                quảnLíUserToolStripMenuItem.Visible = false;
            }
                DateTime current = DateTime.Now;
                var listnotcheck = HistoryController.CheckListNotCheck();
                if (listnotcheck.Count > 0)
                {
                    foreach(int[] list in listnotcheck)
                    {
                        DateTime a = new DateTime(list[2],list[1],list[0]);
                        FinishReport finishForm = new FinishReport();
                        finishForm.dt = a;
                        finishForm.ShowDialog();
                    }
                }
               
                dtshowcustomer_find = Module.MydataGridView(dtshowcustomer_find);
                scalewh = (double)643 / (double)panel1.Size.Height;
                scaleww = (double)1039 / (double)panel1.Size.Width;
                scalew = 1 * scaleww;
                scaleh = 1 * scalewh;
                startSize = panel1.Size;
                bt_chotca.Enabled = false;
                            

                load();
                loadState();
                Timer time = new Timer()
                {
                    Interval = 1000
                };
                time.Start();
                time.Tick += Time_Tick;
            
           
        }
        int signal=0;
        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (signal == 0)
            {
                parent.Close();
            }
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (bt_accept.Enabled == true)
                {
                    bt_accept.PerformClick();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            DateTime check = new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
            DateTime check1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, FileConfig.config.reportstart.Hour, FileConfig.config.reportstart.Minute, FileConfig.config.reportstart.Second);
            DateTime check2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, FileConfig.config.reportfinish.Hour, FileConfig.config.reportfinish.Minute, FileConfig.config.reportfinish.Second);

            if (check1<check && check<check2)
            {
                bt_chotca.Enabled = true;
            }
            else
            {
                bt_chotca.Enabled = false;
            }
            foreach (Label lb in wotkinglabel)
            {
                if (!stoplabel.Contains(lb))
                {
                    countdown(lb);
                }
            }
        }
        private void countdown(Label lb)
        { 
            if (lb.Text.Contains(":"))
            {
                string[] time = lb.Text.Split(':');
                int hh = Convert.ToInt32(time[0]);
                int mm = Convert.ToInt32(time[1]);
                int ss = Convert.ToInt32(time[2]);

                if (hh * 3600 + mm * 60 + ss == FileConfig.config.workingtime)
                {
                    lb.Text = "Hết giờ";
                    lb.BackColor = Color.Red;
                    
                }
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

        }
        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            Panel pn = sender as Panel;

            scalew = scaleww*(double)startSize.Width / (double)pn.Size.Width;
            scaleh = scalewh*(double)startSize.Height / (double)pn.Size.Height;

            panel1.Controls.Clear();


            if (scalew != 0 && scaleh != 0)
            {

                load();
                loadState();
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
          
        }
        private void quảnLíKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMange cm = new CustomerMange();
            if (cm.ShowDialog() == DialogResult.OK)
            {
                load();
                loadState();
            }
        }
        private void quảnLíSứcKhỏeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HealthManage hm = new HealthManage();
            hm.ShowDialog();
        }
        private void keycustomerText_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if(tb.Text != "")
            {
                if (tb.Text.Length >= 3)
                {
                    DataTable data = CustomerController.FindByValueWithoutWorking(tb.Text);
                    if (data.Rows.Count > 0)
                    {
                        dtshowcustomer_find.DataSource = CustomerController.FindByValueWithoutWorking(tb.Text);
                        Cursor.Current = Cursors.Default;
                        dtshowcustomer_find.Columns["Ngày Thêm"].Visible = false;

                    }
                    else
                    {
                        dtshowcustomer_find.DataSource = null;
                    }
                }
                else
                {
                    dtshowcustomer_find.DataSource = null;
                }
            }
            else
            {
                dtshowcustomer_find.DataSource = null;
            }
        }
        private void keycustomerText_KeyDown(object sender, KeyEventArgs e)
        {
            if (dtshowcustomer_find.DataSource!=null)
            {
                int current = dtshowcustomer_find.SelectedRows[0].Index;
                if (e.KeyCode == Keys.Up)
                {
                    if (current > 0)
                    {
                        dtshowcustomer_find.ClearSelection();
                        
                        dtshowcustomer_find.Rows[current - 1].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (current < dtshowcustomer_find.Rows.Count - 1)
                    {
                        dtshowcustomer_find.ClearSelection();
                       
                        dtshowcustomer_find.Rows[current + 1].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {

                }
                if(hidden_machine_id.Text!="")
                {
                    bt_accept.Enabled = true;
                  
                }
            }
        }
        private void keycustomerText_Click(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            
        }
        private void bt_accept_Click(object sender, EventArgs e)
        {
            CustomerFind cf = new CustomerFind();
            cf.selected_machine = Convert.ToInt16(hidden_machine_id.Text);
            cf.customer = dtshowcustomer_find.Rows[dtshowcustomer_find.SelectedRows[0].Index].Cells["Mã Số"].Value.ToString();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                load();
                loadState();
            }
        }
        private void bt_finish_Click(object sender, EventArgs e)
        {
            FinishWork(selected_label);
        }
        private void bt_add_customer_Click(object sender, EventArgs e)
        {
            AddCustomerForm acf = new AddCustomerForm();
            if (acf.ShowDialog() == DialogResult.OK)
            {
                dtshowcustomer_find.DataSource = CustomerController.loadAddedCustomer();
                keycustomerText.Focus();
            }
        }
        private void dtshowcustomer_find_SelectionChanged(object sender, EventArgs e)
        {
            if(dtshowcustomer_find.Rows.Count>0 && hidden_machine_id.Text!="")
            {
                bt_accept.Enabled = true;
            }
            else
            {
                bt_accept.Enabled = false;
            }
        }
        private void bt_find_accept_Click(object sender, EventArgs e)
        {
            
            if (keycustomerText.Text != "")
            {
                DataTable data = CustomerController.FindByValueWithoutWorking(keycustomerText.Text);
                if (data.Rows.Count > 0)
                {
                    dtshowcustomer_find.DataSource = CustomerController.FindByValueWithoutWorking(keycustomerText.Text);
                    Cursor.Current = Cursors.Default;
                    dtshowcustomer_find.Columns["Ngày Thêm"].Visible = false;

                }
                else
                {
                    dtshowcustomer_find.DataSource = null;
                }
            }
        }
        private void QL_Loai_Click(object sender, EventArgs e)
        {
            TypeManage typeManage = new TypeManage();
            typeManage.ShowDialog();
        }

        private void bt_chotca_Click(object sender, EventArgs e)
        {
            FinishReport fr = new FinishReport();
            fr.dt = DateTime.Now;
            fr.ShowDialog();
            
        }

        private void MainMenu_Leave(object sender, EventArgs e)
        {
            parent.Close();
        }

        private void quảnLíUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void thốngKêVàLịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.History.HistoryForm hf = new Views.History.HistoryForm();
            hf.dt = DateTime.Now;
            hf.ShowDialog();
        }

        private void thốngKêTheoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.History.Statical_Month sm = new Views.History.Statical_Month();
            sm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CameraBarCodeForm cb = new CameraBarCodeForm();
            cb.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void quanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MachineManage machine = new MachineManage();
            machine.setPanelSize(startSize.Width, startSize.Height, scaleww, scalewh);
            if (machine.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Lưu thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel1.Controls.Clear();
                load();
                loadState();
            }
            else
            {
                load();
                loadState();
            }
        }

        private void quảnLíKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerMange cm = new CustomerMange();
            if (cm.ShowDialog() == DialogResult.OK)
            {
                load();
                loadState();
            }
        }

        private void quảnLíSứcKhỏeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HealthManage hm = new HealthManage();
            hm.ShowDialog();
        }

        private void quảnLíLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeManage typeManage = new TypeManage();
            typeManage.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            signal = 1;
            this.Close();
            
            UserController.current = null;

            parent.TopMost = true;
            parent.Refresh();
            parent.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonalForm pf = new PersonalForm();
            pf.ShowDialog();
        }

        private void quảnLíUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManage um = new UserManage();
            um.ShowDialog();
        }

        private void lịchSửToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Views.History.HistoryForm hf = new Views.History.HistoryForm();
            hf.dt = DateTime.Now;
            hf.ShowDialog();
        }

        private void thốngKêTheoThángToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Views.History.Statical_Month sm = new Views.History.Statical_Month();
            sm.ShowDialog();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Views.Setting.SettingForm sf = new Views.Setting.SettingForm();
            sf.parent = this;
            sf.ShowDialog();
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Views.Setting.BackupFile bf = new Views.Setting.BackupFile();
            bf.ShowDialog();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            CustomerController.getOldData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CustomerController.getOldData();
        }
    }
}
