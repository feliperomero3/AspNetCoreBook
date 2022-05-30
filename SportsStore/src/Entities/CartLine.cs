namespace SportsStore.Entities;

public class CartLine
{
    public long CartLineId { get; set; }

    public int Quantity { get; set; }

    public Product Product { get; set; }

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
