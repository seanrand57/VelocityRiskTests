using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Linq;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;

namespace Ui.Tests.Steps
{
    public class BaseSteps<TPage> where TPage : BasePage
    {
        protected IWebDriver Driver;

        protected TPage Page;

        protected MenuBar MenuBar;

        public BaseSteps(IWebDriver driver)
        {
            Driver = driver;

            MenuBar = new MenuBar(Driver);
        }

        private void NavigateToHomePage()
        {
            var homePage = new HomePage(Driver);
            Driver.Navigate().GoToUrl(homePage.PageUrl);
        }

        public virtual void NavigateTo()
        {
            if (Page == null)
            {
                NavigateToHomePage();
            }
            else
            {
                SwitchBackToDefaultTab();
                Driver.Navigate().GoToUrl(Page.PageUrl);
            }
        }

        public void VerifyPageUrl(string expectedUrl, string additionalMessage = "")
        {
            Driver.Url.ShouldContain(expectedUrl, $"Url of the current tab should be: '{expectedUrl}'. {additionalMessage}");
        }

        public void VerifyRedirectedToHttps()
        {
            Driver.Url.Split(':')[0].ShouldBe("https", "Url of the current tab should be under HTTPS protocol");
        }

        public int GetCurrentTabsCount()
        {
            return Driver.WindowHandles.Count;
        }

        public void VerifyNewTabIsOpened(int tabsCountBefore)
        {
            GetCurrentTabsCount().ShouldBe(tabsCountBefore + 1, "Link should be opened in new tab");
        }

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

        public void MouseHoverToElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        public void SwitchToLastOpenedTab()
        {
            SwitchToTabByItsName(Driver.WindowHandles.Last());
        }

        public void SwitchBackToDefaultTab()
        {
            SwitchToTabByItsName(Driver.WindowHandles.First());
        }

        public void SwitchToTabByItsName(string tabName)
        {
            Driver.SwitchTo().Window(tabName);
        }

        public void CloseAllTabsExceptFirst()
        {       
            foreach(var tabName in Driver.WindowHandles)
            {
                if (tabName == Driver.WindowHandles.First())
                {
                    continue;
                }

                SwitchToTabByItsName(tabName);
                Driver.Close();
            }
            SwitchBackToDefaultTab();
        }

        public IWebElement WaitForClickable(IWebElement webElement, int timeOut = 20)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
            return element;
        }

        public void ScrollToElement(IWebElement element)
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior:'auto', block: 'center', inline: 'center'})", element);
        }

        public void VerifyOpenLinkInCurrentTab(IWebElement actualLinkElement, string expectedUrl, string customMessage)
        {
            var initialTabsCount = GetCurrentTabsCount();
            ClickElement(actualLinkElement);
            GetCurrentTabsCount().ShouldBe(initialTabsCount, "Link should be opened in current tab");
            VerifyPageUrl(expectedUrl, customMessage);
        } 
        public void VerifyOpenLinkInANewTab(IWebElement actualLinkElement, string expectedUrl, string customMessage)
        {
            var initialTabsCount = GetCurrentTabsCount();
            ClickElement(actualLinkElement);
            VerifyNewTabIsOpened(initialTabsCount);
            verifyNewTabUrl(expectedUrl, customMessage);
        }

        public void verifyNewTabUrl(string expectedUrl, string customMessage)
        {
            SwitchToLastOpenedTab();
            VerifyPageUrl(expectedUrl, customMessage);
            SwitchBackToDefaultTab();
        }
        protected void ClickElement(IWebElement element)
        {
            ScrollToElement(element);
            WaitForClickable(element);
            element.Click();
        }
    }
}
