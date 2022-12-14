using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalE2ETests.SecurityTests.Pages.Internal
{
    public class HandlingMaliciousUsersPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/malicious-users/block";
        private IReadOnlyCollection<IWebElement> BlockTable => _driver.FindElements(By.Name("blockTable"));
        private IReadOnlyCollection<IWebElement> UnblockTable => _driver.FindElements(By.Name("unblockTable"));

        private IWebElement BlockElement;

        private IWebElement UnblockElement;

        public const string ValidMessage1 = "Patient successfuly blocked.";

        public const string ValidMessage2 = "Patient successfuly unblocked.";

        public const string ErrorMesage = "Error.";
        public bool BlockElementDisplayed()
        {
             return BlockElement.Displayed;
        }
        public void ClickBlockElement()
        {
            BlockElement.Click();
        }
        public bool UnBlockElementDisplayed()
        {
            return UnblockElement.Displayed;
        }
        public void ClickUnblockElement()
        {
            UnblockElement.Click();
        }
        public bool GetBlockButtonState()
        {
            return BlockElement.Enabled;
        }
        public bool GetUnblockButtonState()
        {
            return UnblockElement.Enabled;
        }
        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetDialogMessage()
        {
            return _driver.SwitchTo().Alert().Text;
        }

        public void ResolveAlertDialog()
        {
            _driver.SwitchTo().Alert().Accept();
        }
        public string GetValidMessage1()
        {
            return ValidMessage1;
        }
        public string GetValidMessage2()
        {
            return ValidMessage2;
        }
        public HandlingMaliciousUsersPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    if (BlockTable.Count>0 && UnblockTable.Count>0)
                    {
                        BlockElement = _driver.FindElement(By.Name("blockButton"));
                        UnblockElement = _driver.FindElement(By.Name("unblockButton"));
                    }
                    return BlockTable.Count()>0;
                  
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

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
    }
}
