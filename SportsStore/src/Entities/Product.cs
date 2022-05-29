namespace SportsStore.Entities;

public class Product
{
    public long ProductId { get; }

    public string Name { get; }

    public string Description { get; }

    public decimal Price { get; }

    public string Category { get; }

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
