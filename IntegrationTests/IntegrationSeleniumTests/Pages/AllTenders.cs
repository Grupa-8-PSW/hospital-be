using MigraDoc.DocumentObjectModel.Tables;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.IntegrationSeleniumTests.Pages
{
    public class AllTenders
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/allTenders";
        private IWebElement Link => driver.FindElement(By.Id("createTender"));

        private ReadOnlyCollection<IWebElement> Tenders => driver.FindElements(By.Id("offerCard"));

        public AllTenders(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
            wait.Until(condition =>
            {
                try
                {
                    return Tenders.Count > 0;
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

        public void Navigate() => driver.Navigate().GoToUrl(URI);

        public bool LinkDisplayed()
        {
            return Link.Displayed;
        }
        public void ClickLink()
        {
            Link.Click();
        }

        public int TendersCount()
        {
            return Tenders.Count;
        }
    }

}
