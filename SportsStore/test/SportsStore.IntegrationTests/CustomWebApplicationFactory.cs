using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.IntegrationTests.Helpers;

namespace SportsStore.IntegrationTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportsStoreTests;Integrated Security=True;";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<StoreDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(_connectionString);
            });
            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();

            var provider = scope.ServiceProvider;

            var context = provider.GetRequiredService<StoreDbContext>();

            try
            {
                DatabaseHelper.InitializeTestDatabase(context);
            }
            catch (SqlException sqlException)
            {
                var logger = provider.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                logger.LogError(sqlException, "An error occurred creating the test database.");

                throw;
            }
        });
    }
}
