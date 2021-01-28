using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class CustomerMachine
    {
        [Key]
        public int customermachineid { get; set; }

        [ForeignKey("Machines")]
        public int machineid { get; set; }
        public Machines Machines { get; set; }

        [ForeignKey("Customers")]
        public int customerid { get; set; }
        public Customers Customers { get; set; }


        public int activedtime { get; set; }
        public int workingtime { get; set; }

        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }
    }
}
