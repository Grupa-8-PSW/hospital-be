using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IntegrationTests.IntegrationSeleniumTests.Pages
{
    public class ManagerPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/bloodBanks";

        private IWebElement Table => driver.FindElement(By.Id("bloodBanksTable"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='bloodBanksTable']/tbody/tr"));

        private IWebElement LastRowName => driver.FindElement(By.XPath("//table[@id='bloodBanksTable']/tbody/tr[last()]/td[1]"));
        private IWebElement LastRowEmail => driver.FindElement(By.XPath("//table[@id='bloodBanksTable']/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowServerAddress => driver.FindElement(By.XPath("//table[@id='bloodBanksTable']/tbody/tr[last()]/td[3]"));
        private IWebElement Link => driver.FindElement(By.Id("createBloodBanks"));

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 0;
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
        public bool LinkDisplayed()
        {
            return Link.Displayed;
        }
        public void ClickLink()
        {
            Link.Click();
        }

        public ManagerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int BloodBanksCount()
        {
            return Rows.Count;
        }

        public string GetLastRowName()
        {
            return LastRowName.Text;
        }

        public string GetLastRowServerAddress()
        {
            return LastRowServerAddress.Text;
        }

        public string GetLastRowEmail()
        {
            return LastRowEmail.Text;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
