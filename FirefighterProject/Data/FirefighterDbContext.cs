using System;
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
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fiveb\source\repos\EraX72\FirefighterProject\FirefighterProject\FirefighterDB.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firefighters>(entity =>
            {
                entity.HasKey(f => f.FirefighterID);
                entity.Property(f => f.Username).IsRequired().HasMaxLength(255);
                entity.Property(f => f.Password).IsRequired().HasMaxLength(255);
                entity.HasOne(f => f.Firetrucks)
                      .WithMany(ft => ft.Firefighters)
                      .HasForeignKey(f => f.FiretruckID);
            });

            modelBuilder.Entity<Firetrucks>(entity =>
            {
                entity.HasKey(ft => ft.FiretruckID);
                entity.Property(ft => ft.IsMondayShift).IsRequired();
                entity.Property(ft => ft.IsTuesdayShift).IsRequired();
                entity.Property(ft => ft.IsWednesdayShift).IsRequired();
                entity.Property(ft => ft.IsThursdayShift).IsRequired();
                entity.Property(ft => ft.IsFridayShift).IsRequired();
                entity.Property(ft => ft.IsSaturdayShift).IsRequired();
                entity.Property(ft => ft.IsSundayShift).IsRequired();
            });

            modelBuilder.Entity<Incidents>(entity =>
            {
                entity.HasKey(i => i.IncidentID);
                entity.Property(i => i.Date).IsRequired();
                entity.Property(i => i.Duration).IsRequired();
                entity.Property(i => i.WaterUsed).IsRequired().HasColumnType("decimal(10, 2)");
                entity.HasOne(i => i.Firetruck)
                      .WithMany(ft => ft.Incidents)
                      .HasForeignKey(i => i.FiretruckID);
            });
        }
    }
}
