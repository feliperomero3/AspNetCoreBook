namespace SportsStore.Entities;

public class CartLine
{
    public long CartLineId { get; set; }

    public int Quantity { get; set; }

    public Product Product { get; set; }

    protected CartLine() { }

    public CartLine(Product product, int quantity)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));
        Quantity = quantity;
    }
}
