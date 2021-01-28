using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using SNI.Models;
using System.Data;

namespace SNI.Controllers
{
    class HealthController
    {
        public static Health addedhealth;
        public static Health getinformation(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    return context.Healths.Where(hl => hl.healthid == id).FirstOrDefault();
                }
                catch(Exception e)
                {
                    return null;
                }
            
            } 
        }
        public static DataTable FindHealthWithoutselected(string find,List<Health> listWithout)
        {
            using (var context = new ControllerModel())
            {
                List<int> properties = listWithout.Select(o => o.healthid).ToList();
                var listhealth = context.Healths.Where(heal => heal.available == true && heal.name.Contains(find) && properties.Contains(heal.healthid)==false).Take(10).ToList();
                return loadHealth(listhealth);
            }
        }
        public static bool RemoveHealth(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var health = context.Healths.Where(heal => heal.healthid == id).FirstOrDefault();
                    health.available = false;
                    health.dayupdate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
        public static bool addHealth(string health)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    int check = context.Healths.Where(heal => heal.name.Trim() == health.Trim()).Count();
                    if (check == 0)
                    {
                        var hl = new Health
                        {
                            name = health,
                            available = true,
                            dayadd = DateTime.Now,
                            dayupdate = DateTime.Now
                        };
                        context.Healths.Add(hl);
                        context.SaveChanges();
                        addedhealth = hl;
                        return true;
                    }
                    else
                    {
                        var gethealth = context.Healths.Where(heal => heal.name.Trim() == health.Trim()).FirstOrDefault();
                        gethealth.available = true;
                        context.SaveChanges();
                        addedhealth = gethealth;
                        return true;
                    }
                }
                catch(Exception e)
                {
                    return false;
                }
                
            }
        }
        public static bool Recovery(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var health = context.Healths.Where(heal => heal.healthid == id).FirstOrDefault();
                    health.available = true;
                    health.dayupdate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public static DataTable getRemovedHealth()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var listhealth = context.Healths.Where(health => health.available == false).OrderByDescending(health => health.dayadd).Take(10).ToList();
                    return loadCustomerWithUpdate(listhealth);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public static DataTable getListHealth()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var listhealth = context.Healths.Where(health => health.available == true).OrderByDescending(health => health.dayadd).Take(10).ToList();
                    return loadHealth(listhealth);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public static DataTable FindHealth(string find)
        {
            using (var context = new ControllerModel())
            {
                var listhealth = context.Healths.Where(heal => heal.available == true && heal.name.Contains(find)).Take(10).ToList();
                return loadHealth(listhealth);
            }
        }
        private static DataTable loadHealth(List<Health> listcustomer)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Số");
            dt.Columns.Add("Bệnh");
            dt.Columns.Add("Ngày Thêm");
            foreach (Health health in listcustomer)
            {
                DataRow dtr = dt.NewRow();
                dtr["Mã Số"] = health.healthid;
                dtr["Bệnh"] = health.name;
                dtr["Ngày Thêm"] = health.dayadd.Hour + ":" + health.dayadd.Minute + "-" + health.dayadd.Day + "/" + health.dayadd.Month + "/" + health.dayadd.Year;
                dt.Rows.Add(dtr);
            }
            return dt;

        }
        public static DataTable loadCustomerWithUpdate(List<Health> listhealth)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mã Số");
                    dt.Columns.Add("Bệnh");
                    dt.Columns.Add("Ngày Xóa");
                    foreach (Health hl in listhealth)
                    {
                        DataRow dtr = dt.NewRow();
                        dtr["Mã Số"] = hl.healthid;
                        dtr["Bệnh"] = hl.name;
                        dtr["Ngày Xóa"] = hl.dayupdate.Hour + ":" + hl.dayupdate.Minute + "-" + hl.dayupdate.Day + "/" + hl.dayupdate.Month + "/" + hl.dayupdate.Year;
                        dt.Rows.Add(dtr);
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public static bool addHealthbyExcel(string filename)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    string text;
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook book = app.Workbooks.Open(filename);
                    Excel.Worksheet xlWorksheet = (Excel.Worksheet)book.Sheets.get_Item(1);
                    Excel.Range xlRange = xlWorksheet.UsedRange;
                    object[,] valueArray = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
                    for (int i = 0; i < xlWorksheet.UsedRange.Rows.Count; i++)
                    {
                        for (int j = 0; j < xlWorksheet.UsedRange.Columns.Count; j++)
                        {
                            try
                            {
                                text = valueArray[i + 1, j + 1].ToString();  
                                if (text != null)
                                {
                                    addHealth(text);
                                }
                            }
                            catch(Exception e)
                            {
                                
                            }
                        }
                    }

                    return true;
                }
                catch(Exception e)
                {

                    return false;
                }
            }
       
        }
    }
}
