using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Linq;
using System.Text.RegularExpressions;
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
                Driver.Navigate().GoToUrl(Page.PageUrl);
            }
        }

        public void VerifyPageUrlWithoutProtocol(string urlWitoutProtocol)
        {
            Driver.Url.ShouldContain(urlWitoutProtocol,
                $"Url of the current tab (without protocol part) " +
                $"should contain text '{urlWitoutProtocol}'");
        }

        public void VerifyProtocolIsHttps()
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

            Thread.Sleep(2000);
        }

        public void VerifyNavigation(string actualUrl, string expectedUrl, string customMessage)
        {
            Driver.Navigate().GoToUrl(actualUrl);
            var actualurl = Driver.Url;
            actualurl.ShouldBe(expectedUrl, customMessage);
        }

        public void VerifyClickNavigation(IWebElement element, string expectedUrl, string customMessage)
        {
            var tabsCount = TabsCount;

            ScrollToElement(element);
            WaitForClickable(element);

            // open in a new tab explicitly
            var action = new Actions(Driver);
            action.KeyDown(Keys.Control).MoveToElement(element).Click().Perform();

            while (TabsCount == tabsCount)
            {
                TabsCount = Driver.WindowHandles.Count;
            }

            var handles = Driver.WindowHandles;
            Driver.SwitchTo().Window(handles.Last());

            var actualUrl = Driver.Url;
            actualUrl.ShouldBe(expectedUrl, customMessage);

            Driver.Close();
            Driver.SwitchTo().Window(handles.First());
            TabsCount = Driver.WindowHandles.Count;
        }
    }
}
