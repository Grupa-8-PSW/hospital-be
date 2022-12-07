using MigraDoc.DocumentObjectModel.Shapes.Charts;
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
    public class CheckForBloodTypePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/bloodBanks/add";

        private IWebElement BloodTypeOptions => driver.FindElement(By.Name("bloodTypeSelect"));

        private IWebElement BloodQuantityElement => driver.FindElement(By.Name("quantity"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='bloodBanksTable']/tbody/tr"));
        private IWebElement CheckButton => driver.FindElement(By.XPath("//table[@id='bloodBanksTable']/tbody/tr[last()]/td[4]"));

        private IWebElement SubmitButton => driver.FindElement(By.Name("submit"));

        public const string InvalidBloodTypeMessage = "Blood Type is Empty.";
        public const string InvalidBloodAmountMessage = "Amount can't be negative!";
        public const string SuccessfulChekingMessage = "Blood amount checking successful!";


        public CheckForBloodTypePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
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


        public void OpenDialog()
        {
            CheckButton.Click();
        }

        public bool ButtonDisplayed()
        {
            return CheckButton.Displayed;
        }

        public void InsertAmount(string amount)
        {
            BloodQuantityElement.SendKeys(amount);
        }

        public void Submit()
        {
            SubmitButton.Click();
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

        public void SelectComboValue(string value)
        {
            BloodTypeOptions.Click();
            driver.FindElement(By.Name(value)).Click();

        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }

}
