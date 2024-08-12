using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PangoTest.Drivers;
using PangoTest.Pages;
using TechTalk.SpecFlow;

namespace PangoTest.Steps;


[Binding]
public class ApiSteps : BasePage
{
    private readonly Driver _driver;
    private readonly Products _products;
    private string? _cityName;

    public ApiSteps(Driver driver) : base(driver.Page, driver)
    {
        _driver = driver;
        _products = new Products(_driver.Page, _driver);
    }

    [Then(@"Test API")]
    public async Task ThenTestApi()
    {

        var client = new HttpClient();
        var resp = await client.GetStringAsync("https://any.ge/weather/api2.php?get=daily&id=611717");

        // Parse the JSON response
        var json = JObject.Parse(resp);

        // Extract the city name
        _cityName = json["city"]?["name"]?.ToString();

        Console.WriteLine("City Name: " + _cityName);
    }
    
    [Then(@"Api response city should be ""(.*)""")]
    public void ThenApiResponseCityShouldBe(string city)
    {
        Assert.That(_cityName != null && _cityName.Equals(city));
    }
}