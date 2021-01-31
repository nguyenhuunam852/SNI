using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class TypesReports
    {
        [Key]
        public int typereportid { get; set; }

        [ForeignKey("Types")]
        public int typeid { get; set; }
        public Types Types { get; set; }

        [ForeignKey("Reports")]
        public int reportid { get; set; }
        public Reports Reports { get; set; }

        public int amounts { get; set; }

        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }

    }
}
