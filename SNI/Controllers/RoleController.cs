using SNI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNI.Controllers
{
    class RoleController
    {
        public static bool checkRole()
        {
            using (var context = new ControllerModel())
            {
               
                int check =  context.Roles.Where(o => o.name == "Admin").Count();
                int check1 = context.Roles.Where(o => o.name == "Staff").Count();

                if (check == 1 && check1 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static Roles getRoleByName(string name)
        {
            using (var context = new ControllerModel())
            {

                return context.Roles.Where(o => o.name == name).First();
            }
        }
        public static bool AddRoles()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var roleadmin = new Roles
                    {
                        name = "Admin",
                        dayadd = DateTime.Now,
                        dayupdate = DateTime.Now
                    };
                    var rolestaff = new Roles
                    {
                        name = "Staff",
                        dayadd = DateTime.Now,
                        dayupdate = DateTime.Now
                    };
                    context.Roles.Add(roleadmin);
                    context.Roles.Add(rolestaff);
                    context.SaveChanges();
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
