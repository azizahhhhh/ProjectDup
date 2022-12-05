using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDup.Models
{
    [Table ("data_admin", Schema ="public")]
    public class AdminClass
    {
        [Key]
        public int id_admin { get; set; }
        public string nama { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string no_hp { get; set; }
    }
}