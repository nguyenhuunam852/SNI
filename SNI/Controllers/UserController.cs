using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNI.Models;
namespace SNI.Controllers
{
    class UserController
    {
        public static bool AddAdminUser(string username,string password,string name,string email,string phone)
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
                        Roles = context.Roles.Where(o=>o.name == "Admin").First(),
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
    }
}
