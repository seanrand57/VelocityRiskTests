using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using VelocityRiskTests.DataModels.PageObjectModels.Components;

namespace VelocityRiskTests.DataModels.PageObjectModels
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        [FindsBy(How = How.Id, Using = "site-navigation")]
        protected MenuBar MenuBar;

        [FindsBy(How = How.ClassName, Using = "header_white")]
        protected Header Header;

        [FindsBy(How = How.ClassName, Using = "bottom_part")]
        protected Footer Footer;

        [FindsBy(How = How.Id, Using = "cookie-law-info-bar")]
        protected CookieInfo CookieInfo;

        public BasePage(IWebDriver driver)
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
    }
}
