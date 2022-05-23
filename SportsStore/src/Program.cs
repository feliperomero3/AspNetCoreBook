using Microsoft.EntityFrameworkCore;
using SportsStore.Data;

namespace SportsStore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connectionString));

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.MapRazorPages();

        app.Run();
    }
}
