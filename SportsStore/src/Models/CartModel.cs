using System.ComponentModel.DataAnnotations;
using SportsStore.Entities;

namespace SportsStore.Models;

public class CartModel
{
    public long CartId { get; set; }

    public List<CartLineModel>? Lines { get; set; }

    [DataType(DataType.Currency)]
    public decimal TotalValue { get; set; }

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
            TotalValue = cart.TotalValue
        };
    }

    internal Cart MapToCart()
    {
        if (Lines is null)
        {
            throw new InvalidOperationException("Models.CarModel.Lines is null");
        }

        return new Cart(CartId, Lines.Select(l => l.MapToCartLine()).ToList());
    }
}