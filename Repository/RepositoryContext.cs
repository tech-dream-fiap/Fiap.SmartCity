using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public sealed class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Device { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().ToTable("Device");
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<User>()
                .HasOne(x => x.Region)
                .WithMany(x => x.Users)
                .HasForeignKey("RegionId");

            modelBuilder.Entity<Device>()
                .HasOne(x => x.Region)
                .WithMany(x => x.Devices)
                .HasForeignKey("RegionId");
        }
    }
}