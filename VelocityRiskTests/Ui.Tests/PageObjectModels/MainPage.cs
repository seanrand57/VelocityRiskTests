using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        public IWebElement GetMenuLinkByItemName(string menuItemName)
        {
            return Driver.FindElement(By.XPath("//a[contains(text(), '" + menuItemName + "')]"));
        }

        public bool MenuPresents(string menuItemName)
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

        public void ClickOnWhoWeAreMenuItemLink()
        {            
            Driver.FindElement(By.XPath("//li[@id='menu-item-470']/a")).Click();
            Driver.FindElement(By.XPath("//li[@id='menu-item-177']//a")).Click();
        }

        public IWebElement GetLogo()
        {
            return Driver.FindElement(By.XPath("//div[@class='header_white_inner']//img"));
        }

        public IWebElement GetNavBar()
        {
            return Driver.FindElement(By.ClassName("header_orange"));
        }
    }
}
