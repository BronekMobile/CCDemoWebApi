using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Entities
{
    public class CCDbContext: DbContext
    {
        public CCDbContext(DbContextOptions<CCDbContext> options): base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Parking> ParkingLots { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
             .Property(u => u.Name)
             .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.RoleId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Location>()
                .Property(r => r.Type)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Location>()
             .Property(r => r.AddressId)
             .IsRequired();

            modelBuilder.Entity<Room>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Parking>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(r => r.City)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Address>()
             .Property(r => r.Street)
             .IsRequired()
             .HasMaxLength(60);

            modelBuilder.Entity<Address>()
             .Property(r => r.PostalCode)
             .IsRequired()
             .HasMaxLength(10);

            modelBuilder.Entity<Address>()
           .Property(r => r.Country)
           .IsRequired()
           .HasMaxLength(10);
        }
    }
}
