using HospitalTests.HospitalE2ETests.Pages;
using HospitalTests.HospitalE2ETests.ScheduleExaminationTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;

namespace HospitalTests.HospitalE2ETests.ScheduleExaminationTests;

public class ScheduleExaminationTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly ExaminationsPage _examinationsPage;
    private readonly ScheduleExaminationPage _scheduleExaminationPage;
    private readonly HomePage _homePage;
    private readonly LoginPage _loginPage;
    private readonly CalendarPage _calendarPage;
    private readonly int _examinationsCount = 0;

    public ScheduleExaminationTests()
    {
        var options = CreateChromeOptions();

        _driver = new ChromeDriver(options);

        _homePage = new HomePage(_driver);
        _homePage.Navigate();
        _homePage.LoginButtonDisplayed().ShouldBe(true);
        _homePage.GoToLogin();

        _loginPage = new LoginPage(_driver);
        ValidateLoginPage();
        Login();

        _driver.Url.ShouldBe(HomePage.URI + "/");
        _homePage.ExaminationsLinkDisplayed().ShouldBe(true);
        _homePage.GoToCalendar();

        _calendarPage = new CalendarPage(_driver);
        ValidateCalendarPage();
        _calendarPage.SelectDate();
        _calendarPage.ChooseDate();

        _examinationsPage = new ExaminationsPage(_driver);
        ValidateExaminationsPage();
        _examinationsCount = _examinationsPage.GetRowsCount();
        _examinationsPage.ClickButton();

        _scheduleExaminationPage = new ScheduleExaminationPage(_driver);
        ValidateScheduleExaminationPage();
    }

    private static ChromeOptions CreateChromeOptions()
    {
        // options for launching Google Chrome
        var options = new ChromeOptions();
        options.AddArguments("start-maximized"); // open Browser in maximized mode
        options.AddArguments("disable-infobars"); // disabling infobars
        options.AddArguments("--disable-extensions"); // disabling extensions
        options.AddArguments("--disable-gpu"); // applicable to windows os only
        options.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
        options.AddArguments("--no-sandbox"); // Bypass OS security model
        options.AddArguments("--disable-notifications"); // disable notifications

        return options;
    }

    private void ValidateScheduleExaminationPage()
    {
        _driver.Url.ShouldBe(ScheduleExaminationPage.URI);
        _scheduleExaminationPage.PatientSelectBoxDisplayed().ShouldBe(true);
        _scheduleExaminationPage.DatePickerDisplayed().ShouldBe(true);
        _scheduleExaminationPage.TimePickerDisplayed().ShouldBe(true);
        _scheduleExaminationPage.DurationSelectBoxDisplayed().ShouldBe(true);
        _scheduleExaminationPage.SubmitButtonDisplayed().ShouldBe(true);
        _scheduleExaminationPage.BackButtonDisplayed().ShouldBe(true);
    }

    private void ValidateExaminationsPage()
    {
        _driver.Url.ShouldBe(ExaminationsPage.URI);
        _examinationsPage.EnsurePageIsDisplayed();
        _examinationsPage.ButtonDisplayed().ShouldBe(true);
    }

    private void ValidateCalendarPage()
    {
        _driver.Url.ShouldBe(CalendarPage.URI);
        _calendarPage.ChooseButtonDisplayed().ShouldBe(true);
        _calendarPage.CalendarDisplayed().ShouldBe(true);
    }

    private void ValidateLoginPage()
    {
        _driver.Url.ShouldBe(LoginPage.URI);
        _loginPage.UsernameTextBoxDisplayed().ShouldBe(true);
        _loginPage.PasswordTextBoxDisplayed().ShouldBe(true);
        _loginPage.SubmitButtonDisplayed().ShouldBe(true);
    }

    private void Login()
    {
        _loginPage.InsertUsername("doctor");
        _loginPage.InsertPassword("12345");
        _loginPage.Login();

        _loginPage.WaitForLogin();
    }

    [Fact]
    public void InvalidPatientShowsErrorMessage()
    {
        _scheduleExaminationPage.InsertTime("15:37");
        _scheduleExaminationPage.InsertDuration("15");
        _scheduleExaminationPage.SubmitForm();

        _scheduleExaminationPage.WaitForElementAppearance("patientError");

        _scheduleExaminationPage.PatientErrorDisplayed().ShouldBe(true);
        _scheduleExaminationPage.SubmitErrorDisplayed().ShouldBe(true);
        _scheduleExaminationPage.GetPatientError().ShouldBe(
            ScheduleExaminationPage.PatientErrorMessage);
        _scheduleExaminationPage.GetSubmitError().ShouldBe(
            ScheduleExaminationPage.SubmitErrorMessage);
        _driver.Url.ShouldBe(ScheduleExaminationPage.URI);
    }

    [Fact]
    public void InvalidTimeShowsErrorMessage()
    {
        _scheduleExaminationPage.InsertPatient("1");
        _scheduleExaminationPage.InsertDuration("15");
        _scheduleExaminationPage.SubmitForm();

        _scheduleExaminationPage.WaitForElementAppearance("startTimeError");

        _scheduleExaminationPage.StartTimeErrorDisplayed().ShouldBe(true);
        _scheduleExaminationPage.SubmitErrorDisplayed().ShouldBe(true);
        _scheduleExaminationPage.GetStartTimeError().ShouldBe(
            ScheduleExaminationPage.StartTimeErrorMessage);
        _scheduleExaminationPage.GetSubmitError().ShouldBe(
            ScheduleExaminationPage.SubmitErrorMessage);
        _driver.Url.ShouldBe(ScheduleExaminationPage.URI);
    }

    [Fact]
    public void InvalidDurationShowsErrorMessage()
    {
        _scheduleExaminationPage.InsertPatient("2");
        _scheduleExaminationPage.InsertTime("15:35");
        _scheduleExaminationPage.SubmitForm();

        _scheduleExaminationPage.WaitForElementAppearance("durationError");

        _scheduleExaminationPage.DurationErrorDisplayed().ShouldBe(true);
        _scheduleExaminationPage.SubmitErrorDisplayed().ShouldBe(true);
        _scheduleExaminationPage.GetDurationError().ShouldBe(
            ScheduleExaminationPage.DurationErrorMessage);
        _scheduleExaminationPage.GetSubmitError().ShouldBe(
            ScheduleExaminationPage.SubmitErrorMessage);
        _driver.Url.ShouldBe(ScheduleExaminationPage.URI);
    }

    [Fact]
    public void ValidInputSchedulesExamination()
    {
        _scheduleExaminationPage.InsertPatient("2");
        _scheduleExaminationPage.InsertTime("15:55");
        _scheduleExaminationPage.InsertDuration("15");
        _scheduleExaminationPage.SubmitForm();

        _scheduleExaminationPage.WaitForSubmit();

        var newExaminationPage = new ExaminationsPage(_driver);
        newExaminationPage.EnsurePageIsDisplayed();

        newExaminationPage.ButtonDisplayed().ShouldBe(true);
        _examinationsPage.GetRowsCount().ShouldBe(_examinationsCount + 1);
        _examinationsPage.GetLastRowStartTime().ShouldBe("15:55");
        _examinationsPage.GetLastRowEndTime().ShouldBe("16:10");
        _examinationsPage.GetLastRowPatientId().ShouldBe("2");
    }

    [Fact]
    public void ValidInputShowsErrorIfAppointmentTimeIsBusy()
    {
        _scheduleExaminationPage.InsertPatient("2");
        _scheduleExaminationPage.InsertTime("13:00");
        _scheduleExaminationPage.InsertDuration("60");
        _scheduleExaminationPage.SubmitForm();

        _scheduleExaminationPage.WaitForElementAppearance("submitError");

        _scheduleExaminationPage.SubmitErrorDisplayed().ShouldBe(true);
        _scheduleExaminationPage.GetSubmitError().ShouldBe(
            ScheduleExaminationPage.CalendarFullErrorMessage);
        _driver.Url.ShouldBe(ScheduleExaminationPage.URI);
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}