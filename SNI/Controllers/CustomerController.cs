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
        public static bool AddCustomer(string id,string name,string phone,int gender,int age,string address,List<int> listwithout)
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
                   
                    addedCustomer = customer;
                    foreach(int healt in listwithout)
                    {
                        var health = new CustomerHealth
                        {
                            Customers = context.Customers.Where(cus => cus.localid == id).FirstOrDefault(),
                            Health = context.Healths.Where(heal=>heal.healthid==healt).FirstOrDefault(),
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
               return context.Customers.Where(cus => cus.localid == id).FirstOrDefault();
            }
        }
        public static bool UpdateCustomer(string id, string name, string phone, int gender, int age, string address)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var customer = context.Customers.Where(cus => cus.localid == id).FirstOrDefault();
                    if (customer != null)
                    {
                        customer.name = name;
                        customer.phone = phone;
                        customer.gender = gender;
                        customer.age = age;
                        customer.address = address;
                        customer.dayupdate = DateTime.Now;
                    };
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
