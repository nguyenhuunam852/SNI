namespace SNI.Views.Service
{
    partial class ChangeMachineForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.select_machine = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trans_machine = new System.Windows.Forms.Label();
            this.bt_accept = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 275);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ghế đang chọn :";
            // 
            // select_machine
            // 
            this.select_machine.AutoSize = true;
            this.select_machine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_machine.Location = new System.Drawing.Point(108, 281);
            this.select_machine.Name = "select_machine";
            this.select_machine.Size = new System.Drawing.Size(51, 16);
            this.select_machine.TabIndex = 2;
            this.select_machine.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ghế muốn chuyển :";
            // 
            // trans_machine
            // 
            this.trans_machine.AutoSize = true;
            this.trans_machine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trans_machine.Location = new System.Drawing.Point(284, 282);
            this.trans_machine.Name = "trans_machine";
            this.trans_machine.Size = new System.Drawing.Size(32, 16);
            this.trans_machine.TabIndex = 4;
            this.trans_machine.Text = "###";
            // 
            // bt_accept
            // 
            this.bt_accept.Location = new System.Drawing.Point(368, 279);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(75, 23);
            this.bt_accept.TabIndex = 5;
            this.bt_accept.Text = "Xác nhận";
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // bt_close
            // 
            this.bt_close.Location = new System.Drawing.Point(449, 279);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 23);
            this.bt_close.TabIndex = 6;
            this.bt_close.Text = "Close";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // ChangeMachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 309);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.trans_machine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.select_machine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeMachineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangeMachineForm";
            this.Load += new System.EventHandler(this.ChangeMachineForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label select_machine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label trans_machine;
        private System.Windows.Forms.Button bt_accept;
        private System.Windows.Forms.Button bt_close;
    }
}