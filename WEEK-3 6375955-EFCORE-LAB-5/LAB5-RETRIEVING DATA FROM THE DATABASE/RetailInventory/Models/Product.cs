namespace RetailInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}