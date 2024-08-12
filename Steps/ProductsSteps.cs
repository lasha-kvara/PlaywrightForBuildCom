using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PangoTest.API;
using PangoTest.Drivers;
using PangoTest.Pages;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;

namespace PangoTest.Steps;

[Binding]
public class ProductsSteps : BasePage
{
    private readonly Driver _driver;
    private readonly Products _products;
    

    public ProductsSteps(Driver driver) : base(driver.Page, driver)
    {
        _driver = driver;
        _products = new Products(_driver.Page, _driver);
    }


    [Given(@"Search Product Named ""(.*)""")]
    public async Task GivenSearchProductNamed(string productName)
    {
        await SearchProduct(productName);
    }

    [Then(@"Verify That Product Card Are Visible")]
    public async Task ThenVerifyThatProductCardAreVisible()
    {
        await _products.VerifyProductCard_isVisible();
    }

    [Then(@"Verify Product ""(.*)"" Price Should Be \$(.*)")]
    public async Task ThenVerifyProductPriceShouldBe(string productName, decimal price)
    {
        decimal productPrice = await _products.GetPrice_FromProductCard(productName);
        Console.WriteLine("Product Price = " + productPrice);
        Console.WriteLine("Expected Price = " + price);
        Assert.That(productPrice.Equals(price));
    }

    

    [Then(@"bearer")]
    public async Task ThenBearer()
    {
        Console.WriteLine("BEAREEEER == " + _driver._bearerToken);
    }
    
}