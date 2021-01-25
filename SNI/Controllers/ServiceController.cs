using SNI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SNI.Controllers
{
    class ServiceController
    {
        public static List<CustomerMachine> getlistworking()
        {
            using (var context = new ControllerModel())
            {
                return context.CustomerMachines.Include("Machines").ToList();
            }
        }
        public static bool startTime(string cusid,int mchid)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var customer = context.Customers.Where(o => o.localid == cusid).FirstOrDefault();
                    var machine = context.Machines.Where(o => o.machineid == mchid).FirstOrDefault();
                    var customermachine = new CustomerMachine
                    {
                        Customers = customer,
                        Machines = machine,
                        workingtime = Config.workingtime,
                        dayadd = DateTime.Now,
                        dayupdate = DateTime.Now
                    };
                    context.CustomerMachines.Add(customermachine);
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
