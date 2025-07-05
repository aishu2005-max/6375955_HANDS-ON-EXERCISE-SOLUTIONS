using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main()
    {
        using var context = new AppDbContext();

        Console.WriteLine("=== Updating Laptop Price ===");
        var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
        if (product != null)
        {
            product.Price = 70000;
            await context.SaveChangesAsync();
            Console.WriteLine("✅ Laptop price updated to ₹70000.");
        }
        else
        {
            Console.WriteLine(" Laptop not found.");
        }

        Console.WriteLine("\n=== Deleting Rice Bag ===");
        var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
        if (toDelete != null)
        {
            context.Products.Remove(toDelete);
            await context.SaveChangesAsync();
            Console.WriteLine("✅ Rice Bag deleted.");
        }
        else
        {
            Console.WriteLine(" Rice Bag not found.");
        }

        Console.WriteLine("\n=== Final Products ===");
        var products = await context.Products.ToListAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price}");
        }
    }
}