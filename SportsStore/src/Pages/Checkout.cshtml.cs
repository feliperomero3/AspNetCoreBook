using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Data;
using SportsStore.Models;

namespace SportsStore.Pages;

public class CheckoutModel : PageModel
{
    private readonly StoreDbContext _dbContext;

    public CheckoutModel(StoreDbContext storeDdContext)
    {
        _dbContext = storeDdContext;
    }

    [BindProperty]
    public OrderModel Order { get; set; } = new();

    public void OnGet()
    {
    }
}
