using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Models;
using SportsStore.Services;

namespace SportsStore.Pages;

public class CheckoutModel : PageModel
{
    private readonly StoreDbContext _dbContext;
    private readonly CartService _cartService;
    private readonly ILogger<CheckoutModel> _logger;

    public CheckoutModel(StoreDbContext storeDdContext, CartService cartService, ILogger<CheckoutModel> logger)
    {
        _dbContext = storeDdContext;
        _cartService = cartService;
        _logger = logger;
    }

    [BindProperty]
    public OrderModel Order { get; set; } = new();

    public void OnGet()
    {
    }

    public ActionResult OnPost()
    {
        var cartModel = _cartService.GetCart() ?? new();

        if (cartModel.TotalQuantity == 0)
        {
            ModelState.AddModelError(string.Empty, "Sorry, your cart is empty.");
        }

        if (ModelState.IsValid)
        {
            var cart = cartModel.MapToCart();

            Order.Lines = cart.Lines.Select(CartLineModel.MapFromCartLine).ToList();

            var newOrder = Order.MapToOrder();

            _dbContext.Attach(newOrder);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError(exception, "An error occurred while saving the order.");

                throw;
            }

            cart.Clear();

            _cartService.RemoveCart();

            return RedirectToPage("Completed", new { orderId = newOrder.OrderId });
        }

        return RedirectToPage();
    }
}
