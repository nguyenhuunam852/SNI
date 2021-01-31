using SNI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNI.Controllers
{
    class ReportController
    {
        public static bool AddnewReport(DateTime dt)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var check = context.Reports.Where(o => o.datereport.Day == dt.Day
                    && o.datereport.Month == dt.Month
                    && o.datereport.Year == dt.Year).Count();
                    if (check == 0)
                    {
                        var amountofcustomers = context.Histories.Include("Customers").Where(o => o.dayadd.Day == dt.Day
                        && o.dayadd.Month == dt.Month
                        && o.dayadd.Year == dt.Year
                        ).Select(o => o.Customers).Distinct().ToList();

                        var newCustomer = context.Customers.Where(o => o.dayadd.Day == dt.Day
                        && o.dayadd.Month == dt.Month
                        && o.dayadd.Year == dt.Year && o.available == true).Count();

                        var report = new Reports
                        {
                            amountofactivecustomer = amountofcustomers.Count(),
                            amountofnewcustomer = newCustomer,
                            serverreport = false,
                            datereport = dt,
                            dayadd = DateTime.Now,
                            dayupdate = DateTime.Now
                        };

                        context.Reports.Add(report);

                        var listtype = TypeController.getList();
                        foreach(Types ty in listtype)
                        {
                            int count = 0;
                            var test = amountofcustomers.Where(o => o.typeid == ty.typeid);
                            if(test!=null)
                            {
                                count = test.Count();
                                var tr = new SNI.Models.TypesReports
                                {
                                    Types = ty,
                                    Reports = report,
                                    amounts = count,
                                    dayadd = DateTime.Now,
                                    dayupdate = DateTime.Now
                                };
                                context.TypesReports.Add(tr);
                            }
                        }
                        context.SaveChanges();

                    }
                    
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
