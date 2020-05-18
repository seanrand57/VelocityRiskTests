using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Linq;
using Ui.Tests.PageObjectModels;

namespace Ui.Tests.Steps
{
    public abstract class BaseSteps
    {
        protected IWebDriver Driver;
        protected int TabsCount;

        public BaseSteps(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GoToBasePage()
        {
            var basePage = new BasePage(Driver);
            basePage.NavigateTo();
        }

        public void VerifyProtocolIsHttps()
        {
            Driver.Url.Split(':')[0].ShouldBe("https");
        }

        protected void SetCurrentTabsCount()
        {
            TabsCount = Driver.WindowHandles.Count;
        }

        protected IWebElement WaitUntilElementIsVisible(By locator, int timeOut = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        protected void MouseHoverToElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        protected bool IsLinkOpenedOnNewTab()
        {
            var afterTabsCount = Driver.WindowHandles.Count;
            return afterTabsCount == TabsCount + 1;
        }

        protected void SwitchToNewOpenedTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        protected IWebElement WaitForClickable(IWebElement webElement, int timeOut = 20)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
            return element;
        }
    }
}
