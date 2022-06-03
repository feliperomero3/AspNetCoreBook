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

    [Fact]
    public async Task Remove_Product_from_Cart()
    {
        var client = _factory.CreateClient();

        var homePageResponse = await client.GetAsync(string.Empty);

        var homePage = await HtmlDocumentHelper.GetDocumentAsync(homePageResponse);

        var form = (IHtmlFormElement)homePage.QuerySelector("form")!;
        var submit = (IHtmlButtonElement)homePage.QuerySelector("button[type='submit']")!;

        var cartPageResponse = await client.SendAsync(form, submit);

        var cartPage = await HtmlDocumentHelper.GetDocumentAsync(cartPageResponse);

        var formCartPage = (IHtmlFormElement)cartPage.QuerySelector("form")!;
        var submitCartPage = (IHtmlButtonElement)cartPage.QuerySelector("button[type='submit']")!;

        var cartPage2Response = await client.SendAsync(formCartPage, submitCartPage);

        var cartPage2 = await HtmlDocumentHelper.GetDocumentAsync(cartPage2Response);

        var lines = cartPage2.QuerySelector("#cart #lines");

        Assert.NotNull(lines);
        Assert.Equal(0, lines!.Children.Length);
    }
}
