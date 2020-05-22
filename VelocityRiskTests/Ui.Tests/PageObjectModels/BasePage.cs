using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Ui.Tests.PageObjectModels
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        public string PageUrl;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitForClickable(IWebElement webElement, int timeOut = 20)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior:'auto', block: 'center', inline: 'center'})", element);

            Thread.Sleep(2000);
        }
    }
}
