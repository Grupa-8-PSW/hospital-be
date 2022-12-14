using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalE2ETests.Pages.Internal
{
    public class HandlingMaliciousUsersPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/malicious-users/block";

        private IWebElement BlockElement => driver.FindElement(By.Name("block"));
        private IWebElement UnblockElement => driver.FindElement(By.Name("unblock"));

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
        public HandlingMaliciousUsersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
