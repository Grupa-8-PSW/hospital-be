using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V106.DOMSnapshot;

namespace HospitalTests.HospitalE2ETests.RenovateRoomTests.Pages
{
    public class RoomPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/map/floor/rooms/1";

        private IWebElement Room => _driver.FindElement(By.ClassName("canvas"));
        private IWebElement StartRenovateButton => _driver.FindElement(By.ClassName("renovateButton"));
        private IWebElement MergeRoomButton => _driver.FindElement(By.ClassName("buttonsRenovate"));
        private IWebElement SeparateRoomButton => _driver.FindElement(By.ClassName("buttonsRenovate2"));

        private IWebElement NextButton => _driver.FindElement(By.ClassName("nextButton"));

        //private IWebElement ChoseRoom1Button => _driver.FindElement(By.ClassName("roomDestination"));
        //private IWebElement ChoseRoom2Button => _driver.FindElement(By.ClassName("roomDestination2"));

        public RoomPage(IWebDriver driver)
        {
            _driver = driver;
        }

         public void EnsurePageIsDisplayed()
    {
       
        /*var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        wait.Until(condition =>
        {
            try
            {
                return ;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }); */
    }

        #region Ensure Displayed

        public bool RoomDisplayed()
        {
            return Room.Displayed;
        }

        #endregion

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(URI);
        }

        public void ClickButton()
        {
            StartRenovateButton.Click();
        }
        public bool ButtonDisplayed()
        {
            return StartRenovateButton.Displayed;
        }

        public void ClickMergeButton()
        {
            MergeRoomButton.Click();
        }

        public bool ButtonMergeDisplayed()
        {
            return MergeRoomButton.Displayed;
        }
        public void ClickSeparateButton()
        {
            SeparateRoomButton.Click();
        }

        public bool ButtonSeparateDisplayed()
        {
            return SeparateRoomButton.Displayed;
        }


        /*  public void ClickNextButton()
         {
             NextButton.Click();
         }

         public bool ButtonNextDisplayed()
         {
             return NextButton.Displayed;
         }
       public void ClickChoseRoom1Button()
         {
             ChoseRoom1Button.Click();
         }

         public bool ButtonChoseRoom1Displayed()
         {
             return ChoseRoom1Button.Displayed;
         }
         public void ClickChoseRoom2Button()
         {
             ChoseRoom2Button.Click();
         }

         public bool ButtonChoseRoom2Displayed()
         {
             return ChoseRoom2Button.Displayed;
         }*/
    }
}
