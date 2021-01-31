namespace SNI.Views.Customer
{
    partial class AddCustomerForm
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
            this.nametext = new System.Windows.Forms.TextBox();
            this.sdttext = new System.Windows.Forms.TextBox();
            this.gioitinhcbbox = new System.Windows.Forms.ComboBox();
            this.diachirichtext = new System.Windows.Forms.RichTextBox();
            this.tuoinumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.suckhoetext = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.idlabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.loaiCombobox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tuoinumber)).BeginInit();
            this.SuspendLayout();
            // 
            // nametext
            // 
            this.nametext.Location = new System.Drawing.Point(78, 44);
            this.nametext.Name = "nametext";
            this.nametext.Size = new System.Drawing.Size(272, 20);
            this.nametext.TabIndex = 0;
            // 
            // sdttext
            // 
            this.sdttext.Location = new System.Drawing.Point(78, 70);
            this.sdttext.Name = "sdttext";
            this.sdttext.Size = new System.Drawing.Size(272, 20);
            this.sdttext.TabIndex = 1;
            this.sdttext.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // gioitinhcbbox
            // 
            this.gioitinhcbbox.FormattingEnabled = true;
            this.gioitinhcbbox.Location = new System.Drawing.Point(78, 96);
            this.gioitinhcbbox.Name = "gioitinhcbbox";
            this.gioitinhcbbox.Size = new System.Drawing.Size(79, 21);
            this.gioitinhcbbox.TabIndex = 2;
            // 
            // diachirichtext
            // 
            this.diachirichtext.Location = new System.Drawing.Point(78, 165);
            this.diachirichtext.Name = "diachirichtext";
            this.diachirichtext.Size = new System.Drawing.Size(272, 96);
            this.diachirichtext.TabIndex = 4;
            this.diachirichtext.Text = "";
            // 
            // tuoinumber
            // 
            this.tuoinumber.Location = new System.Drawing.Point(78, 123);
            this.tuoinumber.Name = "tuoinumber";
            this.tuoinumber.Size = new System.Drawing.Size(79, 20);
            this.tuoinumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sđt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tuổi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Địa chỉ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // suckhoetext
            // 
            this.suckhoetext.Location = new System.Drawing.Point(78, 266);
            this.suckhoetext.Name = "suckhoetext";
            this.suckhoetext.Size = new System.Drawing.Size(272, 20);
            this.suckhoetext.TabIndex = 5;
            this.suckhoetext.TextChanged += new System.EventHandler(this.suckhoetext_TextChanged);
            this.suckhoetext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suckhoetext_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Sức khỏe";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(78, 265);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(272, 21);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(78, 289);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(272, 150);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(272, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(272, 20);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mã";
            // 
            // idlabel
            // 
            this.idlabel.AutoSize = true;
            this.idlabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idlabel.ForeColor = System.Drawing.Color.Red;
            this.idlabel.Location = new System.Drawing.Point(74, 11);
            this.idlabel.Name = "idlabel";
            this.idlabel.Size = new System.Drawing.Size(53, 21);
            this.idlabel.TabIndex = 20;
            this.idlabel.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(190, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Loại";
            // 
            // loaiCombobox
            // 
            this.loaiCombobox.FormattingEnabled = true;
            this.loaiCombobox.Location = new System.Drawing.Point(227, 96);
            this.loaiCombobox.Name = "loaiCombobox";
            this.loaiCombobox.Size = new System.Drawing.Size(79, 21);
            this.loaiCombobox.TabIndex = 22;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(312, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 410);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.loaiCombobox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.idlabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.suckhoetext);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tuoinumber);
            this.Controls.Add(this.diachirichtext);
            this.Controls.Add(this.gioitinhcbbox);
            this.Controls.Add(this.sdttext);
            this.Controls.Add(this.nametext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddCustomerForm";
            this.Load += new System.EventHandler(this.AddCustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tuoinumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nametext;
        private System.Windows.Forms.TextBox sdttext;
        private System.Windows.Forms.ComboBox gioitinhcbbox;
        private System.Windows.Forms.RichTextBox diachirichtext;
        private System.Windows.Forms.NumericUpDown tuoinumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox suckhoetext;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label idlabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox loaiCombobox;
        private System.Windows.Forms.Button button3;
    }
}