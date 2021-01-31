namespace SNI.Views.Customer
{
    partial class RecoveryCustomer
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
            this.dt_history = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dt_history)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_history
            // 
            this.dt_history.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_history.Location = new System.Drawing.Point(0, 0);
            this.dt_history.Name = "dt_history";
            this.dt_history.Size = new System.Drawing.Size(499, 324);
            this.dt_history.TabIndex = 1;
            // 
            // RecoveryCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 324);
            this.Controls.Add(this.dt_history);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RecoveryCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RecoveryCustomer";
            this.Load += new System.EventHandler(this.RecoveryCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_history)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_history;
    }
}