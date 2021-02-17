namespace SNI.Views.Service
{
    partial class FinishForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.machinename = new System.Windows.Forms.Label();
            this.customername = new System.Windows.Forms.Label();
            this.activetime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.starttime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ghế";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên khách hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thời gian hoạt động";
            // 
            // machinename
            // 
            this.machinename.AutoSize = true;
            this.machinename.Location = new System.Drawing.Point(160, 34);
            this.machinename.Name = "machinename";
            this.machinename.Size = new System.Drawing.Size(13, 13);
            this.machinename.TabIndex = 3;
            this.machinename.Text = "a";
            // 
            // customername
            // 
            this.customername.AutoSize = true;
            this.customername.Location = new System.Drawing.Point(160, 68);
            this.customername.Name = "customername";
            this.customername.Size = new System.Drawing.Size(35, 13);
            this.customername.TabIndex = 4;
            this.customername.Text = "label5";
            // 
            // activetime
            // 
            this.activetime.AutoSize = true;
            this.activetime.Location = new System.Drawing.Point(160, 104);
            this.activetime.Name = "activetime";
            this.activetime.Size = new System.Drawing.Size(35, 13);
            this.activetime.TabIndex = 5;
            this.activetime.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Thời gian bắt đầu";
            // 
            // starttime
            // 
            this.starttime.AutoSize = true;
            this.starttime.Location = new System.Drawing.Point(160, 139);
            this.starttime.Name = "starttime";
            this.starttime.Size = new System.Drawing.Size(35, 13);
            this.starttime.TabIndex = 7;
            this.starttime.Text = "label8";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(141, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "(giờ:phút:giây)";
            // 
            // FinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 239);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.starttime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.activetime);
            this.Controls.Add(this.customername);
            this.Controls.Add(this.machinename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FinishForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FinishForm";
            this.Load += new System.EventHandler(this.FinishForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label machinename;
        private System.Windows.Forms.Label customername;
        private System.Windows.Forms.Label activetime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label starttime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}