using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Data;
using SportsStore.Infrastructure;

namespace SportsStore.Pages
{
    public class CartModel : PageModel
    {
        private readonly StoreDbContext _dbContext;
        private readonly ILogger<CartModel> _logger;

        public CartModel(StoreDbContext dbContext, ILogger<CartModel> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Models.CartModel Cart { get; set; } = new();

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string? returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            var storedCart = HttpContext.Session.GetJson<Models.CartModel>("cart");

            if (storedCart is not null)
            {
                Cart = storedCart;
            }
        }

        public ActionResult OnPost(long productId, string returnUrl)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product is not null)
            {
                var storedCart = HttpContext.Session.GetJson<Models.CartModel>("cart");

                var cart = storedCart?.MapToCart() ?? new();

                cart.AddItem(product, 1);

                Cart = Models.CartModel.MapFromCart(cart);

                HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
