using SportsStore.Infrastructure;
using SportsStore.Models;

namespace SportsStore.Services;

public class CartService
{
    private const string _sessionKey = "cart";
    private readonly IHttpContextAccessor _contextAccesor;

    public CartService(IHttpContextAccessor httpContext)
    {
        _contextAccesor = httpContext ?? throw new InvalidOperationException("HttpContext is null.");
    }

    public CartModel GetCart()
    {
        return _contextAccesor.HttpContext?.Session.GetJson<CartModel>(_sessionKey) ?? new();
    }

    public void SetCart(CartModel cart)
    {
        _contextAccesor.HttpContext?.Session.SetJson(_sessionKey, cart);
    }

    public void RemoveCart()
    {
        _contextAccesor.HttpContext?.Session.Remove(_sessionKey);
    }
}
