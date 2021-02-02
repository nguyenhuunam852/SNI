using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SNI.Models;
namespace SNI.Controllers
{
    class UserController
    {
        public static Users current;
        public static bool AddUser(string username,string password,string name,string email,string phone,string role)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var User = new Users
                    {
                        username = username,
                        password = password,
                        name = name,
                        email = email,
                        phone = phone,
                        available = true,
                        Roles = context.Roles.Where(o=>o.name == role).First(),
                        dayadd = DateTime.Now,
                        dayupdate = DateTime.Now
                    };
                    context.Users.Add(User);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
        public static DataTable getListUSer()
        {
            using (var context = new ControllerModel())
            {
                var lsit = context.Users.Include("Roles").Where(o => o.Roles.name == "Staff");
                DataTable dtb = new DataTable();
                dtb.Columns.Add("id");
                dtb.Columns.Add("Name");
                dtb.Columns.Add("Ngày thêm");

                foreach(Users us in lsit)
                {
                    DataRow dtr = dtb.NewRow();
                    dtr["id"] = us.userid;
                    dtr["Name"] = us.name;
                    dtr["Ngày thêm"] = us.dayadd.ToString();
                    dtb.Rows.Add(dtr);
                }
                return dtb;
            }
        }
        public static Users getinformation(int id)
        {
            using (var context = new ControllerModel())
            {
               
                return context.Users.Where(o=>o.userid == id).FirstOrDefault();
            }
        }
        public static bool Login(string username, string password)
        {
            using (var context = new ControllerModel())
            {
                if(context.Users.ToList().Exists(o => o.username == username && o.password == password))
                {
                    current = context.Users.Include("Roles").Where(o => o.username == username && o.password == password).FirstOrDefault();
                    return true;
                }
                return false;
            }
        }

    }
}
