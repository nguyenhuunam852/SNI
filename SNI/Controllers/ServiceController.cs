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
                        workingtime = FileConfig.config.workingtime,
                        activedtime = 0,
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
        public static bool StopWorkingMachine(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var machine = context.CustomerMachines.Where(o => o.machineid == id).FirstOrDefault();

                    machine.dayupdate = DateTime.Now;
                    var stop = new StopMachine
                    {
                        CustomerMachine = machine,
                        dayadd = DateTime.Now,
                        dayupdate = DateTime.Now
                    };
                    context.StopMachines.Add(stop);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static CustomerMachine getCustomerMachinebyStopMachineid(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {

                    return context.StopMachines.Where(o => o.stopmachineid == id).Include("CustomerMachine").FirstOrDefault().CustomerMachine;
                }
                catch
                {
                    return null;
                }
            }
        }
        public static StopMachine getStopMachinebyMachineid(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    return context.StopMachines.Include("CustomerMachine").Where(o => o.CustomerMachine.machineid == id).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }
        public static List<int> GetAllStopWorkingMachine()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    return context.StopMachines.Include("CustomerMachine").Select(o => o.CustomerMachine.machineid).ToList();

                }
                catch
                {
                    return null;
                }
            }
        }
        public static bool ActiveWorkingMachine(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var machine = context.StopMachines.Include("CustomerMachine").Where(o => o.CustomerMachine.machineid == id).FirstOrDefault();
                    var machine1 = context.CustomerMachines.Where(o => o.machineid == id).FirstOrDefault();

                    int shour =  DateTime.Now.Hour- machine.dayadd.Hour;
                    int sminute = DateTime.Now.Minute - machine.dayadd.Minute;
                    int ssecond = DateTime.Now.Second - machine.dayadd.Second;

                    machine1.activedtime = machine1.activedtime+shour * 3600 + sminute * 60 + ssecond;
                    machine1.dayupdate = DateTime.Now;
                    context.StopMachines.Remove(machine);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool ChangeMachine(int oldmachine,int newmachine)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var cm = context.CustomerMachines.Where(o => o.machineid == oldmachine).FirstOrDefault();
                    var machine = context.Machines.Where(o => o.machineid == newmachine).FirstOrDefault();
                    cm.Machines = machine;
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static int checkCustomerActive(string id)
        {
            using (var context = new ControllerModel())
            {
                return context.Histories.Include("Customers").Where(o => o.Customers.localid == id 
                && o.dayadd.Year == DateTime.Now.Year
                && o.dayadd.Day == DateTime.Now.Day
                && o.dayadd.Month == DateTime.Now.Month).Count();
            }
        }
    }
}
