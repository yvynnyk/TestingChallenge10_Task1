using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject10.Framework;
using TestProject10.Pages;
using log4net;

namespace TestProject10.Tests
{
    public class TestBase
    {
        protected IWebDriver Driver;
        protected PageRegistration registrationPage;
        protected ILog Logger;

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
        public void Cleanup()
        {
            ScreenShot.Take(Driver);
            Logger.Info("Test done");
            Driver.Quit();
        }
    }
}
