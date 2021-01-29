using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class Types
    {
        [Key]
        public int typeid { get; set; }

        public string name { get; set; }
        public bool available { get; set; }
        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }
    }
}
