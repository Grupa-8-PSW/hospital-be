using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalTests.HospitalE2ETests.ScheduleExaminationTests.Pages;

public class ScheduleExaminationPage
{
    private readonly IWebDriver _driver;
    public const string URI = "http://localhost:4200/examinations/create/16/12/2022";

    private SelectElement PatientSelectBox => new SelectElement(_driver.FindElement(By.Name("patient")));
    private IWebElement TimePicker => _driver.FindElement(By.Name("startTime"));
    private IWebElement DatePicker => _driver.FindElement(By.CssSelector("input[formcontrolname='date']"));
    private SelectElement DurationSelectBox => new SelectElement(_driver.FindElement(By.Name("duration")));
    private IWebElement SubmitButton => _driver.FindElement(By.Id("createExamination"));
    private IWebElement BackButton => _driver.FindElement(By.Id("backButton"));
    private IWebElement PatientError => _driver.FindElement(By.Id("patientError"));
    private IWebElement StartTimeError => _driver.FindElement(By.Id("startTimeError"));
    private IWebElement DurationError => _driver.FindElement(By.Id("durationError"));
    private IWebElement SubmitError => _driver.FindElement(By.Id("submitError"));

    public const string PatientErrorMessage = "Please select patient";
    public const string StartTimeErrorMessage = "Please select start time";
    public const string DurationErrorMessage = "Please select duration";
    public const string SubmitErrorMessage = "All fields must be valid.";
    public const string CalendarFullErrorMessage = "Error creating examination, calendar full for that time";
    public ScheduleExaminationPage(IWebDriver driver)
    {
        _driver = driver;
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
    }

    public bool PatientSelectBoxDisplayed()
    {
        return PatientSelectBox.WrappedElement.Displayed;
    }

    public bool TimePickerDisplayed()
    {
        return TimePicker.Displayed;
    }

    public bool DatePickerDisplayed()
    {
        return DatePicker.Displayed;
    }

    public bool DurationSelectBoxDisplayed()
    {
        return DurationSelectBox.WrappedElement.Displayed;
    }

    public bool SubmitButtonDisplayed()
    {
        return SubmitButton.Displayed;
    }

    public bool BackButtonDisplayed()
    {
        return BackButton.Displayed;
    }

    public bool PatientErrorDisplayed()
    {
        return PatientError.Displayed;
    }

    public bool StartTimeErrorDisplayed()
    {
        return StartTimeError.Displayed;
    }

    public bool DurationErrorDisplayed()
    {
        return DurationError.Displayed;
    }

    public bool SubmitErrorDisplayed()
    {
        return SubmitError.Displayed;
    }

    public void InsertPatient(string patientId)
    {
        PatientSelectBox.SelectByValue(patientId);
    }

    public void InsertTime(string time)
    {
        TimePicker.SendKeys(time);
    }

    public void InsertDuration(string duration)
    {
        DurationSelectBox.SelectByValue(duration);
    }

    public void SubmitForm()
    {
        SubmitButton.Click();
    }

    public void GoBack()
    {
        BackButton.Click();
    }

    public string GetPatientError()
    {
        return PatientError.Text;
    }

    public string GetSubmitError()
    {
        return SubmitError.Text;
    }

    public string GetStartTimeError()
    {
        return StartTimeError.Text;
    }

    public string GetDurationError()
    {
        return DurationError.Text;
    }


    public void WaitForSubmit()
    {
        var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(ExaminationsPage.URI));
    }

    public void WaitForElementAppearance(string elementId)
    {
        var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(elementId)));
    }


}