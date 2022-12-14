using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationTests.IntegrationSeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace IntegrationTests.IntegrationSeleniumTests.Tests
{
    public class ProccessBloodUnitRequestsTest : IDisposable
    {

        private readonly IWebDriver driver;
        private Pages.ViewBloodRequestPage viewBloodRequestsPage;
        private Pages.LoginPage loginPage;
        private int RowsCount;

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        public ProccessBloodUnitRequestsTest()
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

            loginPage = new Pages.LoginPage(driver);
            viewBloodRequestsPage = new Pages.ViewBloodRequestPage(driver);

            loginPage.Navigate();
            loginPage.EnsurePageIsDisplayed();
            loginPage.InsertUsername("manager");
            loginPage.InsertPassword("12345");
            loginPage.Login();
            loginPage.WaitForLogin();

            viewBloodRequestsPage.Navigate();
            viewBloodRequestsPage.EnsurePageIsDisplayed();
            RowsCount = viewBloodRequestsPage.RowsCount();
            Assert.True(viewBloodRequestsPage.ButtonsDisplayed());
        }

        [Fact]
        public void TestApprove()
        {
            viewBloodRequestsPage.Approve();
            viewBloodRequestsPage.WaitForTableUpdate();
            Assert.Equal(RowsCount - 1, viewBloodRequestsPage.RowsCount());
        }

        [Fact]
        public void TestReject()
        {
            viewBloodRequestsPage.Reject();
            viewBloodRequestsPage.WaitForTableUpdate();
            Assert.Equal(RowsCount - 1, viewBloodRequestsPage.RowsCount());
        }

        [Fact]
        public void TestUnclear()
        {
            viewBloodRequestsPage.Unclear();
            viewBloodRequestsPage.InsertReason("gas");
            viewBloodRequestsPage.ReturnBack();
            viewBloodRequestsPage.WaitForTableUpdate();
            Assert.Equal(RowsCount - 1, viewBloodRequestsPage.RowsCount());
        }

        [Fact]
        public void TestUnclearCancel()
        {
            viewBloodRequestsPage.Unclear();
            viewBloodRequestsPage.Cancel();
            Pages.ViewBloodRequestPage newViewBloodRequestPage = new ViewBloodRequestPage(driver);
            Assert.Equal(RowsCount, newViewBloodRequestPage.RowsCount());
        }

    }
}
