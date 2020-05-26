using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;

namespace Ui.Tests.Steps
{
    public class BaseSteps<TPage> where TPage : BasePage
    {
        protected IWebDriver Driver;

        protected TPage Page;

        protected int TabsCount;

        protected MenuBar MenuBar;

        public BaseSteps(IWebDriver driver)
        {
            Driver = driver;

            MenuBar = new MenuBar(Driver);
        }

        private void NavigateToHomePage()
        {
            SwitchBackToDefaultTab();
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

        public void VerifyPageUrlWithoutProtocol(string urlWitoutProtocol)
        {
            Driver.Url.ShouldContain(urlWitoutProtocol, $"Url of the current tab (without protocol part) should contain text '{urlWitoutProtocol}'");
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

        public void CloseAllNewlyOpenedTabs()
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

        public void VerifyLink(IWebElement actualLinkElement, string expectedUrl, string customMessage)
        {
            ScrollToElement(actualLinkElement);
            WaitUntilElementIsVisible(actualLinkElement);
            actualLinkElement.Click(); 

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Driver.Url.ShouldContain(expectedUrl, customMessage);
            SwitchBackToDefaultTab();
        }        

        // some links are opened in new tabs, we need to select a tab and get the url
        public string GetUrl()
        {
            var allTabs = Driver.WindowHandles;
            var actualUrl = Driver.Url;
            if (allTabs.Count > 1)
            {
                Driver.SwitchTo().Window(allTabs[1]);
                actualUrl = Driver.Url;
                Driver.Close();
                Driver.SwitchTo().Window(allTabs[0]);
            }

            return actualUrl;
        }
    }
}
