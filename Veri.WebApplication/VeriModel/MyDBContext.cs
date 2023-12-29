using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml;
using Veri.Domain;

namespace Veri.DBContext
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options)
        //: base("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VeriTest;Data Source=(local)")
        //: base("VeriTestConnectionString")
        : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WeekEnd>()
             .ToTable("WeekEnds");
            modelBuilder.Entity<HoliDay>()
             .ToTable("HoliDays");
        }
    }
}