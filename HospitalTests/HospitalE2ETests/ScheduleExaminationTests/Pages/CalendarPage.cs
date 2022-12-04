using OpenQA.Selenium;

namespace HospitalTests.HospitalE2ETests.ScheduleExaminationTests.Pages;

public class CalendarPage
{
    private readonly IWebDriver _driver;
    public const string URI = "http://localhost:4200/calendar";

    private IWebElement Calendar => _driver.FindElement(By.ClassName("mat-calendar"));
    private IWebElement ChooseButton => _driver.FindElement(By.CssSelector("button[type='submit']"));

    private IWebElement CalendarDateButton => _driver.FindElement(
        By.XPath("//button[@aria-label='2022-12-16T00:00:00+01:00']"));

    public CalendarPage(IWebDriver driver)
    {
        _driver = driver;
    }

    #region Ensure Displayed

    public bool CalendarDisplayed()
    {
        return Calendar.Displayed;
    }

    public bool ChooseButtonDisplayed()
    {
        return ChooseButton.Displayed;
    }

    #endregion

    public void InsertDate(string date)
    {
        Calendar.SendKeys(date);
    }

    public void SelectDate()
    {
        CalendarDateButton.Click();
    }

    public void ChooseDate()
    {
        ChooseButton.Click();
    }
}