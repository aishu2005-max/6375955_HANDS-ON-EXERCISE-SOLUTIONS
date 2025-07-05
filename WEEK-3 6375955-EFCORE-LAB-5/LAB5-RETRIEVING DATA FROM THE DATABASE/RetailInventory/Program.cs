using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main()
    {
        using var context = new AppDbContext();

        // 1. Retrieve All Products
        Console.WriteLine("=== All Products ===");
        var products = await context.Products!
                                    .Include(p => p.Category)
                                    .ToListAsync();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price} ({p.Category.Name})");
        }

        //  2. Find by ID
        Console.WriteLine("\n=== Find Product by ID ===");
        var product = await context.Products!.FindAsync(1);
        Console.WriteLine($"Found: {product?.Name}");

        //  3. FirstOrDefault with Condition
        Console.WriteLine("\n=== First Expensive Product (> ₹50000) ===");
        var expensive = await context.Products
                                     .FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive: {expensive?.Name}");
    }
}