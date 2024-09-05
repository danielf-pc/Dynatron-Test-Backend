using Customer_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Customer>()
                .Property(c => c.UpdateAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
