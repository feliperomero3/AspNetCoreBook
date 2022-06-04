using Microsoft.AspNetCore.Mvc;
using SportsStore.Services;

namespace SportsStore.ViewComponents;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly CartService _cartService;

    public CartSummaryViewComponent(CartService cartService)
    {
        _cartService = cartService;
    }

    public IViewComponentResult Invoke()
    {
        var cartModel = _cartService.GetCart() ?? new();

        return View(cartModel);
    }
}