namespace SportsStore.Entities;

public class Product
{
    public long ProductId { get; }

    public string Name { get; } = string.Empty;

    public string Description { get; } = string.Empty;

    public decimal Price { get; }

    public string Category { get; } = string.Empty;

    public Product(string name, string description, decimal price, string category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }
}
