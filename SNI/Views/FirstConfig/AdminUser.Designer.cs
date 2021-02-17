namespace SNI.Views.FirstConfig
{
    partial class AdminUser
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
            this.name_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sdt_txt = new System.Windows.Forms.TextBox();
            this.accept_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(276, 92);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(196, 20);
            this.name_txt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email";
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(276, 133);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(196, 20);
            this.email_txt.TabIndex = 3;
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(68, 133);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(100, 20);
            this.password_txt.TabIndex = 7;
            this.password_txt.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Username";
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(68, 92);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(100, 20);
            this.username_txt.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Sdt";
            // 
            // sdt_txt
            // 
            this.sdt_txt.Location = new System.Drawing.Point(276, 171);
            this.sdt_txt.Name = "sdt_txt";
            this.sdt_txt.Size = new System.Drawing.Size(196, 20);
            this.sdt_txt.TabIndex = 8;
            // 
            // accept_button
            // 
            this.accept_button.Location = new System.Drawing.Point(68, 244);
            this.accept_button.Name = "accept_button";
            this.accept_button.Size = new System.Drawing.Size(75, 23);
            this.accept_button.TabIndex = 10;
            this.accept_button.Text = "Chấp nhận";
            this.accept_button.UseVisualStyleBackColor = true;
            this.accept_button.Click += new System.EventHandler(this.accept_button_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(177, 244);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 11;
            this.close_button.Text = "Hủy";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // AdminUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.accept_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sdt_txt);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.email_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name_txt);
            this.Name = "AdminUser";
            this.Size = new System.Drawing.Size(492, 321);
            this.Load += new System.EventHandler(this.AdminUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sdt_txt;
        private System.Windows.Forms.Button accept_button;
        private System.Windows.Forms.Button close_button;
    }
}
