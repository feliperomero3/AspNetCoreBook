using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Models;

namespace SportsStore.Pages;

public class IndexModel : PageModel
{
    private readonly StoreDbContext _dbContext;

    public IndexModel(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<ProductModel> Products { get; private set; } = Enumerable.Empty<ProductModel>();

    public string CurrentCategory { get; set; } = string.Empty;

    public void OnGet(string category)
    {
        var products = _dbContext.Products
            .AsNoTracking()
            .Where(p => string.IsNullOrEmpty(category) || string.Equals(p.Category.ToLower(), category.ToLower()))
            .ToArray();

        Products = products.Select(p => ProductModel.MapFromProduct(p));
    }
}
