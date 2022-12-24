using IntegrationTests.IntegrationSeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.IntegrationSeleniumTests.Tests
{
    public class CreateTenderTest : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.AllTenders allTendersPage;
        private Pages.CreateTenderPage CreateTenderPage;
        private int tendersCount = 0;

        public CreateTenderTest()
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

            Pages.AllTenders newAllTendersPage = new Pages.AllTenders(driver);
            newAllTendersPage.Navigate();

            newAllTendersPage.EnsurePageIsDisplayed();
            Assert.True(newAllTendersPage.LinkDisplayed());
            tendersCount = newAllTendersPage.TendersCount();
            newAllTendersPage.ClickLink();


            CreateTenderPage = new Pages.CreateTenderPage(driver);
            CreateTenderPage.EnsurePageIsDisplayed();
            
            Assert.Equal(driver.Url, Pages.CreateTenderPage.URI);

            Assert.True(CreateTenderPage.BloodQuantityDisplayed());
            Assert.True(CreateTenderPage.BloodTypeDisplayed());
            Assert.True(CreateTenderPage.FromDateDisplayed());
            Assert.True(CreateTenderPage.ToDateDisplayed());
            Assert.True(CreateTenderPage.SubmitButtonElementDisplayed());



        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestEmptyBloodType()
        {
            CreateTenderPage.InsertBloodType("");
            CreateTenderPage.SubmitForm();
            CreateTenderPage.WaitForAlertDialog();
            Assert.Equal(CreateTenderPage.GetDialogMessage(), Pages.CreateTenderPage.InvalidBloodTypeMessage);
            CreateTenderPage.ResolveAlertDialog();
            Assert.Equal(driver.Url, Pages.CreateTenderPage.URI);

        }

        [Fact]
        public void TestSuccessfulSubmit()
        {
            CreateTenderPage.InsertBloodQuantity("2");
            CreateTenderPage.InsertBloodType("0+");
            CreateTenderPage.InsertFromDate("1016", "2022");

            CreateTenderPage.InsertToDate("1018", "2022");
            CreateTenderPage.SubmitForm();
            CreateTenderPage.WaitForFormSubmit();


            Pages.AllTenders newAllTendersPage = new Pages.AllTenders(driver);
            newAllTendersPage.EnsurePageIsDisplayed();
            Assert.True(newAllTendersPage.LinkDisplayed());

            Assert.Equal(tendersCount + 1, newAllTendersPage.TendersCount());


        }


        [Fact]
        public void NotSuccessfulSubmitWithFromDateMissing()
        {
            CreateTenderPage.InsertBloodQuantity("2");
            CreateTenderPage.InsertBloodType("0+");
            //CreateTenderPage.InsertFromDate("1016", "2022");

            CreateTenderPage.InsertToDate("1018", "2022");
            CreateTenderPage.SubmitForm();
            CreateTenderPage.WaitForFormSubmit2();


            Pages.AllTenders newAllTendersPage = new Pages.AllTenders(driver);

            Assert.True("http://localhost:4200/tenders".Equals(driver.Url));

            int i = 0;
            //Assert.Equal(tendersCount + 1, newAllTendersPage.TendersCount());


        }
    }
}
