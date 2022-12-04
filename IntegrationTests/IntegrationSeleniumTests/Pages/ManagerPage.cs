using System;
using System.Collections.Generic;
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

        private IWebElement Link => driver.FindElement(By.Id("createBloodBanks"));

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return LinkDisplayed();
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

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
