using System.Diagnostics;
using Allure.Commons;
using Microsoft.Playwright;
using PangoTest.Drivers;
using PangoTest.Pages;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(5)] // Specify the worker limit here

namespace PangoTest.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IPage _page;
        private readonly Driver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly BasePage _basePage;
        private static Process? _process;
        private static AllureLifecycle _allure = AllureLifecycle.Instance;


        // The Base Url is Here
        private static readonly string BaseUrl = "https://www.build.com/";

        public Hooks(Driver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _page = _driver.Page;
            _scenarioContext = scenarioContext;
            _basePage = new BasePage(_page, _driver);
        }

        [BeforeScenario]
        public async Task SetupMethod()
        {
            await MaximizeWindow();
            await _driver.GetBearerTokenFromNetworkAsync();
            await GoToUrl(BaseUrl);
            
        }

        [AfterScenario]
        public void TeardownMethod()
        {
            // This will close the driver after scenario
            _driver?.Dispose();
        }
        
        [BeforeTestRun]
        public static void BeforeTestTun()
        {
            _allure.CleanupResultDirectory();
        }

        [AfterStep]
        public async Task AfterStep()
        {
            // It will take the screenshot if some test fails
            if (_scenarioContext.TestError != null)
            {
                var scenarioTitle = _scenarioContext.ScenarioInfo.Title;
                var content = await TakeScreen(_page);
                _allure.AddAttachment($"Allure Failed Screenshot - {scenarioTitle}", "application/png", content);
            }
        }
        

        // This Method Will Take Screenshot and save in Reports/Screenshorts Directory
        private async Task<byte[]> TakeScreen(IPage page)
        {
            var scenarioTitle = _scenarioContext.ScenarioInfo.Title;
            DateTime time = DateTime.Now;
            string nowTime = time.ToString("dd-MMM-yy HH-mm-ss");
            
            var screen = await page.ScreenshotAsync(new()
            {
                Path = $"../../../Reports/Screenshots/{nowTime}-{scenarioTitle}.png"
            });
            return screen;
        }

        private async Task MaximizeWindow()
        {
            await _page.SetViewportSizeAsync(1920, 900);
        }

        public async Task GoToUrl(string envUrl)
        {
            await _driver.Page.GotoAsync(envUrl);
        }
    }
}