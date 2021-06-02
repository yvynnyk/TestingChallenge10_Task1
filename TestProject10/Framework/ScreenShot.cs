using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using System.IO;
using System;

namespace TestProject10.Framework
{
    class ScreenShot
    {
        public static void Take(IWebDriver Driver)
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                string screenName = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                string screenShotFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots") + screenName + ".png";
                screenshot.SaveAsFile(screenShotFileName, ScreenshotImageFormat.Png);
            }
        }
    }
}
