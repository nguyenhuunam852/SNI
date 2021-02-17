using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNI.Views
{
    class Module
    {
        public static string addzero(int a)
        {
            if (a < 10) return "0" + a.ToString();
            return a.ToString();
        }
        public static List<ComboBox> createMonthComboBox(ComboBox cbx,ComboBox cbx1)
        {
            using (var context = new ControllerModel())
            {
                var min = context.Reports.Min(o => o.datereport);
                var max = context.Reports.Max(o => o.datereport);

                DataTable dtb_year = new DataTable();
                dtb_year.Columns.Add("Value");
                DataTable dtb_month = new DataTable();
                dtb_month.Columns.Add("Display");
                dtb_month.Columns.Add("Value");
                for(int i=min.Year;i <=max.Year;i++)
                {
                    DataRow dtr = dtb_year.NewRow();
                    dtr["value"] = i.ToString();
                    dtb_year.Rows.Add(dtr);
                }
                cbx.DataSource = dtb_year;
                cbx.DisplayMember = "value";
                cbx.ValueMember = "value";
                cbx.DropDownStyle = ComboBoxStyle.DropDownList;

                for (int i =1; i <= 12; i++)
                {
                    DataRow dtr = dtb_month.NewRow();
                    dtr["display"] = "Tháng "+i.ToString();
                    dtr["value"] = i.ToString();

                    dtb_month.Rows.Add(dtr);
                }
                cbx1.DataSource = dtb_month;
                cbx1.DisplayMember = "display";
                cbx1.ValueMember = "value";
                cbx1.DropDownStyle = ComboBoxStyle.DropDownList;

                List<ComboBox> cblist = new List<ComboBox>() { cbx, cbx1 };
                 return cblist;

            }
        }
        public static ComboBox loadComboBox(ComboBox gioitinhcbbox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("display");
            dt.Columns.Add("value");

            DataRow dtr = dt.NewRow();
            DataRow dtr1 = dt.NewRow();
            DataRow dtr2 = dt.NewRow();


            dtr["display"] = "Nam";
            dtr["value"] = 0;
            dtr1["display"] = "Nữ";
            dtr1["value"] = 1;
            dtr2["display"] = "Khác";
            dtr2["value"] = 2;

            dt.Rows.Add(dtr);
            dt.Rows.Add(dtr1);
            dt.Rows.Add(dtr2);

            gioitinhcbbox.DataSource = dt;
            gioitinhcbbox.DisplayMember = "display";
            gioitinhcbbox.ValueMember = "value";
            gioitinhcbbox.DropDownStyle = ComboBoxStyle.DropDownList;

            return gioitinhcbbox;
        }
        public static DataGridView MydataGridView(DataGridView dtg)
        {
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.AllowUserToAddRows = false;
            dtg.RowHeadersVisible = false;
            dtg.ReadOnly = true;
            dtg.AllowUserToResizeRows = false;
            dtg.MultiSelect = false;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.CellClick += Dtg_CellClick;
           
            return dtg;
        }

        private static void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1) return;
       
        }

        public static Panel pn;
        public static Label getbuttonx(Label label1,string id)
        {
            label1.Name = id;
            label1.AutoSize = false;
            label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Size = new System.Drawing.Size(15, 13);
            label1.TabIndex = 3;
            label1.Text = "x";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return label1;
        }
        public static Label getLabel(Label label2,string text)
        {
            label2.Text = text;
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            label2.Location = new System.Drawing.Point(15, 0);
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 2;
            return label2;
        }
        public static Panel createMytab(string text,string id,Label lb)
        {
            pn = new Panel();
            pn.AutoSize = true;
            pn.TabIndex = 1;
            pn.Margin = new Padding(0, 0, 0, 0);
            Label label2 = new Label();
            label2 = getLabel(label2, text);
            lb = getbuttonx(lb, id);
            pn.Controls.Add(label2);
            pn.Controls.Add(lb);
            return pn;
        }
        public static ComboBox LoadComboboxLoai(ComboBox comboBox)
        {
            DataTable dt = new DataTable();
            dt = TypeController.getListType();


            comboBox.DataSource = dt;
            comboBox.DisplayMember = "Loại";
            comboBox.ValueMember = "Mã Số";
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            return comboBox;
        }

    }
}
