using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationTests.IntegrationSeleniumTests.Pages;
using Xunit;

namespace IntegrationTests.IntegrationSeleniumTests.Tests
{


    public class CreateBloodBankTest : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.ManagerPage managerPage;
        private Pages.CreateBloodBankPage createBloodBankPage;
        private Pages.LoginPage loginPage;
        private int bloodBanksCount = 0;

        public CreateBloodBankTest()
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

            loginPage.Navigate();
            loginPage.EnsurePageIsDisplayed();
            loginPage.InsertUsername("manager");
            loginPage.InsertPassword("12345");
            loginPage.Login();
            loginPage.WaitForLogin();


            Pages.ManagerPage newManagerPage = new Pages.ManagerPage(driver);
            newManagerPage.Navigate();
            newManagerPage.EnsurePageIsDisplayed();
            Assert.True(newManagerPage.LinkDisplayed());
            bloodBanksCount = newManagerPage.BloodBanksCount();
            newManagerPage.ClickLink();


            createBloodBankPage = new Pages.CreateBloodBankPage(driver);
            createBloodBankPage.EnsurePageIsDisplayed();
            Assert.Equal(driver.Url, Pages.CreateBloodBankPage.URI);

            Assert.True(createBloodBankPage.EmailElementDisplayed());
            Assert.True(createBloodBankPage.NameElementDisplayed());
            Assert.True(createBloodBankPage.ServerAddressDisplayed());
            Assert.True(createBloodBankPage.SubmitButtonElementDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestInvalidEmail()
        {
            createBloodBankPage.InsertName("Banka");
            createBloodBankPage.InsertServerAddress("adresa.com");
            createBloodBankPage.SubmitForm();

            createBloodBankPage.WaitForAlertDialog();
            Assert.Equal(createBloodBankPage.GetDialogMessage(), Pages.CreateBloodBankPage.InvalidEmailMessage);
            createBloodBankPage.ResolveAlertDialog();
            Assert.Equal(driver.Url, Pages.CreateBloodBankPage.URI);
        }

        [Fact]
        public void TestInvalidFormatEmail()
        {
            createBloodBankPage.InsertEmail("email");
            createBloodBankPage.InsertName("Banka");
            createBloodBankPage.InsertServerAddress("adresa.com");
            createBloodBankPage.SubmitForm();

            createBloodBankPage.WaitForAlertDialog();
            Assert.Equal(createBloodBankPage.GetDialogMessage(), Pages.CreateBloodBankPage.InvalidFormatEmailMessage);
            createBloodBankPage.ResolveAlertDialog();
            Assert.Equal(driver.Url, Pages.CreateBloodBankPage.URI);
        }

        [Fact]
        public void TestInvalidName()
        {
            createBloodBankPage.InsertEmail("email@mail.com");
            createBloodBankPage.InsertServerAddress("adresa.com");
            createBloodBankPage.SubmitForm();

            createBloodBankPage.WaitForAlertDialog();
            Assert.Equal(createBloodBankPage.GetDialogMessage(), Pages.CreateBloodBankPage.InvalidNameMessage);
            createBloodBankPage.ResolveAlertDialog();
            Assert.Equal(driver.Url, Pages.CreateBloodBankPage.URI);
        }

        [Fact]
        public void TestInvalidServerAddress()
        {
            createBloodBankPage.InsertEmail("email@mail.com");
            createBloodBankPage.InsertName("Banka");
            createBloodBankPage.SubmitForm();

            createBloodBankPage.WaitForAlertDialog();
            Assert.Equal(createBloodBankPage.GetDialogMessage(), Pages.CreateBloodBankPage.InvalidServerAddressMessage);
            createBloodBankPage.ResolveAlertDialog();
            Assert.Equal(driver.Url, Pages.CreateBloodBankPage.URI);
        }

        [Fact]
        public void TestSuccessfulSubmit()
        {

            createBloodBankPage.InsertEmail("email@mail.com");
            createBloodBankPage.InsertName("Banka");
            createBloodBankPage.InsertServerAddress("adresa.com");
            createBloodBankPage.SubmitForm();
            createBloodBankPage.WaitForAlertDialog();
            Assert.Equal(createBloodBankPage.GetDialogMessage(), Pages.CreateBloodBankPage.CreatedBloodBankMessage);
            createBloodBankPage.ResolveAlertDialog();
            createBloodBankPage.WaitForFormSubmit();

            Pages.ManagerPage newManagerPage = new Pages.ManagerPage(driver);
            newManagerPage.EnsurePageIsDisplayed();
            Assert.True(newManagerPage.LinkDisplayed());

            Assert.Equal(bloodBanksCount + 1, newManagerPage.BloodBanksCount());
            Assert.Equal("email@mail.com", newManagerPage.GetLastRowEmail());
            Assert.Equal("Banka", newManagerPage.GetLastRowName());
            Assert.Equal("adresa.com", newManagerPage.GetLastRowServerAddress());



        }
    }
}