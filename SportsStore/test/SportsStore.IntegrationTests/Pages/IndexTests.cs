using System.Net;
using AngleSharp.Html.Dom;
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
    public async Task Get_Index_Page_Returns_SuccessAsync()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Empty);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Get_Index_Page_Filtered_Products_By_Category()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("?category=Football");

        var content = await HtmlDocumentHelper.GetDocumentAsync(response);

        var products = content.QuerySelectorAll("#products .card");

        Assert.Equal(4, products?.Length);
    }

    [Fact]
    public async Task Add_Product_to_Cart()
    {
        var client = _factory.CreateClient();

        var homePageResponse = await client.GetAsync(string.Empty);

        var homePage = await HtmlDocumentHelper.GetDocumentAsync(homePageResponse);

        var form = (IHtmlFormElement)homePage.QuerySelector("form")!;
        var submit = (IHtmlButtonElement)homePage.QuerySelector("button[type='submit']")!;

        var cartPageResponse = await client.SendAsync(form, submit, new Dictionary<string, string> { });

        var cartPage = await HtmlDocumentHelper.GetDocumentAsync(cartPageResponse);

        var lines = cartPage.QuerySelector("#cart #lines");

        Assert.NotNull(lines);
        Assert.Equal(1, lines!.Children.Length);
    }
}
