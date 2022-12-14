using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalTests.HospitalE2ETests.Pages.Internal
{
    public class InternalHomePage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200";

        private IWebElement LoginLink => _driver.FindElement(By.Name("login"));
        private IWebElement HandlingMaliciousPatientsLink => _driver.FindElement(By.Name("malicious"));
        public bool LoginLinkDisplayed()
        {
            return LoginLink.Displayed;
        }
        public bool HandlingMaliciousPatientsLinkDisplayed ()
        {
            return HandlingMaliciousPatientsLink.Displayed;
        }
        public void ClickLoginLink()
        {
            LoginLink.Click();
        }
        public void ClickHandlingMaliciousPatientsLink()
        {
            HandlingMaliciousPatientsLink.Click();
        }

        public InternalHomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
    }
}
