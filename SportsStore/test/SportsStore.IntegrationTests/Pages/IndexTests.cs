using System.Net;
using SportsStore.IntegrationTests.Helpers;

namespace SportsStore.IntegrationTests.Pages;

public class IndexTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public IndexTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _factory.ClientOptions.AllowAutoRedirect = true;
        _factory.ClientOptions.BaseAddress = new Uri("https://localhost:5000/");
    }

    [Fact]
    public async Task Homepage()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Empty);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Filter_Products_by_Category()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("?category=Football");

        var content = await HtmlDocumentHelper.GetDocumentAsync(response);

        var products = content.QuerySelectorAll("#products .card");

        Assert.Equal(4, products?.Length);
    }
}
