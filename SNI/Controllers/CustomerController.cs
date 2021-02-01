using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SNI.Models;

namespace SNI.Controllers
{
    class CustomerController
    {
        public static Customers addedCustomer;
        public static DataTable getListCustomer()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var listcustomer = context.Customers.Where(cus => cus.available == true).OrderBy(cus => cus.dayadd).Take(10).ToList();
                    return loadCustomer(listcustomer);
                    
                }
                catch(Exception e)
                {
                    return null;
                }
            }
        }
        public static DataTable getExcelListCustomer()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var listcustomer = context.Customers.Include("Types").Where(cus => cus.available == true).OrderBy(cus => cus.dayadd).Take(10).ToList();
                    return loadExcelCustomer(listcustomer);

                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }
        public static DataTable getRemovedListCustomer()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var listcustomer = context.Customers.Where(cus => cus.available == false).OrderBy(cus => cus.dayadd).Take(10).ToList();
                    return loadCustomerWithUpdate(listcustomer);

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public static DataTable loadExcelCustomer(List<Customers> listcustomer)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mã Số");
                    dt.Columns.Add("Họ Tên");
                    dt.Columns.Add("Số điện Thoại");
                    dt.Columns.Add("Năm sinh");
                    dt.Columns.Add("Địa chỉ");
                    dt.Columns.Add("Loại khách hàng");
                    dt.Columns.Add("Giới tính");
                    dt.Columns.Add("Ngày Thêm");
                    foreach (Customers cus in listcustomer)
                    {
                        DataRow dtr = dt.NewRow();
                        dtr["Mã Số"] = cus.localid;
                        dtr["Họ Tên"] = cus.name;
                        dtr["Số điện Thoại"] = cus.phone;
                        dtr["Năm sinh"] =(DateTime.Now.Year-cus.age).ToString();
                        dtr["Địa chỉ"] = cus.address;
                        dtr["Loại khách hàng"] = cus.Types.name;
                        if(cus.gender==0)
                        {
                            dtr["Giới tính"] = "Nam";
                        }
                        if (cus.gender == 1)
                        {
                            dtr["Giới tính"] = "Nữ";
                        }
                        if (cus.gender == 3)
                        {
                            dtr["Giới tính"] = "Khác";
                        }
                        dtr["Ngày Thêm"] = cus.dayadd.Hour + ":" + cus.dayadd.Minute + "-" + cus.dayadd.Day + "/" + cus.dayadd.Month + "/" + cus.dayadd.Year;
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

        public static DataTable loadCustomer(List<Customers> listcustomer)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mã Số");
                    dt.Columns.Add("Họ Tên");
                    dt.Columns.Add("Ngày Thêm");
                    foreach(Customers cus in listcustomer)
                    {
                        DataRow dtr = dt.NewRow();
                        dtr["Mã Số"] = cus.localid;
                        dtr["Họ Tên"] = cus.name;
                        dtr["Ngày Thêm"] = cus.dayadd.Hour+":"+cus.dayadd.Minute + "-"+cus.dayadd.Day+"/"+cus.dayadd.Month+"/"+cus.dayadd.Year;
                        dt.Rows.Add(dtr);
                    }
                    return dt;

                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
        public static DataTable loadCustomerWithUpdate(List<Customers> listcustomer)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mã Số");
                    dt.Columns.Add("Họ Tên");
                    dt.Columns.Add("Ngày Xóa");
                    foreach (Customers cus in listcustomer)
                    {
                        DataRow dtr = dt.NewRow();
                        dtr["Mã Số"] = cus.localid;
                        dtr["Họ Tên"] = cus.name;
                        dtr["Ngày Xóa"] = cus.dayupdate.Hour + ":" + cus.dayupdate.Minute + "-" + cus.dayupdate.Day + "/" + cus.dayupdate.Month + "/" + cus.dayupdate.Year;
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
        public static bool Recovery(string id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var customer = context.Customers.Where(cus => cus.localid == id).FirstOrDefault();
                    customer.available = true;
                    customer.dayupdate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
        public static DataTable FindByValue(string find)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var find_customer = context.Customers.Where(cus => (cus.localid.Contains(find) || cus.name.Contains(find) || cus.phone.Contains(find)) && cus.available==true).Take(10).ToList();
                    return loadCustomer(find_customer);
                }
                catch (Exception e)
                {
                    return null;
                }               
            }
        }
        public static DataTable FindByValueWithoutWorking(string find)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var working = context.CustomerMachines.Select(o => o.Customers.localid);

                    var find_customer = context.Customers.Where(cus => (cus.localid.Contains(find) || cus.name.Contains(find) || cus.phone.Contains(find)) && working.Contains(cus.localid)==false && cus.available == true).Take(10).ToList();
                    return loadCustomer(find_customer);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public static DataTable loadAddedCustomer()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mã Số");
                    dt.Columns.Add("Họ Tên");
                    dt.Columns.Add("Ngày Thêm");
                    DataRow dtr = dt.NewRow();
                    dtr["Mã Số"] =addedCustomer.localid;
                    dtr["Họ Tên"] = addedCustomer.name;
                    dtr["Ngày Thêm"] = addedCustomer.dayadd.Hour + ":" + addedCustomer.dayadd.Minute + "-" + addedCustomer.dayadd.Day + "/" + addedCustomer.dayadd.Month + "/" + addedCustomer.dayadd.Year;
                    dt.Rows.Add(dtr);
                    return dt;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public static bool RemoveCustomer(string id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var customer = context.Customers.Where(cus => cus.localid == id).FirstOrDefault();
                    customer.available = false;
                    customer.dayupdate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool AddCustomer(string id,string name,string phone,int type,int gender,int age,string address,List<Health> listwithout)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var select_type = context.Types.Where(o => o.typeid == type).FirstOrDefault();
                    var customer = new Customers
                    {
                        localid = id,
                        name = name,
                        phone = phone,
                        Types = select_type,
                        gender = gender,
                        age = age,
                        address = address,
                        available =true,
                        dayadd = DateTime.Now,
                        dayupdate = DateTime.Now
                    };
                    context.Customers.Add(customer);
                   
                    addedCustomer = customer;
                    foreach(Health healt in listwithout)
                    {
                        var selecthealth = context.Healths.Where(o => o.healthid == healt.healthid).FirstOrDefault();
                        var health = new CustomerHealth
                        {
                            Customers = context.Customers.Where(cus => cus.localid == id).FirstOrDefault(),
                            Health = selecthealth,
                            dayadd = DateTime.Now,
                            dayupdate = DateTime.Now
                        };
                        context.CustomerHealths.Add(health);
                       
                    }
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static Customers getinformation(string id)
        {
            using (var context = new ControllerModel())
            {
               return context.Customers.Where(cus => cus.localid == id).Include("Types").FirstOrDefault();
            }
        }
        public static bool UpdateCustomer(string id, string name, string phone, int type, int gender, int age, string address,List<Health> addlist,List<Health> removelist)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var customer = context.Customers.Where(cus => cus.localid == id).FirstOrDefault();
                    var select_type = context.Types.Where(o => o.typeid == type).FirstOrDefault();
                    if (customer != null)
                    {
                        customer.name = name;
                        customer.phone = phone;
                        customer.gender = gender;
                        customer.Types = select_type;
                        customer.age = age;
                        customer.address = address;
                        customer.dayupdate = DateTime.Now;
                    };
                    foreach(Health health in removelist)
                    {
                        var ch= context.CustomerHealths.Where(o => o.Customers.localid == id && o.Health.healthid == health.healthid);
                        if(ch.Count()>0)
                        {
                            context.CustomerHealths.RemoveRange(ch);
                        }
                    }
                    context.SaveChanges();
                    foreach (Health health in addlist)
                    {
                        var ch = context.CustomerHealths.Where(o => o.Customers.localid == id && o.Health.healthid == health.healthid);
                        var heal = context.Healths.Where(o => o.healthid==health.healthid).FirstOrDefault();

                        if (ch.Count() == 0)
                        {
                            var ht = new CustomerHealth
                            {
                                Customers = customer,
                                Health = heal,
                                dayadd = DateTime.Now,
                                dayupdate = DateTime.Now
                            };
                            context.CustomerHealths.Add(ht);
                        }
                    }

                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static List<Health> listHealth(string id)
        {
            using (var context = new ControllerModel())
            {
                return context.CustomerHealths.Where(ch => ch.Customers.localid == id).Select(o => o.Health).ToList();
            }
        }
        public static bool ExportbyExcel(string location)
        {
            try
            {
                DataTable dtb = getExcelListCustomer();
                string name = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second).ToString() + ".xlsx";
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";
                // storing header part in Excel  
                for (int i = 1; i < dtb.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dtb.Columns[i - 1].ColumnName;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    for (int j = 0; j < dtb.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dtb.Rows[i][j].ToString();
                    }
                }
                // save the application  
                workbook.SaveAs(location+@"\"+name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Visible = false;
                app.Quit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
