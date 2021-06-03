using OpenQA.Selenium;
using TestProject10.Pages;

namespace TestProject10.Framework
{
    class SiteNavigator
    {
        public static PageRegistration NavigateToRegistrationPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://testingchallenges.thetestingmap.org/challenge10.php");
            return new PageRegistration(driver);
        }

        public static PageLogin NavigateToLoginPage(IWebDriver driver, IWebElement link)
        {
            link.Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            return new PageLogin(driver);
        }
    }
}
