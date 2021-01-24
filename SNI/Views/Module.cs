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

    }
}
