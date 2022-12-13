using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using IntegrationTests.IntegrationSeleniumTests.Pages;

namespace IntegrationTests.IntegrationSeleniumTests.Tests
{
    public class CheckForBloodTypeTest : IDisposable
    {
        private readonly IWebDriver driver;
        Pages.CheckForBloodTypePage checkForBloodTypePage;

        public CheckForBloodTypeTest()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);

            checkForBloodTypePage = new Pages.CheckForBloodTypePage(driver);
            checkForBloodTypePage.Navigate();
            checkForBloodTypePage.EnsurePageIsDisplayed();
            checkForBloodTypePage.OpenDialog();
            Assert.True(checkForBloodTypePage.ButtonDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestInvalidBloodAmount()
        {
            checkForBloodTypePage.SelectComboValue("A+");
            checkForBloodTypePage.InsertAmount("-1");
            checkForBloodTypePage.Submit();
            checkForBloodTypePage.WaitForAlertDialog();
            Assert.Equal(checkForBloodTypePage.GetDialogMessage(), Pages.CheckForBloodTypePage.InvalidBloodAmountMessage);
        }

        [Fact]
        public void TestInvalidBloodType()
        {
            checkForBloodTypePage.InsertAmount("10");
            checkForBloodTypePage.Submit();
            checkForBloodTypePage.WaitForAlertDialog();
            Assert.Equal(checkForBloodTypePage.GetDialogMessage(), Pages.CheckForBloodTypePage.InvalidBloodTypeMessage);
        }

        [Fact]
        public void TestSuccessfulChecking()
        {
            //Mora isa server da radi da bi prosao test
            checkForBloodTypePage.SelectComboValue("A+");
            checkForBloodTypePage.InsertAmount("10");
            checkForBloodTypePage.Submit();
            checkForBloodTypePage.WaitForAlertDialog();
            Assert.Equal(checkForBloodTypePage.GetDialogMessage(), Pages.CheckForBloodTypePage.SuccessfulChekingMessage);
        }

    }
}
