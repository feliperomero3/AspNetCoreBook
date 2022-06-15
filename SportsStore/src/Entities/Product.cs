namespace SportsStore.Entities;

public class Product
{
    public long ProductId { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public string Category { get; private set; }

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
