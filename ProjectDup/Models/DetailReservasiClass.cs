using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDup.Models
{
    [Table("detail_reservasi", Schema = "public")]
    public class DetailReservasiClass
    {
        [Key]
        public int id_detail_reservasi { get; set; }
        public string tanggal_check_in { get; set; }
        public string tanggal_check_out { get; set; }
        public string id_reservasi { get; set; }
        public int id_kamar { get; set; }
    }
}