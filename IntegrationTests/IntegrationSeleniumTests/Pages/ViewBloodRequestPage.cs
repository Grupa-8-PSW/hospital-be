using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace IntegrationTests.IntegrationSeleniumTests.Pages
{
    public class ViewBloodRequestPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/view/bloodRequest";

        private IWebElement Table => driver.FindElement(By.TagName("table"));
        private IReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table/tbody/tr"));

        private IWebElement FirstRow => driver.FindElement(By.XPath("//table/tbody/tr[first()]"));

        private IWebElement ApproveButton => driver.FindElements(By.Name("approve")).ElementAt(0);

        private IWebElement RejectButton => driver.FindElements(By.Name("reject")).ElementAt(0);

        private IWebElement UnclearButton => driver.FindElements(By.Name("unclear")).ElementAt(0);

        private IWebElement TextArea => driver.FindElement(By.Id("myArea"));

        private IWebElement ReturnBackButton => driver.FindElement(By.Id("returnBack"));

        private IWebElement CancelButton => driver.FindElement(By.Id("cancel"));

        private IWebElement Link => driver.FindElement(By.Id("viewRequests"));

        public ViewBloodRequestPage(IWebDriver driver)
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

        public void ClickLink()
        {
            Link.Click();
        }

        public bool ButtonsDisplayed()
        {
            return ApproveButton.Displayed && RejectButton.Displayed && UnclearButton.Displayed;
        }

        public bool ButtonsDisplayed2()
        {
            return ReturnBackButton.Displayed && CancelButton.Displayed;
        }

        public bool TextAreaDiplayed()
        {
            return TextArea.Displayed;
        }

        public void InsertReason(string reason)
        {
            TextArea.SendKeys(reason);
        }

        public void Cancel()
        {
            CancelButton.Click();
        }

        public void ReturnBack()
        {
            ReturnBackButton.Click();
        }

        public void Approve()
        {
            ApproveButton.Click();
        }

        public void Reject()
        {
            RejectButton.Click();
        }

        public void Unclear()
        {
            UnclearButton.Click();
        }

        public int RowsCount()
        {
            return Rows.Count;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
