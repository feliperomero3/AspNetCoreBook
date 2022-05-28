using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;

namespace SportsStore.ViewComponents;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly StoreDbContext _dbContext;

    public NavigationMenuViewComponent(StoreDbContext context)
    {
        _dbContext = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _dbContext.Products
            .Select(p => p.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToArrayAsync();

        return View(categories);
    }
}
