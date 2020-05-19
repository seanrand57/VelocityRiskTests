using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Ui.Tests.PageObjectModels
{
    public abstract class BasePage
    {
        protected string PageUrl;

        protected readonly IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        // todo: use the same method from BaseSteps class
        public void WaitForClickable(IWebElement webElement, int timeOut = 20)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        // todo: move to BaseSteps class
        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior:'auto', block: 'center', inline: 'center'})", element);

            Thread.Sleep(2000);
        }

        // todo: move to BaseSteps class
        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
