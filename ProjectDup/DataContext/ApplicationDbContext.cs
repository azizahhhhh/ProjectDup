using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectDup.Models;

namespace ProjectDup.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base(nameOrConnectionString: "Myconnection")
        {

        }
        public virtual DbSet<PribadiClass> PribadiObj { get; set; }
        public virtual DbSet<AdminClass> AdminObj { get; set; }
        public virtual DbSet<KamarClass> KamarObj { get; set; } 
        public virtual DbSet<ReservasiClass> ReservasiClasses { get; set; }
        public virtual DbSet<DetailReservasiClass> DetailReservasiClasses { get; set; } 
    }
}