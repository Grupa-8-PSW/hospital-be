using HospitalTests.HospitalE2ETests.Pages.Public;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;


namespace HospitalTests.HospitalE2ETests.AppointmentTests
{
    public class CancelAppointmentTest : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        private readonly ViewAppointmentsPage _viewAppointmentsPage;

        public CancelAppointmentTest()
        {
            var options = CreateChromeOptions();
            _driver = new ChromeDriver(options);

            _homePage = new HomePage(_driver);
            _homePage.Navigate();
            _homePage.LoginLinkDisplayed().ShouldBe(true);
            _homePage.ClickLoginLink();

            _loginPage = new LoginPage(_driver);
            _driver.Url.ShouldBe(LoginPage.URI);
            _loginPage.UsernameElementDisplayed().ShouldBe(true);
            _loginPage.PasswordElementDisplayed().ShouldBe(true);
            _loginPage.SubmitButtonElementDisplayed().ShouldBe(true);
            Login();

            _driver.Url.ShouldBe(HomePage.URI);
            _homePage.ClickViewAppointmentsLink();

            _viewAppointmentsPage = new ViewAppointmentsPage(_driver);
            _driver.Url.ShouldBe(ViewAppointmentsPage.URI);
            _viewAppointmentsPage.CancelButtonDisplayed().ShouldBe(true);
        }

        private void Login()
        {
            _loginPage.InsertUsername("patient");
            _loginPage.InsertPassword("12345");
            _loginPage.Login();
            _loginPage.WaitForLogin();
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

        [Fact]
        public void SuccessfullyCancells()
        {
            _viewAppointmentsPage.ClickCancelButton();
            _viewAppointmentsPage.WaitForAlertDialog();
            Assert.Equal(_viewAppointmentsPage.GetValidMessage(), ViewAppointmentsPage.ValidMessage);
            _viewAppointmentsPage.ResolveAlertDialog();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
