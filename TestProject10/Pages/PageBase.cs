using OpenQA.Selenium;

namespace TestProject10.Pages
{
    public class PageBase
    {
        public IWebDriver Driver;

        public PageBase(IWebDriver driver)
        {
            this.Driver = driver;
        }

    }
}
