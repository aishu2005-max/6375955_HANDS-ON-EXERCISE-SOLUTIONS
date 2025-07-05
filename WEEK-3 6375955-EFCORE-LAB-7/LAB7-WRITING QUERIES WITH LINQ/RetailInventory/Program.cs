using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main()
    {
        using var context = new AppDbContext();
        await context.Database.EnsureCreatedAsync();

        Console.WriteLine("=== Filtered & Sorted Products (Price > ₹1000) ===");

        var filtered = await context.Products
            .Where(p => p.Price > 1000)
            .OrderByDescending(p =>(double)p.Price)
            .Include(p => p.Category)
            .ToListAsync();

        foreach (var p in filtered)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price} ({p.Category.Name})");
        }

        Console.WriteLine("\n=== Product DTOs (Name & Price Only) ===");

        var productDTOs = await context.Products
            .Select(p => new ProductDTO { Name = p.Name, Price = p.Price })
            .ToListAsync();

        foreach (var dto in productDTOs)
        {
            Console.WriteLine($"Name: {dto.Name}, Price: ₹{dto.Price}");
        }
    }
}