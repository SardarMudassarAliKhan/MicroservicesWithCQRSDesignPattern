using MicroservicesWithCQRSDesignPattern.Model;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesWithCQRSDesignPattern.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Entity>().HasKey(e => e.Id);
        }
    }
}
