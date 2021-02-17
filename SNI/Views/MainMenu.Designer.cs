namespace SNI
{
    partial class MainMenu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLíGhếToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíSứcKhỏeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QL_Loai = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêVàLịchSửToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêTheoThángToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtshowcustomer_find = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_chotca = new System.Windows.Forms.Button();
            this.bt_finish = new System.Windows.Forms.Button();
            this.hidden_machine_id = new System.Windows.Forms.TextBox();
            this.showname = new System.Windows.Forms.Label();
            this.bt_find_accept = new System.Windows.Forms.Button();
            this.bt_accept = new System.Windows.Forms.Button();
            this.bt_add_customer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.keycustomerText = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtshowcustomer_find)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(6, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 387);
            this.panel1.TabIndex = 0;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLíGhếToolStripMenuItem,
            this.quảnLíKháchHàngToolStripMenuItem,
            this.quảnLíSứcKhỏeToolStripMenuItem,
            this.QL_Loai,
            this.settingsToolStripMenuItem,
            this.quảnLíUsersToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.thốngKêVàLịchSửToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLíGhếToolStripMenuItem
            // 
            this.quảnLíGhếToolStripMenuItem.Name = "quảnLíGhếToolStripMenuItem";
            this.quảnLíGhếToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.quảnLíGhếToolStripMenuItem.Text = "Quản lí Ghế";
            this.quảnLíGhếToolStripMenuItem.Click += new System.EventHandler(this.quảnLíGhếToolStripMenuItem_Click);
            // 
            // quảnLíKháchHàngToolStripMenuItem
            // 
            this.quảnLíKháchHàngToolStripMenuItem.Name = "quảnLíKháchHàngToolStripMenuItem";
            this.quảnLíKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.quảnLíKháchHàngToolStripMenuItem.Text = "Quản lí Khách Hàng";
            this.quảnLíKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLíKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLíSứcKhỏeToolStripMenuItem
            // 
            this.quảnLíSứcKhỏeToolStripMenuItem.Name = "quảnLíSứcKhỏeToolStripMenuItem";
            this.quảnLíSứcKhỏeToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.quảnLíSứcKhỏeToolStripMenuItem.Text = "Quản lí Sức Khỏe";
            this.quảnLíSứcKhỏeToolStripMenuItem.Click += new System.EventHandler(this.quảnLíSứcKhỏeToolStripMenuItem_Click);
            // 
            // QL_Loai
            // 
            this.QL_Loai.Name = "QL_Loai";
            this.QL_Loai.Size = new System.Drawing.Size(82, 20);
            this.QL_Loai.Text = "Quản lí Loại";
            this.QL_Loai.Click += new System.EventHandler(this.QL_Loai_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // quảnLíUsersToolStripMenuItem
            // 
            this.quảnLíUsersToolStripMenuItem.Name = "quảnLíUsersToolStripMenuItem";
            this.quảnLíUsersToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.quảnLíUsersToolStripMenuItem.Text = "Quản Lí Users";
            this.quảnLíUsersToolStripMenuItem.Click += new System.EventHandler(this.quảnLíUsersToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // thốngKêVàLịchSửToolStripMenuItem
            // 
            this.thốngKêVàLịchSửToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lịchSửToolStripMenuItem,
            this.thốngKêTheoThángToolStripMenuItem});
            this.thốngKêVàLịchSửToolStripMenuItem.Name = "thốngKêVàLịchSửToolStripMenuItem";
            this.thốngKêVàLịchSửToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.thốngKêVàLịchSửToolStripMenuItem.Text = "Thống Kê và Lịch Sử";
            this.thốngKêVàLịchSửToolStripMenuItem.Click += new System.EventHandler(this.thốngKêVàLịchSửToolStripMenuItem_Click);
            // 
            // lịchSửToolStripMenuItem
            // 
            this.lịchSửToolStripMenuItem.Name = "lịchSửToolStripMenuItem";
            this.lịchSửToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.lịchSửToolStripMenuItem.Text = "Lịch Sử";
            this.lịchSửToolStripMenuItem.Click += new System.EventHandler(this.lịchSửToolStripMenuItem_Click);
            // 
            // thốngKêTheoThángToolStripMenuItem
            // 
            this.thốngKêTheoThángToolStripMenuItem.Name = "thốngKêTheoThángToolStripMenuItem";
            this.thốngKêTheoThángToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.thốngKêTheoThángToolStripMenuItem.Text = "Thống kê theo Tháng";
            this.thốngKêTheoThángToolStripMenuItem.Click += new System.EventHandler(this.thốngKêTheoThángToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(486, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 387);
            this.panel2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.Controls.Add(this.dtshowcustomer_find);
            this.panel4.Location = new System.Drawing.Point(0, 205);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(302, 176);
            this.panel4.TabIndex = 0;
            // 
            // dtshowcustomer_find
            // 
            this.dtshowcustomer_find.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtshowcustomer_find.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtshowcustomer_find.Location = new System.Drawing.Point(0, 0);
            this.dtshowcustomer_find.Name = "dtshowcustomer_find";
            this.dtshowcustomer_find.Size = new System.Drawing.Size(302, 176);
            this.dtshowcustomer_find.TabIndex = 7;
            this.dtshowcustomer_find.SelectionChanged += new System.EventHandler(this.dtshowcustomer_find_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.bt_chotca);
            this.panel3.Controls.Add(this.bt_finish);
            this.panel3.Controls.Add(this.hidden_machine_id);
            this.panel3.Controls.Add(this.showname);
            this.panel3.Controls.Add(this.bt_find_accept);
            this.panel3.Controls.Add(this.bt_accept);
            this.panel3.Controls.Add(this.bt_add_customer);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.keycustomerText);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 205);
            this.panel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_chotca
            // 
            this.bt_chotca.Enabled = false;
            this.bt_chotca.Location = new System.Drawing.Point(161, 105);
            this.bt_chotca.Name = "bt_chotca";
            this.bt_chotca.Size = new System.Drawing.Size(115, 38);
            this.bt_chotca.TabIndex = 13;
            this.bt_chotca.Text = "Chốt Ca";
            this.bt_chotca.UseVisualStyleBackColor = true;
            this.bt_chotca.Click += new System.EventHandler(this.bt_chotca_Click);
            // 
            // bt_finish
            // 
            this.bt_finish.Enabled = false;
            this.bt_finish.Location = new System.Drawing.Point(161, 62);
            this.bt_finish.Name = "bt_finish";
            this.bt_finish.Size = new System.Drawing.Size(115, 37);
            this.bt_finish.TabIndex = 12;
            this.bt_finish.Text = "Kết thúc";
            this.bt_finish.UseVisualStyleBackColor = true;
            this.bt_finish.Click += new System.EventHandler(this.bt_finish_Click);
            // 
            // hidden_machine_id
            // 
            this.hidden_machine_id.Location = new System.Drawing.Point(0, 27);
            this.hidden_machine_id.Name = "hidden_machine_id";
            this.hidden_machine_id.Size = new System.Drawing.Size(10, 20);
            this.hidden_machine_id.TabIndex = 11;
            this.hidden_machine_id.Visible = false;
            this.hidden_machine_id.WordWrap = false;
            // 
            // showname
            // 
            this.showname.AutoSize = true;
            this.showname.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showname.ForeColor = System.Drawing.Color.Red;
            this.showname.Location = new System.Drawing.Point(116, 15);
            this.showname.Name = "showname";
            this.showname.Size = new System.Drawing.Size(60, 33);
            this.showname.TabIndex = 9;
            this.showname.Text = "###";
            // 
            // bt_find_accept
            // 
            this.bt_find_accept.Location = new System.Drawing.Point(176, 168);
            this.bt_find_accept.Name = "bt_find_accept";
            this.bt_find_accept.Size = new System.Drawing.Size(56, 23);
            this.bt_find_accept.TabIndex = 8;
            this.bt_find_accept.Text = "Tìm";
            this.bt_find_accept.UseVisualStyleBackColor = true;
            this.bt_find_accept.Click += new System.EventHandler(this.bt_find_accept_Click);
            // 
            // bt_accept
            // 
            this.bt_accept.Enabled = false;
            this.bt_accept.Location = new System.Drawing.Point(19, 62);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(115, 38);
            this.bt_accept.TabIndex = 10;
            this.bt_accept.Text = "Đặt ghế ";
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // bt_add_customer
            // 
            this.bt_add_customer.Location = new System.Drawing.Point(19, 106);
            this.bt_add_customer.Name = "bt_add_customer";
            this.bt_add_customer.Size = new System.Drawing.Size(115, 37);
            this.bt_add_customer.TabIndex = 1;
            this.bt_add_customer.Text = "Thêm Khách Hàng";
            this.bt_add_customer.UseVisualStyleBackColor = true;
            this.bt_add_customer.Click += new System.EventHandler(this.bt_add_customer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nhập thông tin tìm kiếm";
            // 
            // keycustomerText
            // 
            this.keycustomerText.Location = new System.Drawing.Point(4, 170);
            this.keycustomerText.Name = "keycustomerText";
            this.keycustomerText.Size = new System.Drawing.Size(169, 20);
            this.keycustomerText.TabIndex = 2;
            this.keycustomerText.Click += new System.EventHandler(this.keycustomerText_Click);
            this.keycustomerText.TextChanged += new System.EventHandler(this.keycustomerText_TextChanged);
            this.keycustomerText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keycustomerText_KeyDown);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(816, 488);
            this.Name = "MainMenu";
            this.Text = "SNI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Leave += new System.EventHandler(this.MainMenu_Leave);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtshowcustomer_find)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLíGhếToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíSứcKhỏeToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_add_customer;
        private System.Windows.Forms.TextBox keycustomerText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtshowcustomer_find;
        private System.Windows.Forms.Button bt_find_accept;
        private System.Windows.Forms.Label showname;
        private System.Windows.Forms.Button bt_accept;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox hidden_machine_id;
        private System.Windows.Forms.Button bt_chotca;
        private System.Windows.Forms.Button bt_finish;
        private System.Windows.Forms.ToolStripMenuItem QL_Loai;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêVàLịchSửToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêTheoThángToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

