using System;
using System.Collections.Generic;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}

public class ECommerceSearch
{
    private Dictionary<string, List<Product>> _productIndex;

    public ECommerceSearch(List<Product> products)
    {
        _productIndex = new Dictionary<string, List<Product>>();
        BuildIndex(products);
    }

    private void BuildIndex(List<Product> products)
    {
        foreach (var product in products)
        {
            // Index by product name
            string name = product.Name.ToLower();
            if (!_productIndex.ContainsKey(name))
            {
                _productIndex[name] = new List<Product>();
            }
            _productIndex[name].Add(product);

            // Index by description keywords (example)
            string[] keywords = product.Description.ToLower().Split(' ');
            foreach (var keyword in keywords)
            {
                if (!_productIndex.ContainsKey(keyword))
                {
                    _productIndex[keyword] = new List<Product>();
                }
                _productIndex[keyword].Add(product);
            }
        }
    }

    public List<Product> SearchProducts(string query)
    {
        query = query.ToLower();
        if (_productIndex.ContainsKey(query))
        {
            return _productIndex[query];
        }
        return new List<Product>(); // Return empty list if no results
    }

    public static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop with SSD", Price = 1200.00m },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest smartphone with great camera", Price = 800.00m },
            new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling over-ear headphones", Price = 150.00m },
            new Product { Id = 4, Name = "Laptop Bag", Description = "Stylish laptop bag for travel", Price = 50.00m }
        };

        ECommerceSearch search = new ECommerceSearch(products);

        // Example usage:
        List<Product> results = search.SearchProducts("laptop");
        Console.WriteLine("Search results for 'laptop':");
        foreach (var product in results)
        {
            Console.WriteLine($"- {product.Name}: {product.Description}");
        }

        results = search.SearchProducts("camera");
        Console.WriteLine("\nSearch results for 'camera':");
        foreach (var product in results)
        {
            Console.WriteLine($"- {product.Name}: {product.Description}");
        }

        results = search.SearchProducts("headphones");
        Console.WriteLine("\nSearch results for 'headphones':");
        foreach (var product in results)
        {
            Console.WriteLine($"- {product.Name}: {product.Description}");
        }
    }
}
