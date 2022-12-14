using OpenQA.Selenium;

namespace HospitalTests.HospitalE2ETests.Pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    public const string URI = "http://localhost:4200";

    private IWebElement LoginButton => _driver.FindElement(
        By.CssSelector("button[routerLink='/auth/login']"));

    private IWebElement CalendarLink => _driver.FindElement(
        By.Id("a[routerLink='/calendar']"));

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public bool LoginButtonDisplayed()
    {
        return LoginButton.Displayed;
    }

    public bool ExaminationsLinkDisplayed()
    {
        return CalendarLink.Displayed;
    }

    public void GoToLogin()
    {
        LoginButton.Click();
    }

    public void GoToCalendar()
    {
        CalendarLink.Click();
    }

    public void Navigate()
    {
        _driver.Navigate().GoToUrl(URI);
    }
}