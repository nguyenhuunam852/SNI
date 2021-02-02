namespace SNI.Views.User
{
    partial class UserManage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.recovery_bt = new System.Windows.Forms.Button();
            this.add_bt = new System.Windows.Forms.Button();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.save_bt = new System.Windows.Forms.Button();
            this.close_bt = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.sdt_txt = new System.Windows.Forms.TextBox();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.update_bt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(298, 348);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // recovery_bt
            // 
            this.recovery_bt.Location = new System.Drawing.Point(23, 41);
            this.recovery_bt.Name = "recovery_bt";
            this.recovery_bt.Size = new System.Drawing.Size(116, 23);
            this.recovery_bt.TabIndex = 9;
            this.recovery_bt.Text = "Khôi phục";
            this.recovery_bt.UseVisualStyleBackColor = true;
            this.recovery_bt.Click += new System.EventHandler(this.recovery_bt_Click);
            // 
            // add_bt
            // 
            this.add_bt.Location = new System.Drawing.Point(23, 12);
            this.add_bt.Name = "add_bt";
            this.add_bt.Size = new System.Drawing.Size(116, 23);
            this.add_bt.TabIndex = 8;
            this.add_bt.Text = "Thêm ";
            this.add_bt.UseVisualStyleBackColor = true;
            this.add_bt.Click += new System.EventHandler(this.button1_Click);
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(70, 137);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(191, 20);
            this.password_txt.TabIndex = 23;
            this.password_txt.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Username";
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(70, 111);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(191, 20);
            this.username_txt.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.save_bt);
            this.panel1.Controls.Add(this.close_bt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.sdt_txt);
            this.panel1.Controls.Add(this.email_txt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.name_txt);
            this.panel1.Controls.Add(this.password_txt);
            this.panel1.Controls.Add(this.username_txt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(298, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 249);
            this.panel1.TabIndex = 24;
            // 
            // save_bt
            // 
            this.save_bt.Location = new System.Drawing.Point(145, 17);
            this.save_bt.Name = "save_bt";
            this.save_bt.Size = new System.Drawing.Size(116, 23);
            this.save_bt.TabIndex = 30;
            this.save_bt.Text = "Lưu";
            this.save_bt.UseVisualStyleBackColor = true;
            this.save_bt.Click += new System.EventHandler(this.save_bt_Click);
            // 
            // close_bt
            // 
            this.close_bt.Location = new System.Drawing.Point(20, 17);
            this.close_bt.Name = "close_bt";
            this.close_bt.Size = new System.Drawing.Size(116, 23);
            this.close_bt.TabIndex = 11;
            this.close_bt.Text = "Hủy";
            this.close_bt.UseVisualStyleBackColor = true;
            this.close_bt.Click += new System.EventHandler(this.close_bt_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Sdt";
            // 
            // sdt_txt
            // 
            this.sdt_txt.Location = new System.Drawing.Point(70, 214);
            this.sdt_txt.Name = "sdt_txt";
            this.sdt_txt.Size = new System.Drawing.Size(191, 20);
            this.sdt_txt.TabIndex = 28;
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(70, 189);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(191, 20);
            this.email_txt.TabIndex = 27;
            this.email_txt.TextChanged += new System.EventHandler(this.email_txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tên";
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(70, 163);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(191, 20);
            this.name_txt.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.update_bt);
            this.panel2.Controls.Add(this.add_bt);
            this.panel2.Controls.Add(this.recovery_bt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(298, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 100);
            this.panel2.TabIndex = 25;
            // 
            // update_bt
            // 
            this.update_bt.Location = new System.Drawing.Point(145, 12);
            this.update_bt.Name = "update_bt";
            this.update_bt.Size = new System.Drawing.Size(116, 23);
            this.update_bt.TabIndex = 10;
            this.update_bt.Text = "Sửa";
            this.update_bt.UseVisualStyleBackColor = true;
            this.update_bt.Click += new System.EventHandler(this.update_bt_Click);
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 348);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserManage";
            this.Load += new System.EventHandler(this.UserManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button recovery_bt;
        private System.Windows.Forms.Button add_bt;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sdt_txt;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Button update_bt;
        private System.Windows.Forms.Button save_bt;
        private System.Windows.Forms.Button close_bt;
    }
}