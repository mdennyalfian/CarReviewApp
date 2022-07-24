using CarReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarCategory>()
                .HasKey(pc => new { pc.CarId, pc.CategoryId });

            modelBuilder.Entity<CarCategory>()
                .HasOne(p => p.Car)
                .WithMany(pc => pc.CarCategories)
                .HasForeignKey(c => c.CarId);

            modelBuilder.Entity<CarCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.CarCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<CarOwner>()
                .HasKey(po => new { po.CarId, po.OwnerId });

            modelBuilder.Entity<CarOwner>()
                .HasOne(p => p.Car)
                .WithMany(po => po.CarOwners)
                .HasForeignKey(c => c.CarId);

            modelBuilder.Entity<CarOwner>()
                .HasOne(p => p.Owner)
                .WithMany(po => po.CarOwners)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
