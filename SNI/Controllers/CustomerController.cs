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
        public static List<Customers> loadCustomer()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mã Số");
                    dt.Columns.Add("Họ Tên");
                    dt.Columns.Add("Ngày Thêm");
                    var listcustomer = context.Customers.Where(cus => cus.available == true).OrderBy(cus => cus.dayadd).Take(10).ToList();
                    foreach(Customers cus in listcustomer)
                    {

                    }
                    return listcustomer;

                }
                catch(Exception ex)
                {
                    return null;
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

                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
