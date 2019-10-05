using Microsoft.EntityFrameworkCore;
using Products.Domain.Models;

namespace Products.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Products", schema: "products-schema");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Product>().Property(p => p.Cost).IsRequired();
        }
    }
}