using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject10.Framework;
using TestProject10.Pages;
using log4net;
using NUnit.Framework.Interfaces;
using System.IO;
using System;

namespace TestProject10.Tests
{
    public class TestBase
    {
        protected IWebDriver Driver;
        protected PageRegistration registrationPage;
        protected ILog Logger;

        //[OneTimeSetUp]
        [SetUp]
        public void Setup()
        {
            Logger = LogManager.GetLogger(GetType());
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            registrationPage = SiteNavigator.NavigateToRegistrationPage(Driver);
            Logger.Info("Test started");
        }

        [TearDown]
        public void TakeScreenShoot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                string screenName = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                string screenShotFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots") + screenName + ".png";
                screenshot.SaveAsFile(screenShotFileName, ScreenshotImageFormat.Png);
            }
        }
        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}
