using OpenQA.Selenium;

namespace TestProject10.Pages
{
    public class PageHome : PageBase
    {
        public PageHome(IWebDriver driver) : base(driver)
        { 
        }
        private IWebElement Header => Driver.FindElement(By.TagName("h1"));
        public string GetHeader()
        {
            return Header.Text;
        }
    }
}
