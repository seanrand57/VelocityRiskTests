using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Linq;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;
using Ui.Tests.Resources;

namespace Ui.Tests.Steps
{
    public class BaseSteps
    {
        protected IWebDriver Driver;
        protected int TabsCount;

        protected MenuBar MenuBar;

        public BaseSteps(IWebDriver driver)
        {
            Driver = driver;

            MenuBar = new MenuBar(Driver);
        }

        public void GoToHomePage()
        {
            var homePage = new HomePage(Driver);
            homePage.NavigateTo();
        }

        public void VerifyProtocolIsHttps()
        {
            Driver.Url.Split(':')[0].ShouldBe("https", ShouldlyCustomMessages.ProtocolShouldBeHttps);
        }

        protected void VerifyNewTabIsOpened()
        {
            var afterTabsCount = Driver.WindowHandles.Count;
            (afterTabsCount == TabsCount + 1).ShouldBeTrue(ShouldlyCustomMessages.LinkShouldBeOpenedInNewTab);
        }

        protected void SetCurrentTabsCount()
        {
            TabsCount = Driver.WindowHandles.Count;
        }

        //protected IWebElement WaitUntilElementIsVisible(By locator, int timeOut = 10)
        //{
        //    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
        //    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        //    return element;
        //}

        public void WaitUntilElementIsVisible(IWebElement element, int timeout = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        protected void MouseHoverToElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        protected void SwitchToNewOpenedTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        protected void SwitchBackToDefaultTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }

        protected IWebElement WaitForClickable(IWebElement webElement, int timeOut = 20)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
            return element;
        }
    }
}
