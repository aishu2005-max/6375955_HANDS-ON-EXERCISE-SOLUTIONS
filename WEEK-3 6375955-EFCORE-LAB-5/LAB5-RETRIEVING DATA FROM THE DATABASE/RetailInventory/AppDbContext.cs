using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

using System.IO;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=RetailInventory.db");
        
    }
}