using HospitalTests.HospitalE2ETests.Pages;
using HospitalTests.HospitalE2ETests.RenovateRoomTests.Pages;
using HospitalTests.HospitalE2ETests.ScheduleExaminationTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;

namespace HospitalTests.HospitalE2ETests.RenovateRoomTests;

public class RenovateRoomTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly RoomPage _roomPage;
  
    public RenovateRoomTests()
    {
        var options = CreateChromeOptions();

        _driver = new ChromeDriver(options);

        _roomPage = new RoomPage(_driver);
        _roomPage.Navigate();
        _roomPage.ClickButton();
        _roomPage.ClickMergeButton();
        _roomPage.ClickSeparateButton();
      //  _roomPage.ClickNextButton();
      //  _roomPage.ClickChoseRoom1Button();
       // _roomPage.ClickChoseRoom2Button();

    }

    private static ChromeOptions CreateChromeOptions()
    {
        // options for launching Google Chrome
        var options = new ChromeOptions();
        options.AddArguments("start-maximized"); // open Browser in maximized mode
        options.AddArguments("disable-infobars"); // disabling infobars
        options.AddArguments("--disable-extensions"); // disabling extensions
        options.AddArguments("--disable-gpu"); // applicable to windows os only
        options.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
        options.AddArguments("--no-sandbox"); // Bypass OS security model
        options.AddArguments("--disable-notifications"); // disable notifications

        return options;
    }

    [Fact]
    public void MergingRoom()
    {
        _driver.Url.ShouldBe(RoomPage.URI);
        _roomPage.RoomDisplayed().ShouldBe(true);
        _roomPage.ButtonDisplayed().ShouldBe(true);
        _roomPage.ButtonMergeDisplayed().ShouldBe(true);
       // _roomPage.ButtonNextDisplayed().ShouldBe(true);
      //  _roomPage.ButtonChoseRoom1Displayed().ShouldBe(true);
        //_roomPage.ButtonChoseRoom2Displayed().ShouldBe(true);
    }

    [Fact]
    public void SeparatingRoom()
    {
        _driver.Url.ShouldBe(RoomPage.URI);
        _roomPage.RoomDisplayed().ShouldBe(true);
        _roomPage.ButtonDisplayed().ShouldBe(true);
        _roomPage.ButtonSeparateDisplayed().ShouldBe(true);
        // _roomPage.ButtonNextDisplayed().ShouldBe(true);
        //  _roomPage.ButtonChoseRoom1Displayed().ShouldBe(true);
    }
 
    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }


}