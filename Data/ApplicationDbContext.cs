using Microsoft.EntityFrameworkCore;
using ColdStorageManagement.Models;

namespace ColdStorageManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ColdRoom> ColdRooms { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Cold Rooms
            modelBuilder.Entity<ColdRoom>().HasData(
                new ColdRoom
                {
                    Id = 1,
                    Name = "Frozen Storage (-18°C)",
                    Type = "Frozen",
                    Temperature = -18,
                    Capacity = 5000,
                    AvailableCapacity = 5000,
                    PricePerKgPerDay = 10,
                    IsAvailable = true
                },
                new ColdRoom
                {
                    Id = 2,
                    Name = "Chilled Storage (4°C)",
                    Type = "Chilled",
                    Temperature = 4,
                    Capacity = 3000,
                    AvailableCapacity = 3000,
                    PricePerKgPerDay = 6,
                    IsAvailable = true
                },
                new ColdRoom
                {
                    Id = 3,
                    Name = "Ambient Storage (20°C)",
                    Type = "Ambient",
                    Temperature = 20,
                    Capacity = 8000,
                    AvailableCapacity = 8000,
                    PricePerKgPerDay = 4,
                    IsAvailable = true
                }
            );
        }
    }
}