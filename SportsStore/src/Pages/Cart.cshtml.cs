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

        public Models.CartModel Cart { get; set; } = new();

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

        public ActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart = _cartService.GetCart();

            var lineModel = Cart.Lines.Find(l => l.Product.ProductId == productId);

            if (lineModel is not null)
            {
                var cart = Cart.MapToCart();

                var product = cart.GetItem(productId)!;

                cart.RemoveLine(product);

                Cart = Models.CartModel.MapFromCart(cart);

                _cartService.SetCart(Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
