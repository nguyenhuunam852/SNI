namespace SNI.Views.FirstConfig
{
    partial class ActiveVariables
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reporttime_picker = new System.Windows.Forms.DateTimePicker();
            this.finishreport_picker = new System.Windows.Forms.DateTimePicker();
            this.activetime_mask = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Thời gian kết thúc báo cáo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Thời gian bắt đầu báo cáo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Thời gian hoạt động";
            // 
            // reporttime_picker
            // 
            this.reporttime_picker.CustomFormat = "hh:mm:ss";
            this.reporttime_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.reporttime_picker.Location = new System.Drawing.Point(150, 53);
            this.reporttime_picker.Name = "reporttime_picker";
            this.reporttime_picker.ShowUpDown = true;
            this.reporttime_picker.Size = new System.Drawing.Size(99, 20);
            this.reporttime_picker.TabIndex = 32;
            this.reporttime_picker.Value = new System.DateTime(2021, 2, 1, 17, 0, 0, 0);
            // 
            // finishreport_picker
            // 
            this.finishreport_picker.CustomFormat = "hh:mm:ss";
            this.finishreport_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.finishreport_picker.Location = new System.Drawing.Point(150, 90);
            this.finishreport_picker.Name = "finishreport_picker";
            this.finishreport_picker.ShowUpDown = true;
            this.finishreport_picker.Size = new System.Drawing.Size(99, 20);
            this.finishreport_picker.TabIndex = 33;
            this.finishreport_picker.Value = new System.DateTime(2021, 2, 1, 18, 0, 0, 0);
            // 
            // activetime_mask
            // 
            this.activetime_mask.Location = new System.Drawing.Point(120, 12);
            this.activetime_mask.Mask = "90:00";
            this.activetime_mask.Name = "activetime_mask";
            this.activetime_mask.Size = new System.Drawing.Size(35, 20);
            this.activetime_mask.TabIndex = 34;
            this.activetime_mask.ValidatingType = typeof(System.DateTime);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "hh:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(150, 90);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker1.TabIndex = 33;
            this.dateTimePicker1.Value = new System.DateTime(2021, 2, 1, 18, 0, 0, 0);
            // 
            // ActiveVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 176);
            this.Controls.Add(this.activetime_mask);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.finishreport_picker);
            this.Controls.Add(this.reporttime_picker);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ActiveVariables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ActiveVariables";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker reporttime_picker;
        private System.Windows.Forms.DateTimePicker finishreport_picker;
        private System.Windows.Forms.MaskedTextBox activetime_mask;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}