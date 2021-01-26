using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SNI.Models;
namespace SNI
{
    class ControllerModel : DbContext
    {
        public ControllerModel() : base("connect")
        {

        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Machines> Machines { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<CustomerHealth> CustomerHealths { get; set; }
        public DbSet<CustomerMachine> CustomerMachines { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
