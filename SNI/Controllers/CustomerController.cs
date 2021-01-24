using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SNI.Models;

namespace SNI.Controllers
{
    class CustomerController
    {
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
        public static DataTable FindByValue(string find)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var find_customer = context.Customers.Where(cus => cus.localid.Contains(find) || cus.name.Contains(find)).Take(10).ToList();
                    return loadCustomer(find_customer);
                }
                catch (Exception e)
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
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool AddCustomer(string id,string name,string phone,int gender,int age,string address)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var customer = new Customers
                    {
                        localid = id,
                        name = name,
                        phone = phone,
                        gender = gender,
                        age = age,
                        address = address,
                        available =true,
                        dayadd = DateTime.Now,
                        dayupdate = DateTime.Now
                    };
                    context.Customers.Add(customer);
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
               return context.Customers.Where(cus => cus.localid == id).FirstOrDefault();
            }
        }
    }
}
