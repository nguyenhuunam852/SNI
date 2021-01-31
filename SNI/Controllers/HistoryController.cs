using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SNI.Models;
namespace SNI.Controllers
{
    class HistoryController
    {
        public static DataTable getHistorybyCustomerId(string id)
        {
            using (var context = new ControllerModel())
            {
                var getlist =  context.Histories.Include("Customers").Include("Machines").Where(o => o.Customers.localid == id).ToList();
                return getHistoryData(getlist);
            }
        }
        public static DataTable getHistoryData(List<History> listhistory)
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Tên Ghế");
            dtb.Columns.Add("Thời gian hoạt động");
            dtb.Columns.Add("Thời gian bắt đầu");
            foreach(History h in listhistory)
            {
                DataRow dtr = dtb.NewRow();
                dtr["Tên Ghế"] = h.Machines.name;
                dtr["Thời gian hoạt động"] = h.activetime;
                dtr["Thời gian bắt đầu"] = h.dayadd;
                dtb.Rows.Add(dtr);
            }
            return dtb;

        }
    }
}
