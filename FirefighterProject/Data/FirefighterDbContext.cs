using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirefighterProject.Model;
using Microsoft.EntityFrameworkCore;

namespace FirefighterProject.Data
{

    public class FirefighterDbContext : DbContext
    {
        public DbSet<Firefighters> Firefighters { get; set; }
        public DbSet<Firetrucks> Firetrucks { get; set; }
        public DbSet<Incidents> Incidents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pc1_16\\source\\repos\\EraX72\\FirefighterProject\\FirefighterProject\\FirefighterDB.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Firefighters>()
                .HasKey(f => f.FirefighterID);

            modelBuilder.Entity<Firetrucks>()
                .HasKey(ft => ft.FiretruckID);

            modelBuilder.Entity<Incidents>()
                .HasKey(i => i.IncidentID);

        }
    }
}
