
using SNI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SNI.Controllers
{
    class MachineController
    {
        public static List<Machines> tempmachine ;
        public static List<Machines> removemachine ;
        public static bool StopWorkingMachine(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var machine = context.CustomerMachines.Where(o => o.machineid == id).FirstOrDefault();
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
                 
                    return context.StopMachines.Where(o=>o.stopmachineid==id).Include("CustomerMachine").FirstOrDefault().CustomerMachine;
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
                    return context.StopMachines.Include("CustomerMachine").Select(o=>o.CustomerMachine.machineid).ToList();
                    
                }
                catch
                {
                    return null;
                }
            }
        }

        public static bool SaveAllMachine()
        {
            try
            {
                foreach (Machines mch in tempmachine)
                {
                    AddnewMachine(mch.machineid,mch.name, mch.locationx, mch.locationy, mch.status);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool RemoveAllMachine()
        {
            try
            {
                foreach (Machines mch in removemachine)
                {
                    RemoveMachine(mch.name);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool RemoveMachine(string nm)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var machine = context.Machines.Where(mch => mch.name.Trim() == nm.Trim()).FirstOrDefault();
                    machine.status = 3;
                    machine.dayupdate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
        public static bool AddnewMachine(int id,string name,int locationx,int locationy,int status)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    if(id<=0)
                    { 
                        var machine = new Machines
                        {
                            name = name,
                            locationx = locationx,
                            locationy = locationy,
                            status = status,
                            dayadd = DateTime.Now,
                            dayupdate = DateTime.Now
                        };
                        context.Machines.Add(machine);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        var getmachine = context.Machines.Where(machine => machine.machineid == id ).FirstOrDefault();
                        getmachine.name = name;
                        getmachine.locationx = locationx;
                        getmachine.locationy = locationy;
                        getmachine.status = status;
                        context.SaveChanges();
                        return true;
                    }

                }
                catch(Exception e)
                {
                    return false;
                }
            }
            
        }
        public static bool AddnewMachineTemp(string name, int locationx, int locationy, int status)
        {
            var machine1 = tempmachine.Find(mch => mch.name == name);
            if (machine1 == null)
            {
                var machine = new Machines
                {
                    name = name,
                    locationx = locationx,
                    locationy = locationy,
                    status = status,
                    dayadd = DateTime.Now,
                    dayupdate = DateTime.Now
                };
                tempmachine.Add(machine);

                return true;
            }
            return false;

        }

        internal static bool ActiveWorkingMachine(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var machine = context.StopMachines.Include("CustomerMachine").Where(o => o.CustomerMachine.machineid == id).FirstOrDefault();
                   
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

        public static bool loadMachine()
        {
            try
            {
                using (var context = new ControllerModel())
                {
                    IQueryable<Machines> iqm = from temp in context.Machines select temp;
                    tempmachine = iqm.ToList();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        public static Machines getinfor(int idmachine)
        {
            using (var context = new ControllerModel())
            {
                var mch = tempmachine.Where(machine => machine.machineid == idmachine ).FirstOrDefault();
                return mch;   
            }
        }
        public static bool updateMachine(int id,string newname,int status,int locationx,int locationy)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var machine = tempmachine.Where(mch => mch.machineid == id).FirstOrDefault();
                    machine.name = newname;
                    machine.status = status;
                    machine.locationx = locationx;
                    machine.locationy = locationy;
                    machine.dayupdate = DateTime.Now;
                   
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
        public static List<Machines> getListRemovedMachine()
        {
            using (var context = new ControllerModel())
            {
                return context.Machines.Where(machine => machine.status == 3).ToList();
            }
        }
        public static bool Recovery(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var machine = tempmachine.Where(mch => mch.machineid == id).FirstOrDefault();
                    machine.status = 1;
                    return true;
                }
                catch(Exception x)
                {
                    return false;
                }
            }
           
        }
        public static bool RecoveryTemp(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var machine = removemachine.Where(mch => mch.machineid == id).FirstOrDefault();
                    removemachine.Remove(machine);
                    tempmachine.Add(machine);
                    return true;
                }
                catch (Exception x)
                {
                    return false;
                }
            }
        }
        public static bool RepairedMachine(Machines mc)
        {
            mc.status = 0;
            return true;
        }
        public static bool NotRepairedMachine(Machines mc)
        {
            mc.status = 1;
            return true;
        }

    }
}
