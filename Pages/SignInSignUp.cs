using System.Text.RegularExpressions;
using PangoTest.Drivers;
using Gherkin;
using Microsoft.Playwright;
using NUnit.Framework;
using PangoTest.Drivers;
using PangoTest.Pages;

namespace PangoTest.Pages;

public class SignInSignUp : BasePage
{
    private readonly IPage _page;
    private readonly Driver _driver;

    public SignInSignUp(IPage page, Driver driver) : base(page, driver)
    {
        _page = page;
        _driver = driver;
    }

    public async Task ClickLogin_Dropdown() => await _login_Dropdown.ClickAsync();
    public async Task ClickLogin_Button() => await _login_Button.ClickAsync();
    public async Task EnterEmail_InInput(string email) => await _email_Input.FillAsync(email);
    public async Task EnterPassword_InInput(string pass) => await _password_Input.FillAsync(pass);

    
    
    #region Elements Visibility
    public async Task<bool> InvalidEmailOrPass_ErrorMsg_Visible() => 
        await _invalidEmailOrPass_Message.IsVisibleAsync(new LocatorIsVisibleOptions{ Timeout = 3000 });
    public async Task<bool> HelloMessage_AfterLogin() => 
        await _helloMessage.IsVisibleAsync(new LocatorIsVisibleOptions{ Timeout = 3000 });
    
    #endregion Elements Visibility*/

    
    
    
    
    #region SignIn Locators
    
    private ILocator _login_Dropdown => _page.GetByLabel("account dropdown");
    private ILocator _login_Button => _page.GetByRole(AriaRole.Button, new() { Name = "Log in" });
    private ILocator _email_Input => _page.GetByPlaceholder("Email", new() { Exact = true });
    private ILocator _password_Input => _page.GetByPlaceholder("Password");
    private ILocator _emptyEmailInput_Msg => _page.GetByText("Please enter an email address.");
    private ILocator _emptyPasswordInput_Msg => _page.GetByText("Please enter a password.");
    private ILocator _helloMessage => _page.GetByText("Hello, Albert");
    private ILocator _invalidEmailOrPass_Message => _page.GetByText("Invalid email address and/or password.");

    #endregion
}