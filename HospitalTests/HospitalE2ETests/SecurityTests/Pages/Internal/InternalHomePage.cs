using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalTests.HospitalE2ETests.SecurityTests.Pages.Internal
{
    public class InternalHomePage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/";

        private IWebElement LoginLink => _driver.FindElement(By.Name("login"));
        private IWebElement MaliciousUserLink => _driver.FindElement(By.Name("malicious"));
        public bool LoginLinkDisplayed()
        {
            return LoginLink.Displayed;
        }
        public bool HandlingMaliciousPatientsLinkDisplayed()
        {
               return MaliciousUserLink.Displayed;

        }
        public void ClickLoginLink()
        {
            LoginLink.Click();
        }
       public void ClickHandlingMaliciousPatientsLink()
        {
             MaliciousUserLink.Click();
        }
     
        public InternalHomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);

    }
}
