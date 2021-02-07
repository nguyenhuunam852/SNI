namespace SNI.Views.Setting
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataBase_gb = new System.Windows.Forms.GroupBox();
            this.database_close = new System.Windows.Forms.Button();
            this.database_save = new System.Windows.Forms.Button();
            this.database_txt = new System.Windows.Forms.TextBox();
            this.database_update = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.servername_txt = new System.Windows.Forms.TextBox();
            this.activetime_gb = new System.Windows.Forms.GroupBox();
            this.activetime_close = new System.Windows.Forms.Button();
            this.activetime_Save = new System.Windows.Forms.Button();
            this.activetime_update = new System.Windows.Forms.Button();
            this.activetime_mask = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.finishreport_picker = new System.Windows.Forms.DateTimePicker();
            this.reporttime_picker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.branch_gb = new System.Windows.Forms.GroupBox();
            this.branch_close = new System.Windows.Forms.Button();
            this.branch_save = new System.Windows.Forms.Button();
            this.branch_update = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.branchid_txt = new System.Windows.Forms.TextBox();
            this.apptoken = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.usetoken = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.api_gb = new System.Windows.Forms.GroupBox();
            this.api_close = new System.Windows.Forms.Button();
            this.api_save = new System.Windows.Forms.Button();
            this.api_update = new System.Windows.Forms.Button();
            this.update_api_txt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.report_api_txt = new System.Windows.Forms.TextBox();
            this.codeGroup_txt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DataBase_gb.SuspendLayout();
            this.activetime_gb.SuspendLayout();
            this.branch_gb.SuspendLayout();
            this.api_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataBase_gb
            // 
            this.DataBase_gb.Controls.Add(this.database_close);
            this.DataBase_gb.Controls.Add(this.database_save);
            this.DataBase_gb.Controls.Add(this.database_txt);
            this.DataBase_gb.Controls.Add(this.database_update);
            this.DataBase_gb.Controls.Add(this.label4);
            this.DataBase_gb.Controls.Add(this.password_txt);
            this.DataBase_gb.Controls.Add(this.label3);
            this.DataBase_gb.Controls.Add(this.username_txt);
            this.DataBase_gb.Controls.Add(this.label2);
            this.DataBase_gb.Controls.Add(this.label1);
            this.DataBase_gb.Controls.Add(this.servername_txt);
            this.DataBase_gb.Location = new System.Drawing.Point(13, 12);
            this.DataBase_gb.Name = "DataBase_gb";
            this.DataBase_gb.Size = new System.Drawing.Size(273, 222);
            this.DataBase_gb.TabIndex = 0;
            this.DataBase_gb.TabStop = false;
            this.DataBase_gb.Text = "Database Setting";
            // 
            // database_close
            // 
            this.database_close.Location = new System.Drawing.Point(132, 193);
            this.database_close.Name = "database_close";
            this.database_close.Size = new System.Drawing.Size(75, 23);
            this.database_close.TabIndex = 45;
            this.database_close.Text = "Hủy";
            this.database_close.UseVisualStyleBackColor = true;
            this.database_close.Click += new System.EventHandler(this.database_close_Click);
            // 
            // database_save
            // 
            this.database_save.Location = new System.Drawing.Point(51, 193);
            this.database_save.Name = "database_save";
            this.database_save.Size = new System.Drawing.Size(75, 23);
            this.database_save.TabIndex = 44;
            this.database_save.Text = "Lưu";
            this.database_save.UseVisualStyleBackColor = true;
            this.database_save.Click += new System.EventHandler(this.database_save_Click);
            // 
            // database_txt
            // 
            this.database_txt.Location = new System.Drawing.Point(107, 153);
            this.database_txt.Name = "database_txt";
            this.database_txt.Size = new System.Drawing.Size(135, 20);
            this.database_txt.TabIndex = 39;
            // 
            // database_update
            // 
            this.database_update.Location = new System.Drawing.Point(163, 10);
            this.database_update.Name = "database_update";
            this.database_update.Size = new System.Drawing.Size(75, 23);
            this.database_update.TabIndex = 43;
            this.database_update.Text = "Thay đổi";
            this.database_update.UseVisualStyleBackColor = true;
            this.database_update.Click += new System.EventHandler(this.database_update_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Database";
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(107, 117);
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '*';
            this.password_txt.Size = new System.Drawing.Size(135, 20);
            this.password_txt.TabIndex = 35;
            this.password_txt.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Password";
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(107, 80);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(135, 20);
            this.username_txt.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "UserName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "ServerName";
            // 
            // servername_txt
            // 
            this.servername_txt.Location = new System.Drawing.Point(107, 39);
            this.servername_txt.Name = "servername_txt";
            this.servername_txt.Size = new System.Drawing.Size(135, 20);
            this.servername_txt.TabIndex = 30;
            // 
            // activetime_gb
            // 
            this.activetime_gb.Controls.Add(this.activetime_close);
            this.activetime_gb.Controls.Add(this.activetime_Save);
            this.activetime_gb.Controls.Add(this.activetime_update);
            this.activetime_gb.Controls.Add(this.activetime_mask);
            this.activetime_gb.Controls.Add(this.dateTimePicker1);
            this.activetime_gb.Controls.Add(this.finishreport_picker);
            this.activetime_gb.Controls.Add(this.reporttime_picker);
            this.activetime_gb.Controls.Add(this.label5);
            this.activetime_gb.Controls.Add(this.label6);
            this.activetime_gb.Controls.Add(this.label7);
            this.activetime_gb.Location = new System.Drawing.Point(12, 240);
            this.activetime_gb.Name = "activetime_gb";
            this.activetime_gb.Size = new System.Drawing.Size(273, 210);
            this.activetime_gb.TabIndex = 1;
            this.activetime_gb.TabStop = false;
            this.activetime_gb.Text = "Active Time Setting";
            // 
            // activetime_close
            // 
            this.activetime_close.Location = new System.Drawing.Point(133, 173);
            this.activetime_close.Name = "activetime_close";
            this.activetime_close.Size = new System.Drawing.Size(75, 23);
            this.activetime_close.TabIndex = 47;
            this.activetime_close.Text = "Hủy";
            this.activetime_close.UseVisualStyleBackColor = true;
            this.activetime_close.Click += new System.EventHandler(this.activetime_close_Click);
            // 
            // activetime_Save
            // 
            this.activetime_Save.Location = new System.Drawing.Point(52, 173);
            this.activetime_Save.Name = "activetime_Save";
            this.activetime_Save.Size = new System.Drawing.Size(75, 23);
            this.activetime_Save.TabIndex = 46;
            this.activetime_Save.Text = "Lưu";
            this.activetime_Save.UseVisualStyleBackColor = true;
            this.activetime_Save.Click += new System.EventHandler(this.activetime_Save_Click);
            // 
            // activetime_update
            // 
            this.activetime_update.Location = new System.Drawing.Point(174, 22);
            this.activetime_update.Name = "activetime_update";
            this.activetime_update.Size = new System.Drawing.Size(75, 23);
            this.activetime_update.TabIndex = 46;
            this.activetime_update.Text = "Thay đổi";
            this.activetime_update.UseVisualStyleBackColor = true;
            this.activetime_update.Click += new System.EventHandler(this.activetime_update_Click);
            // 
            // activetime_mask
            // 
            this.activetime_mask.Location = new System.Drawing.Point(133, 44);
            this.activetime_mask.Mask = "90:00";
            this.activetime_mask.Name = "activetime_mask";
            this.activetime_mask.Size = new System.Drawing.Size(35, 20);
            this.activetime_mask.TabIndex = 52;
            this.activetime_mask.Text = "3000";
            this.activetime_mask.ValidatingType = typeof(System.DateTime);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "hh:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(163, 122);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker1.TabIndex = 50;
            this.dateTimePicker1.Value = new System.DateTime(2021, 2, 1, 18, 0, 0, 0);
            // 
            // finishreport_picker
            // 
            this.finishreport_picker.CustomFormat = "hh:mm:ss";
            this.finishreport_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.finishreport_picker.Location = new System.Drawing.Point(163, 122);
            this.finishreport_picker.Name = "finishreport_picker";
            this.finishreport_picker.ShowUpDown = true;
            this.finishreport_picker.Size = new System.Drawing.Size(99, 20);
            this.finishreport_picker.TabIndex = 51;
            this.finishreport_picker.Value = new System.DateTime(2021, 2, 1, 18, 0, 0, 0);
            // 
            // reporttime_picker
            // 
            this.reporttime_picker.CustomFormat = "hh:mm:ss";
            this.reporttime_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.reporttime_picker.Location = new System.Drawing.Point(163, 85);
            this.reporttime_picker.Name = "reporttime_picker";
            this.reporttime_picker.ShowUpDown = true;
            this.reporttime_picker.Size = new System.Drawing.Size(99, 20);
            this.reporttime_picker.TabIndex = 49;
            this.reporttime_picker.Value = new System.DateTime(2021, 2, 1, 17, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Thời gian kết thúc báo cáo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Thời gian bắt đầu báo cáo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Thời gian hoạt động";
            // 
            // branch_gb
            // 
            this.branch_gb.Controls.Add(this.branch_close);
            this.branch_gb.Controls.Add(this.branch_save);
            this.branch_gb.Controls.Add(this.branch_update);
            this.branch_gb.Controls.Add(this.label10);
            this.branch_gb.Controls.Add(this.branchid_txt);
            this.branch_gb.Location = new System.Drawing.Point(305, 13);
            this.branch_gb.Name = "branch_gb";
            this.branch_gb.Size = new System.Drawing.Size(314, 112);
            this.branch_gb.TabIndex = 2;
            this.branch_gb.TabStop = false;
            this.branch_gb.Text = "Branch Setting";
            // 
            // branch_close
            // 
            this.branch_close.Location = new System.Drawing.Point(161, 64);
            this.branch_close.Name = "branch_close";
            this.branch_close.Size = new System.Drawing.Size(75, 23);
            this.branch_close.TabIndex = 47;
            this.branch_close.Text = "Hủy";
            this.branch_close.UseVisualStyleBackColor = true;
            this.branch_close.Click += new System.EventHandler(this.branch_close_Click);
            // 
            // branch_save
            // 
            this.branch_save.Location = new System.Drawing.Point(80, 64);
            this.branch_save.Name = "branch_save";
            this.branch_save.Size = new System.Drawing.Size(75, 23);
            this.branch_save.TabIndex = 46;
            this.branch_save.Text = "Lưu";
            this.branch_save.UseVisualStyleBackColor = true;
            this.branch_save.Click += new System.EventHandler(this.branch_save_Click);
            // 
            // branch_update
            // 
            this.branch_update.Location = new System.Drawing.Point(229, 9);
            this.branch_update.Name = "branch_update";
            this.branch_update.Size = new System.Drawing.Size(75, 23);
            this.branch_update.TabIndex = 53;
            this.branch_update.Text = "Thay đổi";
            this.branch_update.UseVisualStyleBackColor = true;
            this.branch_update.Click += new System.EventHandler(this.branch_update_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Mã chi nhánh";
            // 
            // branchid_txt
            // 
            this.branchid_txt.Location = new System.Drawing.Point(97, 38);
            this.branchid_txt.Name = "branchid_txt";
            this.branchid_txt.Size = new System.Drawing.Size(211, 20);
            this.branchid_txt.TabIndex = 36;
            // 
            // apptoken
            // 
            this.apptoken.Location = new System.Drawing.Point(97, 171);
            this.apptoken.Name = "apptoken";
            this.apptoken.Size = new System.Drawing.Size(200, 20);
            this.apptoken.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "AppToken";
            // 
            // usetoken
            // 
            this.usetoken.Location = new System.Drawing.Point(97, 134);
            this.usetoken.Name = "usetoken";
            this.usetoken.Size = new System.Drawing.Size(200, 20);
            this.usetoken.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "UseToken";
            // 
            // api_gb
            // 
            this.api_gb.Controls.Add(this.codeGroup_txt);
            this.api_gb.Controls.Add(this.label13);
            this.api_gb.Controls.Add(this.api_close);
            this.api_gb.Controls.Add(this.api_save);
            this.api_gb.Controls.Add(this.api_update);
            this.api_gb.Controls.Add(this.apptoken);
            this.api_gb.Controls.Add(this.update_api_txt);
            this.api_gb.Controls.Add(this.label8);
            this.api_gb.Controls.Add(this.label11);
            this.api_gb.Controls.Add(this.usetoken);
            this.api_gb.Controls.Add(this.label9);
            this.api_gb.Controls.Add(this.label12);
            this.api_gb.Controls.Add(this.report_api_txt);
            this.api_gb.Location = new System.Drawing.Point(305, 136);
            this.api_gb.Name = "api_gb";
            this.api_gb.Size = new System.Drawing.Size(314, 300);
            this.api_gb.TabIndex = 42;
            this.api_gb.TabStop = false;
            this.api_gb.Text = "Api Setting";
            // 
            // api_close
            // 
            this.api_close.Location = new System.Drawing.Point(151, 251);
            this.api_close.Name = "api_close";
            this.api_close.Size = new System.Drawing.Size(75, 23);
            this.api_close.TabIndex = 55;
            this.api_close.Text = "Hủy";
            this.api_close.UseVisualStyleBackColor = true;
            this.api_close.Click += new System.EventHandler(this.api_close_Click);
            // 
            // api_save
            // 
            this.api_save.Location = new System.Drawing.Point(70, 251);
            this.api_save.Name = "api_save";
            this.api_save.Size = new System.Drawing.Size(75, 23);
            this.api_save.TabIndex = 54;
            this.api_save.Text = "Lưu";
            this.api_save.UseVisualStyleBackColor = true;
            this.api_save.Click += new System.EventHandler(this.api_save_Click);
            // 
            // api_update
            // 
            this.api_update.Location = new System.Drawing.Point(229, 19);
            this.api_update.Name = "api_update";
            this.api_update.Size = new System.Drawing.Size(75, 23);
            this.api_update.TabIndex = 54;
            this.api_update.Text = "Thay đổi";
            this.api_update.UseVisualStyleBackColor = true;
            this.api_update.Click += new System.EventHandler(this.api_update_Click);
            // 
            // update_api_txt
            // 
            this.update_api_txt.Location = new System.Drawing.Point(97, 89);
            this.update_api_txt.Name = "update_api_txt";
            this.update_api_txt.Size = new System.Drawing.Size(200, 20);
            this.update_api_txt.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Update Api";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "Report Api";
            // 
            // report_api_txt
            // 
            this.report_api_txt.Location = new System.Drawing.Point(97, 49);
            this.report_api_txt.Name = "report_api_txt";
            this.report_api_txt.Size = new System.Drawing.Size(200, 20);
            this.report_api_txt.TabIndex = 42;
            // 
            // codeGroup_txt
            // 
            this.codeGroup_txt.Location = new System.Drawing.Point(97, 204);
            this.codeGroup_txt.Name = "codeGroup_txt";
            this.codeGroup_txt.Size = new System.Drawing.Size(200, 20);
            this.codeGroup_txt.TabIndex = 57;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 56;
            this.label13.Text = "Code Group";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 448);
            this.Controls.Add(this.api_gb);
            this.Controls.Add(this.branch_gb);
            this.Controls.Add(this.activetime_gb);
            this.Controls.Add(this.DataBase_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.DataBase_gb.ResumeLayout(false);
            this.DataBase_gb.PerformLayout();
            this.activetime_gb.ResumeLayout(false);
            this.activetime_gb.PerformLayout();
            this.branch_gb.ResumeLayout(false);
            this.branch_gb.PerformLayout();
            this.api_gb.ResumeLayout(false);
            this.api_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DataBase_gb;
        private System.Windows.Forms.TextBox database_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox servername_txt;
        private System.Windows.Forms.GroupBox activetime_gb;
        private System.Windows.Forms.MaskedTextBox activetime_mask;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker finishreport_picker;
        private System.Windows.Forms.DateTimePicker reporttime_picker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox branch_gb;
        private System.Windows.Forms.TextBox apptoken;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox usetoken;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox branchid_txt;
        private System.Windows.Forms.GroupBox api_gb;
        private System.Windows.Forms.TextBox update_api_txt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox report_api_txt;
        private System.Windows.Forms.Button database_update;
        private System.Windows.Forms.Button database_close;
        private System.Windows.Forms.Button database_save;
        private System.Windows.Forms.Button activetime_close;
        private System.Windows.Forms.Button activetime_Save;
        private System.Windows.Forms.Button activetime_update;
        private System.Windows.Forms.Button branch_close;
        private System.Windows.Forms.Button branch_save;
        private System.Windows.Forms.Button branch_update;
        private System.Windows.Forms.Button api_close;
        private System.Windows.Forms.Button api_save;
        private System.Windows.Forms.Button api_update;
        private System.Windows.Forms.TextBox codeGroup_txt;
        private System.Windows.Forms.Label label13;
    }
}