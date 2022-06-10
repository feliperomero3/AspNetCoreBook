using SportsStore.Entities;

namespace SportsStore.Data;

public class StoreDbContextInitializer
{
    private readonly StoreDbContext _storeDbContext;

    public StoreDbContextInitializer(StoreDbContext storeDbContext)
    {
        _storeDbContext = storeDbContext;
    }

    public void Initialize()
    {
        _storeDbContext.Database.EnsureCreated();
        
        if (_storeDbContext.Products.Any())
        {
            return;
        }

        var p1 = new Product("Kayak", "A boat for one person", 275, "Water sports");
        var p2 = new Product("Life Jacket", "Protective and fashionable", 48.95m, "Water sports");
        var p3 = new Product("Football Ball", "FIFA-approved size and weight", 19.5m, "Football");
        var p4 = new Product("Corner Flags", "Give your pitch a professional touch", 34.95m, "Football");
        var p5 = new Product("Stadium", "Flat-packed 35,000-seat stadium", 79500, "Football");
        var p6 = new Product("Thinking Cap", "Improve brain efficiency by 75%", 16, "Chess");
        var p7 = new Product("Unsteady Chair", "Secretly give your opponent a disadvantage", 29.95m, "Chess");
        var p8 = new Product("Human Chess Board", "A fun game for the family", 75, "Chess");
        var p9 = new Product("Bling-Bling King", "Gold-plated, diamond-studded King", 1200, "Chess");
        var p10 = new Product("Football Boots", "Nike Legend Academy Football Boots", 38, "Football");

        _storeDbContext.Products.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

        _storeDbContext.SaveChanges();
    }
}