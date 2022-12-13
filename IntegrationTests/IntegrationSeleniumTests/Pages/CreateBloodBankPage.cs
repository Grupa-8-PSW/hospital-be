using MigraDoc.DocumentObjectModel.Tables;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.IntegrationSeleniumTests.Pages
{
    public class CreateBloodBankPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/bloodBanks/add";

        private IWebElement BloodTypeElement => driver.FindElement(By.Name("bloodTypeSelect"));
        private IWebElement BloodQuantityElement => driver.FindElement(By.Name("quantity"));
        
        public const string InvalidEmailMessage = "Email is Null/Empty/WhiteSpace.";
        public const string InvalidFormatEmailMessage = "Email is invalid.";
        public const string InvalidNameMessage = "Name is Null/Empty/WhiteSpace.";
        public const string InvalidServerAddressMessage = "ServerAddress is Null/Empty/WhiteSpace.";
        public const string CreatedBloodBankMessage = "Registration success!";

        public CreateBloodBankPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return EmailElementDisplayed() || NameElementDisplayed() || ServerAddressDisplayed();
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

        public bool EmailElementDisplayed()
        {
            return EmailElement.Displayed;
        }

        public bool NameElementDisplayed()
        {
            return NameElement.Displayed;
        }

        public bool ServerAddressDisplayed()
        {
            return ServerAddressElement.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public void InsertName(string name)
        {
            NameElement.SendKeys(name);
        }

        public void InsertEmail(string email)
        {
            EmailElement.SendKeys(email);
        }

        public void InsertServerAddress(string serverAddress)
        {
            ServerAddressElement.SendKeys(serverAddress);
        }

        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetDialogMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }

        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void WaitForFormSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(ManagerPage.URI));
        }
    }
}
