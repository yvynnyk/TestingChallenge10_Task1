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
        private IWebElement UsernameInput => Driver.FindElement(By.XPath("//input[@name='username']"));
        private IWebElement PasswordInput => Driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement FistNameInput => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        private IWebElement LastNameInput => Driver.FindElement(By.XPath("//input[@name='lastname']"));
        private IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        public PageRegistration RegisterUser(string userName, string userPassword, string firstName, string lastName)
        {
                UsernameInput.SendKeys(userName);
                PasswordInput.SendKeys(userPassword);
                FistNameInput.SendKeys(firstName);
                LastNameInput.SendKeys(lastName);
                SubmitButton.Click();
            return new PageRegistration(Driver);
        }
        private WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        private IWebElement Table => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
        private int Rows => Table.FindElements(By.TagName("tr")).Count;
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
        public IWebElement ApplicationLink => Driver.FindElement(By.XPath("//a[text()='link']"));

    }
}
