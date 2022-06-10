using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportsStore.Pages;

public class CompletedModel : PageModel
{
    public string? OrderId { get; private set; }

    public void OnGet(string? orderId)
    {
        OrderId = orderId;
    }
}
