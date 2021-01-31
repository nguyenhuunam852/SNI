using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class Reports
    {
        [Key]
        public int reportid { get; set; }

        public int amountofactivecustomer { get; set; }
        public int amountofnewcustomer { get; set; }
        public bool serverreport { get; set; }

        public DateTime datereport { get; set; }
        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }
    }
}
