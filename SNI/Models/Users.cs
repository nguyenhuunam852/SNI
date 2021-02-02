using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SNI.Models
{
    class Users
    {
        [Key]
        public int userid { get; set; }

        public string username { get; set; }
        public string password { get; set; }

        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool available { get; set; }

        [ForeignKey("Roles")]
        public int roleid { get; set; }
        public Roles Roles { get; set; }

        public DateTime dayadd { get; set; }
        public DateTime dayupdate { get; set; }
    }
}
