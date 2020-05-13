using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Ui.Tests.PageObjectModels.Components
{
    public class MenuBar : BaseComponent
    {
        // Agents
        [FindsBy(How = How.XPath, Using = "//ul[@id='top-menu']/li[position()=1]")]
        private IWebElement _agents;

        // Homeowners
        [FindsBy(How = How.XPath, Using = "//ul[@id='top-menu']/li[position()=2]")]
        private IWebElement _homeowners;

        // Business
        [FindsBy(How = How.XPath, Using = "//ul[@id='top-menu']/li[position()=3]/ul/li[position()=1]")]
        private IWebElement _largeCommercial;
        [FindsBy(How = How.XPath, Using = "//ul[@id='top-menu']/li[position()=3]/ul/li[position()=2]")]
        private IWebElement _smallCommercial;

        // Customers
        [FindsBy(How = How.XPath, Using = "//ul[@id='top-menu']/li[position()=4]/ul/li[position()=1]")]
        private IWebElement _claims;
        [FindsBy(How = How.XPath, Using = "//ul[@id='top-menu']/li[position()=4]/ul/li[position()=2]/ul/li[position()=1]")]
        private IWebElement _manageYourPolicy;
        [FindsBy(How = How.XPath, Using = "//ul[@id='top-menu']/li[position()=4]/ul/li[position()=2]/ul/li[position()=2]")]
        private IWebElement _makePayment;

        // Notes and News
        [FindsBy(How = How.XPath, Using = "//ul[@id='top-menu']/li[position()=5]")]
        private IWebElement _notesAndNews;

        public MenuBar(IWebDriver driver) : base(driver) { }

        public IWebElement GetMenuLinkByItemName(string itemName)
        {
            return Driver.FindElement(By.XPath("//a[contains(text(), '" + itemName + "')]"));
        }

        public bool IsMenuItemPresented(string itemName)
        {
            try
            {
                GetMenuLinkByItemName(itemName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClickMenuItemByName(string itemName)
        {
            var menuItem = GetMenuLinkByItemName(itemName);

            var parentElements = menuItem.FindElements(By.XPath("ancestor::ul[@class = 'sub-menu']"));
            if (parentElements.Count > 0)
            {
                menuItem.FindElement(By.XPath("ancestor::ul[@class = 'sub-menu']/preceding-sibling::a")).Click();
            }
            menuItem.Click();
        }
    }
}
