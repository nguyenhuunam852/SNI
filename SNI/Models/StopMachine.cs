using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class StopMachine
    {
        [Key]
        public int stopmachineid { get; set; }

        [ForeignKey("CustomerMachine")]
        public int customermachineid { get; set; }
        public CustomerMachine CustomerMachine { get; set; }

        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }


    }
}
