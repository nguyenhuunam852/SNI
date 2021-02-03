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
        public static List<int[]> CheckListNotCheck()
        {
            using (var context = new ControllerModel())
            {
                var getlist = context.Histories.Where(o => o.ischeck == false 
                && (o.dayadd.Day!=DateTime.Now.Day
                || o.dayadd.Month!=DateTime.Now.Month
                || o.dayadd.Year!=DateTime.Now.Year)
                ).Select(o => new { o.dayadd.Day, o.dayadd.Month, o.dayadd.Year }).Distinct().ToList();

                List<int[]> htr = new List<int[]>();
                foreach(var i in getlist)
                {
                    int[] array = new int[] { i.Day, i.Month, i.Year };
                    htr.Add(array);
                }
                return htr;
            }
        }
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
