using System.ComponentModel.DataAnnotations;
using SportsStore.Entities;

namespace SportsStore.Models;

public class ProductModel
{
    public long ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    public string Category { get; set; } = string.Empty;

    public static ProductModel MapFromProduct(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        return new ProductModel
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
        };
    }

    internal Product MapToProduct()
    {
        return new Product(ProductId, Name, Description, Price, Category);
    }
}