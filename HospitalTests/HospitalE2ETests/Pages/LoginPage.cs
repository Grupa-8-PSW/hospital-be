using HospitalTests.HospitalE2ETests.ScheduleExaminationTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalTests.HospitalE2ETests.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    public const string URI = "http://localhost:4200/auth/login";

    private IWebElement UsernameTextBox => _driver.FindElement(By.CssSelector("input[name='username']"));
    private IWebElement PasswordTextBox => _driver.FindElement(By.CssSelector("input[name='password']"));
    private IWebElement SubmitButton => _driver.FindElement(By.CssSelector("button[type='submit']"));

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    #region Ensure Displayed

    public bool UsernameTextBoxDisplayed()
    {
        return UsernameTextBox.Displayed;
    }

    public bool PasswordTextBoxDisplayed()
    {
        return PasswordTextBox.Displayed;
    }

    public bool SubmitButtonDisplayed()
    {
        return SubmitButton.Displayed;
    }

    #endregion

    #region Insert Values

    public void InsertUsername(string username)
    {
        UsernameTextBox.SendKeys(username);
    }

    public void InsertPassword(string password)
    {
        PasswordTextBox.SendKeys(password);
    }

    #endregion

    public void Login()
    {
        SubmitButton.Click();
    }

    public void WaitForLogin()
    {
        var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(HomePage.URI + "/"));
    }
}
