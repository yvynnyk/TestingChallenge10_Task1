using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace TestProject10.Pages
{
    public class PageLogin : PageBase
    {
        public PageLogin(IWebDriver driver) : base(driver)
        {
        }
        private WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        IWebElement UserName => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
        IWebElement UserPassword => Driver.FindElement(By.XPath("//input[@name='password']"));
        IWebElement ButtonLogin => Driver.FindElement(By.XPath("//button[@type='submit']"));
        
        public PageHome Login(string name, string password)
        {
            UserName.SendKeys(name);
            UserPassword.SendKeys(password);
            ButtonLogin.Click();
            return new PageHome(Driver);
        }
    }
}
