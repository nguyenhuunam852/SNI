using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class Customers
    {
        [Key]
        public int customerid { get; set; }

        public string localid { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int gender { get; set; }
        public string address { get; set; } 
        public int age { get; set; }
        public bool available { get; set; }
        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }
    }
}
