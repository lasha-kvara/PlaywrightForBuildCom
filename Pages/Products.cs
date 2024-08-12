using Microsoft.Playwright;
using PangoTest.Drivers;

namespace PangoTest.Pages;

public class Products : BasePage
{
    private readonly IPage _page;
    private readonly Driver _driver;

    public Products(IPage page, Driver driver) : base(page, driver)
    {
        _page = page;
        _driver = driver;
    }

    public async Task VerifyProductCard_isVisible() => await Assertions.Expect(_productCard()).ToBeVisibleAsync();
    
    public async Task<decimal> GetPrice_FromProductCard(string prodId)
    {
        // Get the inner text of the price element
        var priceText = await _price_FromProductCard().InnerTextAsync();
    
        // Remove all non-numeric characters except the decimal point
        var cleanedPriceText = System.Text.RegularExpressions.Regex.Replace(priceText, "[^0-9.]", "");

        Console.WriteLine("cleaned price = " + cleanedPriceText);
        
        // Parse the cleaned price text to decimal
        if (decimal.TryParse(cleanedPriceText, out var price))
        {
            return price;
        }
    
        throw new Exception($"Unable to parse price from product card with ID {prodId}. Price text was: '{priceText}'");
    }
    #region Products Locators
    
    private ILocator _productCard() => _page.Locator($"(//*[@data-automation[contains(., 'product-card')]])[1]");
    private ILocator _price_FromProductCard() => _page.Locator($"(//*[@data-automation[contains(., 'product-card')]])[1]/div/div[2]/div/div/div/span");
    
    #endregion
    
}