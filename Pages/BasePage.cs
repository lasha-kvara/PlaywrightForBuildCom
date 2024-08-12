using PangoTest.Drivers;
using Microsoft.Playwright;
using PangoTest.Drivers;
using static Microsoft.Playwright.Assertions;

namespace PangoTest.Pages;

public class BasePage
{
    private readonly IPage _page;
    private readonly Driver _driver;


    public BasePage(IPage page, Driver driver)
    {
        _page = page;
        _driver = driver;
    }
    
    #region Elements Visibility
    
    public async Task VerifyElementVisibility()
    {
        var elements = new List<ILocator>
        {
            _navigation_Bathroom_Btn,
            _navigation_ShopAllDepartments_Btn,
            _navigation_Kitchen_Btn,
            _navigation_Lighting_Btn,
            _navigation_Fans_Btn,
            _navigation_Hardware_Btn,
            _navigation_appliances_Btn,
            _navigation_flooring_Btn,
            _navigation_cabinetHardware_Btn,
            _navigation_outdoor_Btn,
            _navigation_hvac_Btn,
            _navigation_clearance_Btn
        };

        foreach (var element in elements)
        {
            if (!await element.IsVisibleAsync())
            {
                throw new Exception($"Element {element} is not visible.");
            }
        }

        Console.WriteLine("All elements are visible.");
    }

    #endregion Elements Visibility


    public async Task SearchProduct(string productName)
    {
        await _search_Input.ClickAsync();
        await _search_Input.FillAsync(productName);
        await _search_Btn.ClickAsync();
        await Task.Delay(2000);
    }
    
    private ILocator _navigation_Bathroom_Btn => _page.Locator("//*[@data-automation='bathroom-link']");
    private ILocator _navigation_ShopAllDepartments_Btn => _page.Locator("//*[@data-automation='shop-all-departments-button']");
    private ILocator _navigation_Kitchen_Btn => _page.Locator("//*[@data-automation='kitchen-link']");
    private ILocator _navigation_Lighting_Btn => _page.Locator("//*[@data-automation='lighting-link']");
    private ILocator _navigation_Fans_Btn => _page.Locator("//*[@data-automation='fans-link']");
    private ILocator _navigation_Hardware_Btn => _page.Locator("//*[@data-automation='hardware-link']");
    private ILocator _navigation_appliances_Btn => _page.Locator("//*[@data-automation='appliances-link']");
    private ILocator _navigation_flooring_Btn => _page.Locator("//*[@data-automation='flooring-link']");
    private ILocator _navigation_cabinetHardware_Btn => _page.Locator("//*[@data-automation='cabinet-hardware-link']");
    private ILocator _navigation_outdoor_Btn => _page.Locator("//*[@data-automation='outdoor-link']");
    private ILocator _navigation_hvac_Btn => _page.Locator("//*[@data-automation='hvac-link']");
    private ILocator _navigation_clearance_Btn => _page.Locator("//*[@data-automation='clearance-link']");
    private ILocator _search_Input => _page.Locator("//*[@data-automation='search-input']").First;
    private ILocator _search_Btn => _page.Locator("(//*[@aria-label='Submit search'])[1]");
    
}