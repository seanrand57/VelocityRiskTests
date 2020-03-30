using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace VelocityRisk.DataModels.PageObjectModels
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void WaitForClickable(IWebElement webElement, int timeOut = 20)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));                     
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior:'auto', block: 'center', inline: 'center'})", element);
            // Thread.sleep() is used here to wait for Js scrollIntoView() finishes
            // Looking for a more stable solution
            Thread.Sleep(2000);
        }
    }
}
