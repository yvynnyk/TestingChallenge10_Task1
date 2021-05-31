using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject10.Pages
{
    public class PageRegistration : PageBase
    {
        public PageRegistration(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement usernameInput => Driver.FindElement(By.XPath("//input[@name='username']"));
        private IWebElement passwordInput => Driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement fistNameInput => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        private IWebElement lastNameInput => Driver.FindElement(By.XPath("//input[@name='lastname']"));
        private IWebElement submitButton => Driver.FindElement(By.XPath("//input[@type='submit']"));

        public PageRegistration RegisterUser(string userName, string userPassword, string firstName, string lastName)
        {
                usernameInput.SendKeys(userName);
                passwordInput.SendKeys(userPassword);
                fistNameInput.SendKeys(firstName);
                lastNameInput.SendKeys(lastName);
                submitButton.Click();
            return new PageRegistration(Driver);
        }
        private WebDriverWait wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        private IWebElement table => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
        private int Rows => table.FindElements(By.TagName("tr")).Count;
        public string GetNameFromTable()
        {
            return Driver.FindElement(By.XPath($"//tbody//tr[{Rows}]//th[2]")).Text;
        }
        public string GetPasswordFromTable()
        {
            return Driver.FindElement(By.XPath($"//tbody//tr[{Rows}]//th[3]")).Text;
        }
        public string GetFirstNameFromTable()
        {
            return Driver.FindElement(By.XPath($"//tbody//tr[{Rows}]//th[4]")).Text;
        }
        public string GetLastNameFromTable()
        {
            return Driver.FindElement(By.XPath($"//tbody//tr[{Rows}]//th[5]")).Text;
        }

    }
}
