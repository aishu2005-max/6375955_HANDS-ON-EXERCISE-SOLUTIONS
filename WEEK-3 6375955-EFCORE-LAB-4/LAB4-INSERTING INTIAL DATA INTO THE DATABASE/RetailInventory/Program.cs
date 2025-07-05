using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main()
    {
        // Create a database context instance
        using var context = new AppDbContext();

        // Ensure database and tables are created
        await context.Database.EnsureCreatedAsync();

        // Check if data already exists to avoid duplicate insertions
        if (!await context.Products.AnyAsync())
        {
            // Create new categories
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            // Add categories to database
            await context.Categories.AddRangeAsync(electronics, groceries);

            // Create sample products linked to categories
            var product1 = new Product
            {
                Name = "Laptop",
                Price = 75000,
                Category = electronics
            };

            var product2 = new Product
            {
                Name = "Rice Bag",
                Price = 1200,
                Category = groceries
            };

            // Add products to database
            await context.Products.AddRangeAsync(product1, product2);

            // Save changes to database
            await context.SaveChangesAsync();

            Console.WriteLine(" Sample data inserted successfully.");
        }
        else
        {
            Console.WriteLine(" Data already exists. No action taken.");
        }
    }
}
