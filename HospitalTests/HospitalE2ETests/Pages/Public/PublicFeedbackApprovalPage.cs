using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalE2ETests.Pages.Public
{
    public class PublicFeedbackApprovalPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/createFeedback";
    }
}
