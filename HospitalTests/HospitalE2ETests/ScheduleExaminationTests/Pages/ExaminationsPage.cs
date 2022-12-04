using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalTests.HospitalE2ETests.ScheduleExaminationTests.Pages;

public class ExaminationsPage
{
    private readonly IWebDriver _driver;

    public const string URI = "http://localhost:4200/examinations/16/12/2022";

    private IWebElement Table => _driver.FindElement(By.Id("examinationsTable"));

    //private IReadOnlyCollection<IWebElement> Rows =>
    //    _driver.FindElements(By.XPath("//table[@id=examinationsTable]/tbody/tr"));

    private IReadOnlyCollection<IWebElement> Rows =>
        _driver.FindElements(By.CssSelector("table[id='examinationsTable'] tbody tr"));

    private IWebElement LastRowStartTime =>
        _driver.FindElement(By.XPath("//table[@id='examinationsTable']/tbody/tr[last()]/td[1]"));
    private IWebElement LastRowEndTime =>
        _driver.FindElement(By.XPath("//table[@id='examinationsTable']/tbody/tr[last()]/td[2]"));
    private IWebElement LastRowPatientId =>
        _driver.FindElement(By.XPath("//table[@id='examinationsTable']/tbody/tr[last()]/td[3]"));

    private IWebElement ScheduleExaminationButton =>
        _driver.FindElement(By.Id("scheduleExamination"));

    public ExaminationsPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public void EnsurePageIsDisplayed()
    {
        var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        wait.Until(condition =>
        {
            try
            {
                return Rows.Count > 0;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        });
    }

    public bool ButtonDisplayed()
    {
        return ScheduleExaminationButton.Displayed;
    }

    public void ClickButton()
    {
        ScheduleExaminationButton.Click();
    }

    public int GetRowsCount()
    {
        return Rows.Count;
    }

    public string GetLastRowStartTime()
    {
        return LastRowStartTime.Text;
    }

    public string GetLastRowEndTime()
    {
        return LastRowEndTime.Text;
    }
    public string GetLastRowPatientId()
    {
        return LastRowPatientId.Text;
    }

    public void Navigate() => _driver.Navigate().GoToUrl(URI);

}