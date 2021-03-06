﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views.Setting
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        public Form parent;
       
        private void database_gb_control(bool signal)
        {
            foreach(Control ctr in DataBase_gb.Controls)
            {
                if(ctr is TextBox)
                {
                    ctr.Enabled = signal;
                }
            }
            database_update.Enabled = !signal;
            database_save.Enabled = signal;
            database_close.Enabled = signal;
            servername_txt.Text = FileConfig.config.servername;
            username_txt.Text = FileConfig.config.username;
            password_txt.Text = FileConfig.config.password;
            database_txt.Text = FileConfig.config.database;
        }
        private void branch_control(bool signal)
        {
            foreach (Control ctr in branch_gb.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Enabled = signal;
                }
            }
            branch_update.Enabled = !signal;
            branch_save.Enabled = signal;
            branch_close.Enabled = signal;
            branchid_txt.Text = FileConfig.config.MaChiNhanh;
            
        }
        private void api_control(bool signal)
        {
            foreach (Control ctr in api_gb.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Enabled = signal;
                }
            }
            api_update.Enabled = !signal;
            api_save.Enabled = signal;
            api_close.Enabled = signal;

            report_api_txt.Text = FileConfig.config.reportapi;
            update_api_txt.Text = FileConfig.config.updateapi;
            usetoken.Text = FileConfig.config.usertoken;
            apptoken.Text = FileConfig.config.apptoken;
            codeGroup_txt.Text = FileConfig.config.codeGroup;
        }
        private void active_time_control(bool signal)
        {
            foreach (Control ctr in activetime_gb.Controls)
            {
                if (ctr is MaskedTextBox || ctr is DateTimePicker)
                {
                    ctr.Enabled = signal;
                }
            }
            activetime_update.Enabled = !signal;
            activetime_Save.Enabled = signal;
            activetime_close.Enabled = signal;

            int minute = FileConfig.config.workingtime / 60;
            int second = FileConfig.config.workingtime - minute * 60;

            activetime_mask.Text = AddZero(minute)+":"+AddZero(second);
            reporttime_picker.Value = FileConfig.config.reportstart;
            finishreport_picker.Value = FileConfig.config.reportfinish;

        }
        private string AddZero(int a)
        {
            if (a < 10) return "0" + a.ToString();
            return a.ToString();
        }
        private void SettingForm_Load(object sender, EventArgs e)
        {
            database_gb_control(false);
            active_time_control(false);
            branch_control(false);
            api_control(false);

        }

        private void database_update_Click(object sender, EventArgs e)
        {
            database_gb_control(true);
        }

        private void database_close_Click(object sender, EventArgs e)
        {
            database_gb_control(false);
        }

        private void database_save_Click(object sender, EventArgs e)
        {
            FileConfig.CreateConnect(servername_txt.Text, username_txt.Text, password_txt.Text, database_txt.Text,0);
            if (FileConfig.testConnect())
            {
                MessageBox.Show("Connect thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (FileConfig.CheckDatabase())
                {
                    MessageBox.Show("Tạo Database Thành Công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileConfig.CreateConnect(servername_txt.Text, username_txt.Text, password_txt.Text, database_txt.Text, 1);
                    parent.Close();
                }
                else
                {
                    MessageBox.Show("Tạo Database Thất Bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileConfig.ReadFile();
                }
            }
            else
            {
                MessageBox.Show("Connect thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileConfig.ReadFile();
            }
        }

        private void activetime_update_Click(object sender, EventArgs e)
        {
            active_time_control(true);
        }

        private void activetime_close_Click(object sender, EventArgs e)
        {
            active_time_control(false);
        }

        private void activetime_Save_Click(object sender, EventArgs e)
        {
            var list = activetime_mask.Text.Split(':');
            try
            {
                if (FileConfig.SaveTime(list, reporttime_picker.Value, finishreport_picker.Value))
                {
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    active_time_control(false);
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

        private void branch_update_Click(object sender, EventArgs e)
        {
            branch_control(true);
        }

        private void branch_save_Click(object sender, EventArgs e)
        {
            if (FileConfig.SaveBranch(branchid_txt.Text))
            {
                MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                branch_control(false);
            }
            else
            {
                MessageBox.Show("Nhập đúng Format!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void branch_close_Click(object sender, EventArgs e)
        {
            branch_control(false);
        }

        private void api_update_Click(object sender, EventArgs e)
        {
            api_control(true);
        }

        private void api_save_Click(object sender, EventArgs e)
        {
            if (FileConfig.SaveApi(report_api_txt.Text, update_api_txt.Text, apptoken.Text, usetoken.Text, codeGroup_txt.Text))
            {
                MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                api_control(false);
            }
            else
            {
                MessageBox.Show("Nhập đúng Format!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void api_close_Click(object sender, EventArgs e)
        {
            api_control(false);
        }
    }
}
