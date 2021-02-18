namespace SNI.Views.FirstConfig
{
    partial class ApiSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.update_api_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.report_api_txt = new System.Windows.Forms.TextBox();
            this.apptoken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usetoken = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.codeGroup_txt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // update_api_txt
            // 
            this.update_api_txt.Location = new System.Drawing.Point(184, 98);
            this.update_api_txt.Name = "update_api_txt";
            this.update_api_txt.Size = new System.Drawing.Size(211, 20);
            this.update_api_txt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Update Api";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Report Api";
            // 
            // report_api_txt
            // 
            this.report_api_txt.Location = new System.Drawing.Point(184, 57);
            this.report_api_txt.Name = "report_api_txt";
            this.report_api_txt.Size = new System.Drawing.Size(211, 20);
            this.report_api_txt.TabIndex = 0;
            // 
            // apptoken
            // 
            this.apptoken.Location = new System.Drawing.Point(184, 175);
            this.apptoken.Name = "apptoken";
            this.apptoken.Size = new System.Drawing.Size(211, 20);
            this.apptoken.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "AppToken";
            // 
            // usetoken
            // 
            this.usetoken.Location = new System.Drawing.Point(184, 138);
            this.usetoken.Name = "usetoken";
            this.usetoken.Size = new System.Drawing.Size(211, 20);
            this.usetoken.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "UseToken";
            // 
            // codeGroup_txt
            // 
            this.codeGroup_txt.Location = new System.Drawing.Point(184, 210);
            this.codeGroup_txt.Name = "codeGroup_txt";
            this.codeGroup_txt.Size = new System.Drawing.Size(211, 20);
            this.codeGroup_txt.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(90, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 58;
            this.label13.Text = "Code Group";
            // 
            // ApiSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.codeGroup_txt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.apptoken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usetoken);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.update_api_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.report_api_txt);
            this.Name = "ApiSettings";
            this.Size = new System.Drawing.Size(492, 321);
            this.Load += new System.EventHandler(this.ApiSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox update_api_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox report_api_txt;
        private System.Windows.Forms.TextBox apptoken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usetoken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codeGroup_txt;
        private System.Windows.Forms.Label label13;
    }
}
