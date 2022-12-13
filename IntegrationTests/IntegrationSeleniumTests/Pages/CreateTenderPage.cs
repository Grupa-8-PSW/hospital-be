using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.IntegrationSeleniumTests.Pages
{
    public class CreateTenderPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/tenders";

        private IWebElement FromDate => driver.FindElement(By.Id("d1"));
        private IWebElement ToDate => driver.FindElement(By.Id("d2"));
        private IWebElement BloodType => driver.FindElement(By.Id("bloodGroup"));
        private IWebElement BloodQuantity => driver.FindElement(By.Id("quant"));

        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("submit"));


        public const string InvalidFromDateMessage = "Start is null";
        public const string InvalidBloodTypeMessage = "Type is empty!";



        public CreateTenderPage(IWebDriver driver)
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
                    return FromDateDisplayed() || ToDateDisplayed() || BloodTypeDisplayed() || BloodQuantityDisplayed() || SubmitButtonElementDisplayed();
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

        public bool FromDateDisplayed()
        {
            return FromDate.Displayed;
        }

        public bool ToDateDisplayed()
        {
            return ToDate.Displayed;
        }

        public bool BloodTypeDisplayed()
        {
            return BloodType.Displayed;
        }

        public bool BloodQuantityDisplayed()
        {
            return BloodQuantity.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }


        public void InsertFromDate(String dayAndMonth, String year)
        {
            FromDate.SendKeys(dayAndMonth);
            FromDate.SendKeys(Keys.Tab);
            FromDate.SendKeys(year);

        }

        public void InsertToDate(String dayAndMonth, String year)
        {
            ToDate.SendKeys(dayAndMonth);
            ToDate.SendKeys(Keys.Tab);
            ToDate.SendKeys(year);


        }
        public void InsertBloodType(String tip)
        {
            BloodType.SendKeys(tip);
        }

        public void InsertBloodQuantity(String q)
        {
            BloodQuantity.SendKeys(q);
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

           wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(AllTenders.URI));
        }
    }
}
