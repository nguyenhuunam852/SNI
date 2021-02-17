using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SNI.Models;
using SNI.Views;

namespace SNI.Controllers
{
    class HistoryController
    {
        public static DataTable GetListHistoryinDay(DateTime dt)
        {
            using (var context = new ControllerModel())
            {
                DataTable dtb = new DataTable();
                dtb.Columns.Add("Tên Khách Hàng");
                dtb.Columns.Add("Tên Máy");
                dtb.Columns.Add("Thời gian hoạt động");
                List<History> lh = context.Histories.Include("Customers").Include("Machines").Where(o => 
                o.daystart.Year == dt.Year
                && o.daystart.Month == dt.Month
                && o.daystart.Day == dt.Day).ToList();
                foreach(History h in lh)
                {
                    DataRow dtr = dtb.NewRow();
                    dtr["Tên Khách Hàng"] = h.Customers.name;
                    dtr["Tên Máy"] = h.Machines.name;
                    int minute = h.activetime / 60;
                    int secone = h.activetime - minute * 60;
                    dtr["Thời gian hoạt động"] = minute.ToString() + ":" + secone.ToString();
                    dtb.Rows.Add(dtr);
                }
                return dtb;
            }
        }
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

                var getserverreport = context.Reports.Where(o => o.serverreport == false).ToList();
                foreach(Reports rp in getserverreport)
                {
                    int[] array = new int[] { rp.datereport.Day,rp.datereport.Month,rp.datereport.Year };
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
                DataTable dtb = new DataTable();
                dtb.Columns.Add("Tên Ghế");
                dtb.Columns.Add("Thời gian hoạt động");
                dtb.Columns.Add("Thời gian bắt đầu");
                foreach(History his in getlist)
                {
                    DataRow dtr = dtb.NewRow();
                    dtr["Tên Ghế"] = his.Machines.name;
                    int[] hour = Module.convertSecond(his.activetime);
                    dtr["Thời gian hoạt động"] = Module.addzero(hour[0])+":"+Module.addzero(hour[1])+":"+Module.addzero(hour[2]);
                    dtr["Thời gian bắt đầu"] = his.dayadd.ToString();
                    dtb.Rows.Add(dtr);
                }
                return dtb;
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
