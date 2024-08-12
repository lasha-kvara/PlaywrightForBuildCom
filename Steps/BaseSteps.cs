using PangoTest.Drivers;
using PangoTest.Pages;
using TechTalk.SpecFlow;

namespace PangoTest.Steps;

[Binding]
public class BaseSteps : BasePage
{
    private readonly Driver _driver;

    public BaseSteps(Driver driver) : base(driver.Page, driver)
    {
        _driver = driver;
    }


    [Given(@"Verify Navigation Menu Elements Are Visible")]
    public async Task ThenVerifyNavigationMenuElementsAreVisible()
    {
        await VerifyElementVisibility();
    }
}