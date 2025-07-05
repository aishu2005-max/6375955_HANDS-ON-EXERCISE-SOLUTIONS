using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RetailInventory;
using RetailInventory.Models;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        // Seed initial data
        if (!context.Categories.Any())
        {
            var electronics = new Category { Name = "Electronics" };
            context.Categories.Add(electronics);

            context.Products.Add(new Product
            {
                Name = "Laptop",
                Price = 49999,
                Category = electronics
            });

            context.SaveChanges();
            Console.WriteLine("Sample data added.");
        }

        var products = context.Products.Include(p => p.Category).ToList();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price} - Category: {p.Category?.Name}");
        }
    }
}
