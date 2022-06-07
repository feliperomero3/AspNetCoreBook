using System.Net;
using AngleSharp.Html.Dom;
using SportsStore.IntegrationTests.Helpers;

namespace SportsStore.IntegrationTests.Pages;

public class CheckoutTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public CheckoutTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _factory.ClientOptions.AllowAutoRedirect = false;
        _factory.ClientOptions.BaseAddress = new Uri("https://localhost:5000/");
    }

    [Fact]
    public async Task Submit_an_OrderAsync()
    {
        var client = _factory.CreateClient();

        var homePageResponse = await client.GetAsync(string.Empty);

        var homePage = await HtmlDocumentHelper.GetDocumentAsync(homePageResponse);

        var form = (IHtmlFormElement)homePage.QuerySelector("form")!;
        var submit = (IHtmlButtonElement)homePage.QuerySelector("button[type='submit']")!;

        var cartPageResponse = await client.SendAsync(form, submit);

        var checkoutPageResponse = await client.GetAsync("Checkout");

        var checkoutPage = await HtmlDocumentHelper.GetDocumentAsync(checkoutPageResponse);

        var formCheckoutPage = (IHtmlFormElement)checkoutPage.QuerySelector("form")!;
        var submitCheckoutPage = (IHtmlButtonElement)checkoutPage.QuerySelector("button[type='submit']")!;

        var completedPageResponse = await client.SendAsync(formCheckoutPage, submitCheckoutPage,
            new Dictionary<string, string>()
            {
                ["Order.Name"] = "Alice Smith",
                ["Order.Line1"] = "Main Street #1",
                ["Order.City"] = "New York",
                ["Order.State"] = "New York",
                ["Order.Zip"] = "10001",
                ["Order.Country"] = "United States of America"
            });

        Assert.Equal(HttpStatusCode.Redirect, completedPageResponse.StatusCode);
        Assert.Equal("/Completed?orderId=1", completedPageResponse.Headers.Location?.OriginalString);
    }
}