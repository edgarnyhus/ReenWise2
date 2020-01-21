using System;
using System.Linq;
using System.Reflection;
using ReenWise.Domain.Models.Mirror;
using Microsoft.EntityFrameworkCore;

namespace ReenWise.Infrastructure.Data.Context
{
    public class ReenWiseDbContext : DbContext
    {
        public ReenWiseDbContext(DbContextOptions options) : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<LicensePlate> LicensePlates { get; set; }
        //public DbSet<GeoLocation> Locations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<OdoMeter> OdoMeters { get; set; }
        public DbSet<OperatingHours> OperatingHours { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>()
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(32)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(p => p.Email)
                .HasMaxLength(32);

            //modelBuilder.Entity<Driver>()
            //    .HasOne(p => p.Organization)
            //    .WithMany(b => b.Drivers)
            //    .HasForeignKey(p => p.OrganizationId);

            //modelBuilder.Entity<Driver>()
            //    .HasMany(p => p.Vehicles)
            //    .WithOne(b => b.Driver);

            modelBuilder.Entity<Equipment>()
                .Property(p => p.Alias)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Equipment>()
                .Property(p => p.SerialNumber)
                .HasMaxLength(32);

            modelBuilder.Entity<Equipment>()
                .Property(p => p.Notes)
                .HasMaxLength(1024);

            //modelBuilder.Entity<Equipment>()
            //    .HasOne(p => p.Model)
            //    .WithMany()
            //    .HasForeignKey(p => p.ModelId);

            //modelBuilder.Entity<Equipment>()
            //    .HasMany(p => p.Locations)
            //    .WithOne();

            //modelBuilder.Entity<Equipment>()
            //    .HasMany(p => p.Temperatures)
            //    .WithOne();

            //modelBuilder.Entity<Equipment>()
            //    .HasOne(p => p.Organization)
            //    .WithMany(b => b.Equipment)
            //    .HasForeignKey(p => p.OrganizationId);

            //modelBuilder.Entity<Equipment>()
            //    .HasOne(p => p.OperatingHours)
            //    .WithMany()
            //    .HasForeignKey(p => p.OperatingHoursId);

            //modelBuilder.Entity<Equipment>()
            //    .HasOne(p => p.InitialOperatingHours)
            //    .WithMany()
            //    .HasForeignKey(p => p.InitialOperatingHoursId);

            //modelBuilder.Entity<Equipment>()
            //    .HasOne(p => p.Unit)
            //    .WithMany()
            //    .HasForeignKey(p => p.UnitId);

            modelBuilder.Entity<LicensePlate>()
                .Property(p => p.Number)
                .HasMaxLength(8)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(p => p.Latitude)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(p => p.Longitude)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(p => p.InMovement)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(p => p.Timestamp)
                .IsRequired();

            modelBuilder.Entity<Manufacturer>()
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            //modelBuilder.Entity<Manufacturer>()
            //    .HasMany(p => p.Equipment)
            //    .WithOne();

            //modelBuilder.Entity<Manufacturer>()
            //    .HasMany(p => p.Vehicles)
            //    .WithOne();

            //modelBuilder.Entity<Manufacturer>()
            //    .HasMany(p => p.Models)
            //    .WithOne();

            modelBuilder.Entity<Model>()
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Model>()
                .Property(p => p.SerialNumber)
                .HasMaxLength(32);

            modelBuilder.Entity<Model>()
                .Property(p => p.Description)
                .HasMaxLength(512);

            modelBuilder.Entity<Model>()
                .Property(p => p.Attachment)
                .HasMaxLength(256);

            //modelBuilder.Entity<Model>()
            //    .HasOne(p => p.Manufacturer)
            //    .WithMany()
            //    .HasForeignKey(p => p.ManufacturerId);

            modelBuilder.Entity<OdoMeter>()
                .Property(p => p.Value)
                .IsRequired();

            modelBuilder.Entity<OdoMeter>()
                .Property(p => p.Timestamp)
                .IsRequired();

            modelBuilder.Entity<OperatingHours>()
                .Property(p => p.Hours)
                .IsRequired();

            modelBuilder.Entity<OperatingHours>()
                .Property(p => p.UnitDriven)
                .IsRequired();

            modelBuilder.Entity<Organization>()
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Temperature>()
                .Property(p => p.Value)
                .IsRequired();

            modelBuilder.Entity<Temperature>()
                .Property(p => p.Timestamp)
                .IsRequired();

            modelBuilder.Entity<Unit>()
                .Property(p => p.SerialNumber)
                .HasMaxLength(32);

            modelBuilder.Entity<Unit>()
                .Property(p => p.Type)
                .HasMaxLength(32);

            modelBuilder.Entity<Unit>()
                .Property(p => p.SerialNumber)
                .HasMaxLength(32);

            modelBuilder.Entity<Unit>()
                .Property(p => p.Health)
                .HasMaxLength(32);

            modelBuilder.Entity<Unit>()
                .Property(p => p.Status)
                .HasMaxLength(32);

            modelBuilder.Entity<Vehicle>()
                .Property(p => p.Alias)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(p => p.CommercialClass)
                .HasMaxLength(32);

            modelBuilder.Entity<Vehicle>()
                .Property(p => p.Notes)
                .HasMaxLength(1024);

            modelBuilder.Entity<Vehicle>()
                .Property(p => p.FuelType)
                .HasMaxLength(32);

            modelBuilder.Entity<Vehicle>()
                .Property(p => p.Color)
                .HasMaxLength(32);

            //modelBuilder.Entity<Vehicle>()
            //    .HasOne(p => p.Model)
            //    .WithMany()
            //    .HasForeignKey(p => p.ModelId);

            //modelBuilder.Entity<Vehicle>()
            //    .HasOne(p => p.LicensePlate)
            //    .WithMany()
            //    .HasForeignKey(p => p.LicensePlateId);

            //modelBuilder.Entity<Vehicle>()
            //    .HasOne(p => p.Unit)
            //    .WithMany()
            //    .HasForeignKey(p => p.UnitId);

            //modelBuilder.Entity<Vehicle>()
            //    .HasOne(p => p.Driver)
            //    .WithMany()
            //    .HasForeignKey(p => p.DriverId);

            //modelBuilder.Entity<Vehicle>()
            //    .HasOne(p => p.Organization)
            //    .WithMany(b => b.Vehicles)
            //    .HasForeignKey(p => p.OrganizationId);

            //modelBuilder.Entity<Vehicle>()
            //    .HasOne(p => p.OdoMeter)
            //    .WithMany()
            //    .HasForeignKey(p => p.OdoMeterId);
            
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //using (var db = new ReenWiseDbContext())
            //{
            //    if (!db.Equipment.Any())
            //    {
            //        // The table is empty
            //    }
            //}
            //modelBuilder.Entity<Model>().HasData(
            //    new Model {Id = Guid.NewGuid(), Name = "DAJLJA C-05L-L", SerialNumber = "MUM030887", Description = "B3"},
            //    new Model {Id = Guid.NewGuid(), Name = "EAARST C-10L", SerialNumber = "MUM030467", Description = "C Estetisk stygg"},
            //    new Model {Id = Guid.NewGuid(), Name = "EABXEL C-10L", SerialNumber = "MUM030764", Description = "C Estetisk stygg"},
            //    new Model {Id = Guid.NewGuid(), Name = "EACHRX C-08CL", SerialNumber = "MUM030719", Description = "B Estetisk stygg"},
            //    new Model {Id = Guid.NewGuid(), Name = "EADRBA C-08CL", SerialNumber = "MUM030746", Description = "B Estetisk stygg"},
            //    new Model {Id = Guid.NewGuid(), Name = "EAEATJ C-22K", SerialNumber = "MUM029340", Description = "B Fin"},
            //    new Model {Id = Guid.NewGuid(), Name = "EAGUUU C-08CL", SerialNumber = "MUM030683", Description = "A Fin"},
            //    new Model {Id = Guid.NewGuid(), Name = "EAHBYT C-10CL", SerialNumber = "MUM030741", Description = "C Estetisk stygg"},
            //    new Model {Id = Guid.NewGuid(), Name = "EAJFGU C-10LL", SerialNumber = "MUM029330", Description = "A Fin"},
            //    new Model {Id = Guid.NewGuid(), Name = "EAKNKF C-10CL", SerialNumber = "MUM030743", Description = "C Estetisk stygg"},
            //    new Model {Id = Guid.NewGuid(), Name = "EALUNJ C-10L", SerialNumber = "MUM030509", Description = "C Estetisk stygg"},
            //    new Model {Id = Guid.NewGuid(), Name = "EANVZX C-22K", SerialNumber = "MUM030724", Description = "C Estetisk stygg"}
            //);

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer {Id = Guid.NewGuid(), Name = "Nordcon AS"},
                new Manufacturer {Id = Guid.NewGuid(), Name = "BNS Container AS"
                }
            );
            modelBuilder.Entity<Organization>().HasData(
                new Organization {Id = Guid.NewGuid(), Name = "Norsk Gjenvinning AS"},
                new Organization {Id = Guid.NewGuid(), Name = "SmartContainer AS"}
            );
        }
    }

}
