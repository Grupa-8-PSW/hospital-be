using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalE2ETests.Pages.Public
{
    public class ViewAppointmentsPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/appointments";

        private IReadOnlyCollection<IWebElement> Rows =>
        _driver.FindElements(By.CssSelector("table[id='upcomingAppointmentsTable'] tbody tr"));

        private IWebElement CancelButton;

        public const string ValidMessage = "Appointment successfully cancelled.";

        public bool CancelButtonDisplayed()
        {
            return CancelButton.Displayed;
        }

        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        public string GetValidMessage()
        {
            return ValidMessage;
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

        public ViewAppointmentsPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    if (Rows.Count > 0)
                    {
                        CancelButton = _driver.FindElement(By.Id((Rows.Count() - 1).ToString()));
                    }

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

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
    }
}
