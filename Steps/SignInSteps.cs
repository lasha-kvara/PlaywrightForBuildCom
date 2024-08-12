using PangoTest.Drivers;
using PangoTest.Pages;
using TechTalk.SpecFlow;

namespace PangoTest.Steps;

[Binding]
public class SignInSteps : BasePage
{
    private readonly Driver _driver;
    private readonly SignInSignUp _signInSignUp;

    public SignInSteps(Driver driver) : base(driver.Page, driver)
    {
        _driver = driver;
        _signInSignUp = new SignInSignUp(_driver.Page, _driver);
    }
    
    [Given(@"Go To Login Page")]
    public async Task GivenGoToLoginPage()
    {
        await _signInSignUp.ClickLogin_Dropdown();
        await _signInSignUp.ClickLogin_Button();
    }

    [Then(@"Enter Email ""(.*)""")]
    public async Task ThenEnterEmail(string email)
    {
        await _signInSignUp.EnterEmail_InInput(email);
    }

    [Then(@"Enter Password ""(.*)""")]
    public async Task ThenEnterPassword(string pass)
    {
        await _signInSignUp.EnterPassword_InInput(pass);
    }

    [Then(@"Click Login Button")]
    public async Task ThenClickLoginButton()
    {
        await _signInSignUp.ClickLogin_Button();
    }

    [Then(@"Verify Login Successful")]
    public async Task ThenVerifyLoginSuccessful()
    {
        await _signInSignUp.HelloMessage_AfterLogin();
    }

    [Then(@"Verify Invalid Email Or Password Error Message")]
    public async Task ThenVerifyInvalidEmailOrPasswordErrorMessage()
    {
        await _signInSignUp.InvalidEmailOrPass_ErrorMsg_Visible();
    }
}