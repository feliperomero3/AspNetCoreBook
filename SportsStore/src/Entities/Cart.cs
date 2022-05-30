﻿namespace SportsStore.Entities;

public class Cart
{
    public long CartId { get; set; }

    public List<CartLine> Lines { get; set; } = new List<CartLine>();

    public decimal TotalValue => Lines.Sum(l => l.Product.Price * l.Quantity);

    public Cart() { }

    public Cart(long cartId, List<CartLine> lines)
    {
        CartId = cartId;
        Lines = lines ?? throw new ArgumentNullException(nameof(lines));
    }

    public void AddItem(Product product, int quantity)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        var line = Lines
            .Where(p => p.Product.ProductId == product.ProductId)
            .FirstOrDefault();

        if (line is null)
        {
            Lines.Add(new CartLine(quantity, product));
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public void RemoveLine(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        var line = Lines.FirstOrDefault(l => l.Product.ProductId == product.ProductId);

        if (line is not null)
        {
            Lines.Remove(line);
        }
    }

    public void Clear() => Lines.Clear();
}
