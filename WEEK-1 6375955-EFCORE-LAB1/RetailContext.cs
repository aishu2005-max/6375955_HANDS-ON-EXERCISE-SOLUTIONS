
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory;

public class RetailContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=retail.db;");
    }
}