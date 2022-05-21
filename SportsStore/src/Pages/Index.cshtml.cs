using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Entities;

namespace SportsStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StoreDbContext _dbContext;

        public IndexModel(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> Products { get; private set; } = Enumerable.Empty<Product>();

        public void OnGet()
        {
            Products = _dbContext.Products.AsNoTracking().ToArray();
        }
    }
}
