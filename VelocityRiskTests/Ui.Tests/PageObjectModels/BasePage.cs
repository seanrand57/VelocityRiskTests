using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Ui.Tests.PageObjectModels.Components;

namespace Ui.Tests.PageObjectModels
{
    public class ComponentBasePage
    {
        protected string PageUrl = "https://velocityrisk.com/";

        protected readonly IWebDriver Driver;

        protected MenuBar MenuBar;

        protected Header Header;

        protected Footer Footer;

        protected CookieInfo CookieInfo;

        public ComponentBasePage(IWebDriver driver)
        {
            Driver = driver;

            MenuBar = new MenuBar(driver);
            Header = new Header(driver);
            Footer = new Footer(driver);
            CookieInfo = new CookieInfo(driver);
        }

        public void WaitForClickable(IWebElement webElement, int timeOut = 20)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior:'auto', block: 'center', inline: 'center'})", element);

            Thread.Sleep(2000);
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
