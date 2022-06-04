using System.ComponentModel.DataAnnotations;
using SportsStore.Entities;

namespace SportsStore.Models;

public class CartModel
{
    public long CartId { get; set; }

    public List<CartLineModel> Lines { get; set; } = new List<CartLineModel>();

    [DataType(DataType.Currency)]
    public decimal TotalValue { get; set; }

    public int TotalQuantity { get; set; }

    internal static CartModel MapFromCart(Cart cart)
    {
        if (cart is null)
        {
            throw new ArgumentNullException(nameof(cart));
        }

        return new CartModel
        {
            CartId = cart.CartId,
            Lines = cart.Lines.Select(l => CartLineModel.MapFromCartLine(l)).ToList(),
            TotalValue = cart.TotalValue,
            TotalQuantity = cart.TotalQuantity,
        };
    }

    internal Cart MapToCart()
    {
        return new Cart(CartId, Lines.Select(l => l.MapToCartLine()).ToList());
    }
}