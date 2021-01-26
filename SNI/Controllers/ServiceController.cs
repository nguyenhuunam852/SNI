using SNI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public static Customers getcustomerinfbymachine(int id)
        {
            using (var context = new ControllerModel())
            {
                return context.CustomerMachines.Where(o => o.Machines.machineid == id).Include("Customers").FirstOrDefault().Customers;
            }
        }
        public static CustomerMachine getInformation(int machineid,string customerid)
        {
            using (var context = new ControllerModel())
            {
                return context.CustomerMachines.Where(o => o.Machines.machineid == machineid && o.Customers.localid == customerid).FirstOrDefault();
            }

        }
        public static bool FinishWork(string cusid, int mchid,int cm,DateTime date,int activetime)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    context.CustomerMachines.Remove(context.CustomerMachines.Where(o => o.customermachineid == cm).FirstOrDefault());
                    var customer = context.Customers.Where(o => o.localid == cusid).FirstOrDefault();
                    var machine = context.Machines.Where(o => o.machineid == mchid).FirstOrDefault();
                    var history = new History
                    {
                        Customers = customer,
                        Machines = machine,
                        activetime = activetime,
                        daystart = date,
                        dayadd = DateTime.Now,
                        dayupdate = DateTime.Now
                    };
                    context.Histories.Add(history);
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
