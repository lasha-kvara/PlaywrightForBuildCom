using System;
using Microsoft.Playwright;

namespace PangoTest.Drivers
{
    public class Driver : IDisposable
    {
        private readonly IBrowser? _browser;
        private readonly IPage _page;

        public Driver()
        {
            _browser = InitializePlaywright();
            _page = _browser.NewPageAsync().GetAwaiter().GetResult(); // Blocking, for simplicity
        }

        public IPage Page => _page;

        private IBrowser InitializePlaywright()
        {
            var playwright = Playwright.CreateAsync().GetAwaiter().GetResult(); // Blocking, for simplicity
            var browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                //SlowMo = 500
            }).GetAwaiter().GetResult(); // Blocking, for simplicity
            return browser;
        }

        public async Task<IPage> OpenNewBrowserPage(string url)
        {
            var newBrowser = _browser;
            var page = newBrowser?.NewPageAsync().GetAwaiter().GetResult();
            await page?.GotoAsync(url)!;
            await Task.Delay(5000);
            return page;
        }

        public void ClosePage(IPage page)
        { 
            page?.CloseAsync().GetAwaiter().GetResult(); // Blocking, for simplicity
        }
        public string _bearerToken;
        public async Task<string> GetBearerTokenFromNetworkAsync()
        {
            // Set up network request interception
            _page.Request += (_, e) =>
            {
                var headers = e.Headers;
                if (headers.TryGetValue("authorization", out var authorization))
                {
                    var token = authorization.Split(' ')[1]; // Assumes 'Bearer <token>'
                    _bearerToken = token;
                    Console.WriteLine("Authorization header: " + authorization);
                }
            };

            
            return null; // Adjust as needed based on your requirements
        }

       
            
        public void Dispose()
        {
            _browser?.CloseAsync().GetAwaiter().GetResult(); // Blocking, for simplicity
        }
    }
}