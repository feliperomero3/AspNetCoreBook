using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using SportsStore.Data;

namespace SportsStore.ViewComponents;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly StoreDbContext _dbContext;
    private readonly ILogger<NavigationMenuViewComponent> _logger;

    public NavigationMenuViewComponent(StoreDbContext context, ILogger<NavigationMenuViewComponent> logger)
    {
        _dbContext = context;
        _logger = logger;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var category = Request.Query["category"];

        if (category == StringValues.Empty)
        {
            _logger.LogInformation("No Category found in query string.");
        }
        else
        {
            _logger.LogInformation("Category '{category}' found in query string.", category);
        }

        ViewBag.SelectedCategory = category;

        var categories = await _dbContext.Products
            .AsNoTracking()
            .Select(p => p.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToArrayAsync();

        return View(categories);
    }
}
