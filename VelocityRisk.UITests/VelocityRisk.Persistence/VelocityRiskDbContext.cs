using Microsoft.EntityFrameworkCore;
using System;
using VelocityRisk.Persistence.Models;

namespace VelocityRisk.Persistence
{
    public class VelocityRiskDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<PanelItem> PanelItems { get; set; }

        public VelocityRiskDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=velocityRisk;Trusted_Connection=True;");
        }
    }
}
