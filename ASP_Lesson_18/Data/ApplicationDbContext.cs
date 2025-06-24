using ASP_Lesson_18.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<CustomerInterest> CustomerInterests { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerInterest>()
                .HasKey(ci => new { ci.CustomerId, ci.ProductCategoryId });

            modelBuilder.Entity<CustomerInterest>()
                .HasOne(ci => ci.Customer)
                .WithMany(c => c.Interests)
                .HasForeignKey(ci => ci.CustomerId);

            modelBuilder.Entity<CustomerInterest>()
                .HasOne(ci => ci.ProductCategory)
                .WithMany(pc => pc.CustomerInterests)
                .HasForeignKey(ci => ci.ProductCategoryId);

            modelBuilder.Entity<Promotion>()
                .HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Promotions)
                .HasForeignKey(p => p.ProductCategoryId);
        }
    }
}
