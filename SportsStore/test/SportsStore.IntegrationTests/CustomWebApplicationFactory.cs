using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;

namespace SportsStore.IntegrationTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private readonly string _connectionStringKey = "ConnectionStrings:DefaultConnection";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        var projectDir = Directory.GetCurrentDirectory();
        var configPath = Path.Combine(projectDir, "appsettings.json");

        builder.ConfigureAppConfiguration((context, config) =>
        {
            config.AddJsonFile(configPath);
        });

        builder.UseEnvironment("Development");

        builder.ConfigureTestServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<StoreDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();

            var provider = scope.ServiceProvider;

            var config = provider.GetRequiredService<IConfiguration>();

            var connectionString = config.GetValue<string>(_connectionStringKey);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string is missing.");
            }

            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        });
    }
}
