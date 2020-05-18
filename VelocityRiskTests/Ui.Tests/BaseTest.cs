using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Ui.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [OneTimeSetUp]
        public void BaseSetUp()
        {
            Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void BaseTearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        protected void WaitUntilElementIsVisible(By locator, int secondsToWait = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsToWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected void MouseHoverToElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        protected IWebElement GetElemetByLocator(By locator)
        {
            var element = Driver.FindElement(locator);
            return element;
        }

        protected void ClickOnElementByLocator(By locator)
        {
            var element = GetElemetByLocator(locator);
            element.Click();
        }

        protected bool IsLinkOpenedOnNewTab(int beforeTabsCount)
        {
            var afterTabsCount = Driver.WindowHandles.Count;
            return afterTabsCount == beforeTabsCount + 1;
        }

        protected void SwitchToNewOpenedTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }
    }
}