using RetailInventory;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

using var context = new RetailContext();

// Add sample data (only first time)
if (!context.Categories.Any())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    context.Categories.AddRange(electronics, groceries);

    context.Products.AddRange(
        new Product { Name = "Laptop", Stock = 10, Category = electronics },
        new Product { Name = "TV", Stock = 5, Category = electronics },
        new Product { Name = "Rice", Stock = 100, Category = groceries }
    );

    context.SaveChanges();
    Console.WriteLine("Sample data added.");
}

// Show products
var products = context.Products.Include(p => p.Category).ToList();

foreach (var product in products)
{
    Console.WriteLine($"{product.Name} ({product.Category?.Name}) - Stock: {product.Stock}");
}

