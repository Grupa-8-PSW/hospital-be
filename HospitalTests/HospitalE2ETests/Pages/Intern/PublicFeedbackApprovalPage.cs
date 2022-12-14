using OpenQA.Selenium;

namespace HospitalTests.HospitalE2ETests.Pages.Intern
{
    public class PublicFeedbackApprovalPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/feedback/approval";

        public PublicFeedbackApprovalPage(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}
