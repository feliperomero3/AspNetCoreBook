namespace SportsStore.Entities;

public class CartLine
{
    public long CartLineId { get; set; }

    public int Quantity { get; set; }

    public Product Product { get; set; }

    public decimal TotalValue => Quantity * Product.Price;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Required by EF Core
    private CartLine() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Required by EF Core

    public CartLine(int quantity, Product product)
    {
        Quantity = quantity;
        Product = product ?? throw new ArgumentNullException(nameof(product));
    }

    public CartLine(long cartLineId, int quantity, Product product)
    {
        CartLineId = cartLineId;
        Quantity = quantity;
        Product = product ?? throw new ArgumentNullException(nameof(product));
    }
}
