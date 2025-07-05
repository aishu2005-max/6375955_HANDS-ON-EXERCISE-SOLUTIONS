using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use LocalDB (SQL Server Express)
            optionsBuilder.UseSqlite("Data Source=retail.db");
        }
    }
}