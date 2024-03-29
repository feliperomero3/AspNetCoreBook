﻿using System.ComponentModel.DataAnnotations;
using SportsStore.Entities;

namespace SportsStore.Models;

public class CartLineModel
{
    public long CartLineId { get; set; }

    public int Quantity { get; set; }

    public ProductModel Product { get; set; } = new();

    [DataType(DataType.Currency)]
    public decimal TotalValue { get; set; }

    internal static CartLineModel MapFromCartLine(CartLine cartLine)
    {
        if (cartLine is null)
        {
            throw new ArgumentNullException(nameof(cartLine));
        }

        return new CartLineModel
        {
            Quantity = cartLine.Quantity,
            Product = ProductModel.MapFromProduct(cartLine.Product),
            TotalValue = cartLine.TotalValue
        };
    }

    internal CartLine MapToCartLine()
    {
        if (Product is null)
        {
            throw new InvalidOperationException("Models.ProductModel is null");
        }

        return new CartLine(CartLineId, Quantity, Product.MapToProduct());
    }
}