using System.Collections.Generic;
using RetailInventory.Models;
namespace RetailInventory.Models;


public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public int Stock { get; set; }

    // Foreign key
    public int CategoryId { get; set; }

    // Navigation property
    public Category? Category { get; set; }
}