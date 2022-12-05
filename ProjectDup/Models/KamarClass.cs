using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDup.Models
{
    [Table("data_kamar", Schema = "public")]
    public class KamarClass
    {
        [Key]
        public int id_kamar { get; set; }
        public string nama_kamar { get; set; }
        public string harga { get; set; }
    }
}