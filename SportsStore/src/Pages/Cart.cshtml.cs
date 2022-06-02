using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Data;
using SportsStore.Services;

namespace SportsStore.Pages
{
    public class CartModel : PageModel
    {
        private readonly StoreDbContext _dbContext;
        private readonly CartService _cartService;
        private readonly ILogger<CartModel> _logger;

        public CartModel(StoreDbContext dbContext, CartService cartService, ILogger<CartModel> logger)
        {
            _dbContext = dbContext;
            _cartService = cartService;
            _logger = logger;
        }

        public Models.CartModel? Cart { get; set; }

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string? returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            Cart = _cartService.GetCart() ?? new();
        }

        public ActionResult OnPost(long productId, string returnUrl)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product is not null)
            {
                var storedCart = _cartService.GetCart();

                var cart = storedCart?.MapToCart() ?? new();

                cart.AddItem(product, 1);

                Cart = Models.CartModel.MapFromCart(cart);

                _cartService.SetCart(Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
