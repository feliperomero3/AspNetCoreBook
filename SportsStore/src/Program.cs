using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Services;

namespace SportsStore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddSession();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddScoped<CartService>();
        builder.Services.AddScoped<StoreDbContextInitializer>();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connectionString));

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<StoreDbContextInitializer>().Initialize();
        }

        app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseSession();

        app.MapRazorPages();

        app.MapBlazorHub();
        app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

        app.Run();
    }
}
