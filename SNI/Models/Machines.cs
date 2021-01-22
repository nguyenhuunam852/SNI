using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class Machines
    {
        [Key]
        public int machineid { get; set; }

        public string name { get; set; }
        public int locationx { get; set; }
        public int locationy { get; set; }
        public int status { get; set; }
        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }

    }
}
