using HospitalTests.HospitalE2ETests.Pages.Intern;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;

namespace HospitalTests.HospitalE2ETests.FeedbackTests
{
    public class PublicFeedbackApprovalTest
    {
        private const string url = "http://localhost:4200/feedback/approval";

        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;

        private IEnumerable<IWebElement> PublicFeedbacks => _driver.FindElements(
            By.CssSelector("mat-card"));

        public PublicFeedbackApprovalTest()
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

            _driver.Navigate().GoToUrl(url);
            var a = PublicFeedbacks.Count();
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(condition => PublicFeedbacks.Any());
        }

        [Fact]
        public void ApproveFeedback()
        {
            IWebElement button = PublicFeedbacks.Last().FindElement(By.CssSelector("button"));
            var buttonType = button.GetAttribute("name");
            button.Click();
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(condition => {
                var btn = PublicFeedbacks.Last().FindElement(By.CssSelector("button"));
                return btn != null;
            });
            var newButton = PublicFeedbacks.Last().FindElement(By.CssSelector("button"));
            var newButtonType = newButton.GetAttribute("name");
            if (buttonType == "approval-button")
                newButtonType.ShouldBe("deny-button");
            else
                newButtonType.ShouldBe("approval-button");
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

        private void ValidateLoginPage()
        {
            _driver.Url.ShouldBe(LoginPage.URI);
            _loginPage.UsernameTextBoxDisplayed().ShouldBe(true);
            _loginPage.PasswordTextBoxDisplayed().ShouldBe(true);
            _loginPage.SubmitButtonDisplayed().ShouldBe(true);
        }

        private void Login()
        {
            _loginPage.InsertUsername("manager");
            _loginPage.InsertPassword("12345");
            _loginPage.Login();

            _loginPage.WaitForLogin();
        }

    }
}
