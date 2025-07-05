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

        if (!context.Categories.Any())
        {
            var electronics = new Category { Name = "Electronics" };
            context.Categories.Add(electronics);
            context.Products.Add(new Product
            {
                Name = "Laptop",
                Price = 45000,
                Category = electronics
            });
            context.SaveChanges();
        }

        var products = context.Products.Include(p => p.Category).ToList();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price} - Category: {p.Category?.Name}");
        }
    }
}
