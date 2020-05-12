using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels
{
    public class MainPage
    {
        private readonly IWebDriver _driver;

        private const string PAGE_URL = "https://velocityrisk.com/";

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(PAGE_URL);
        }

        public IWebElement GetMenuLinkByItemName(string menuItemName)
        {
            return _driver.FindElement(By.XPath("//a[contains(text(), '" + menuItemName + "')]"));
        }

        public bool IsMenuPresents(string menuItemName)
        {
            try
            {
                GetMenuLinkByItemName(menuItemName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClickMenuItemByName(string menuItemName)
        {
            var menuItem = GetMenuLinkByItemName(menuItemName);

            var parentElements = menuItem.FindElements(By.XPath("ancestor::ul[@class = 'sub-menu']"));
            if (parentElements.Count > 0)
            {
                menuItem.FindElement(By.XPath("ancestor::ul[@class = 'sub-menu']/preceding-sibling::a")).Click();
            }
            menuItem.Click();
        }
    }
}
