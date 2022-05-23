using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SportsStore.IntegrationTests.Pages;

public class IndexTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public IndexTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _factory.ClientOptions.AllowAutoRedirect = false;
        _factory.ClientOptions.BaseAddress = new Uri("https://localhost:5000/");
    }

    [Fact]
    public async Task Get_Index_Page_Returns_SuccessAsync()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Empty);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
