namespace SportsStore.Entities;

public class Product
{
    public long ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; }

    public Product() { }

    public Product(string name, string description, decimal price, string category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

    public Product(long productId, string name, string description, decimal price, string category) : this(name, description, price, category)
    {
        ProductId = productId;
    }
}
