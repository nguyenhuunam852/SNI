using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class CustomerHealth
    {
        [Key]
        public int customerhealthid { get; set; }

        [ForeignKey("Health")]
        public int healthid { get; set; }
        public Health Health { get; set; }

        [ForeignKey("Customers")]
        public int customerid { get; set; }
        public Customers Customers { get; set; }

        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }
    }
}
