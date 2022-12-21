using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel.Tables;

namespace IntegrationTests.IntegrationSeleniumTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/auth/login";

        private IWebElement UsernameTextBox => _driver.FindElement(By.CssSelector("input[name='username']"));
        private IWebElement PasswordTextBox => _driver.FindElement(By.CssSelector("input[name='password']"));
        private IWebElement SubmitButton => _driver.FindElement(By.CssSelector("button[type='submit']"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Ensure Displayed

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return UsernameTextBoxDisplayed() && PasswordTextBoxDisplayed() && SubmitButtonDisplayed();
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

        public bool UsernameTextBoxDisplayed()
        {
            return UsernameTextBox.Displayed;
        }

        public bool PasswordTextBoxDisplayed()
        {
            return PasswordTextBox.Displayed;
        }

        public bool SubmitButtonDisplayed()
        {
            return SubmitButton.Displayed;
        }

        #endregion

        #region Insert Values

        public void InsertUsername(string username)
        {
            UsernameTextBox.SendKeys(username);
        }

        public void InsertPassword(string password)
        {
            PasswordTextBox.SendKeys(password);
        }

        #endregion

        public void Login()
        {
            SubmitButton.Click();
        }

        public void WaitForLogin()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:4200/"));
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
    }
}