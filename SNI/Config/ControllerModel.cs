﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SNI.Models;
namespace SNI
{
    class ControllerModel : DbContext
    {
        public ControllerModel() : base(FileConfig.connect)
        {
            //Database.SetInitializer<ControllerModel>(null);
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Machines> Machines { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<CustomerHealth> CustomerHealths { get; set; }
        public DbSet<CustomerMachine> CustomerMachines { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<StopMachine> StopMachines { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<TypesReports> TypesReports { get; set; }
        public DbSet<Roles> Roles { get; set; }

    }
}
