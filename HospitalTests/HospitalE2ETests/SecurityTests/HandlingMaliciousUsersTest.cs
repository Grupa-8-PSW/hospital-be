using HospitalTests.HospitalE2ETests.Pages.Public;
using HospitalTests.HospitalE2ETests.SecurityTests.Pages.Internal;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalE2ETests.SecurityTests
{
    public class HandlingMaliciousUsersTest : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly InternalHomePage _homePage;
        private readonly InternalLoginPage _loginPage;
        private readonly HandlingMaliciousUsersPage _handlingMaliciousUsersPage;
        public HandlingMaliciousUsersTest()
        {
            var options = CreateChromeOptions();

            _driver = new ChromeDriver(options);

            _homePage = new InternalHomePage(_driver);

            _homePage.Navigate();
            _homePage.LoginLinkDisplayed().ShouldBe(true);
            _homePage.ClickLoginLink();

            _loginPage = new InternalLoginPage(_driver);
            _driver.Url.ShouldBe(InternalLoginPage.URI);
            _loginPage.UsernameElementDisplayed().ShouldBe(true);
            _loginPage.PasswordElementDisplayed().ShouldBe(true);
            _loginPage.SubmitButtonElementDisplayed().ShouldBe(true);
            Login();

             _driver.Url.ShouldBe(InternalHomePage.URI);
             _homePage.ClickHandlingMaliciousPatientsLink();

            _handlingMaliciousUsersPage = new HandlingMaliciousUsersPage(_driver);
            _driver.Url.ShouldBe(HandlingMaliciousUsersPage.URI);
            _handlingMaliciousUsersPage.BlockElementDisplayed().ShouldBe(true);
            _handlingMaliciousUsersPage.UnBlockElementDisplayed().ShouldBe(true);
        }
        private void Login()
        {
            _loginPage.InsertUsername("manager");
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
        public void ValidBlock()
        {
            _handlingMaliciousUsersPage.ClickBlockElement();
            Assert.True(_handlingMaliciousUsersPage.GetBlockButtonState());
            Assert.Equal(_handlingMaliciousUsersPage.GetValidMessage1(), HandlingMaliciousUsersPage.ValidMessage1);
        }
        [Fact]
        public void ValidUnblock()
        {
            _handlingMaliciousUsersPage.ClickBlockElement();
            Assert.True(_handlingMaliciousUsersPage.GetUnblockButtonState());
            Assert.Equal(_handlingMaliciousUsersPage.GetValidMessage2(), HandlingMaliciousUsersPage.ValidMessage2);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
