using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDup.Models
{
    [Table ("data_pribadi_pelanggan", Schema ="public")]
    public class PribadiClass
    {
        [Key]
        public int id_pelanggan { get; set; }
        public string username { get; set; }   
        public string password { get; set; }
        public string no_ktp { get; set; }
        public string nama { get; set; }
        public string no_hp { get; set; } 
        public string email { get; set; }
    }
}