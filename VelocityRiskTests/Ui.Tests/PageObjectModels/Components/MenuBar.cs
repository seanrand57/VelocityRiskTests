using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Ui.Tests.PageObjectModels.Components
{
    public class MenuItemType
    {
        private MenuItemType(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static MenuItemType Agents => new MenuItemType("Agents");
        public static MenuItemType Homeowners => new MenuItemType("Homeowners");
        public static MenuItemType BusinessLargeCommercial => new MenuItemType("Large Commercial");
        public static MenuItemType BusinessSmallCommercial => new MenuItemType("Small Commercial");
        public static MenuItemType CustomersClaims => new MenuItemType("Claims");
        public static MenuItemType CustomersManageYourPolicy => new MenuItemType("Manage Your Policy");
        public static MenuItemType CustomersMakePayment => new MenuItemType("Make a Payment");
        public static MenuItemType NotesAndNews => new MenuItemType("Notes and News");

        public static MenuItemType Customers => new MenuItemType("Customers");
    }

    public class MenuBar : BaseComponent
    {
        public MenuBar(IWebDriver driver) : base(driver) { }

        public bool IsMenuItemPresented(MenuItemType item)
        {
            try
            {
                GetMenuLinkByItemName(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClickAgentsMenuItem() => ClickMenuItemByName(MenuItemType.Agents);

        public void ClickHomeownersMenuItem() => ClickMenuItemByName(MenuItemType.Homeowners);

        public void ClickBusinessLargeCommercialsMenuItem() => ClickMenuItemByName(MenuItemType.BusinessLargeCommercial);

        public void ClickBusinessSmallCommercialsMenuItem() => ClickMenuItemByName(MenuItemType.BusinessSmallCommercial);

        public void ClickCustomersClaimsMenuItem() => ClickMenuItemByName(MenuItemType.CustomersClaims);

        public void ClickCustomersManageYourPolicyMenuItem() => ClickMenuItemByName(MenuItemType.CustomersManageYourPolicy);

        public void ClickCustomersMakePaymentMenuItem() => ClickMenuItemByName(MenuItemType.CustomersMakePayment);

        public void ClickNotesAndNewsMenuItem() => ClickMenuItemByName(MenuItemType.NotesAndNews);

        public void HoverCustomersMenuItem() => HoverMenuItemByName(MenuItemType.Customers);

        private IWebElement GetMenuLinkByItemName(MenuItemType item)
        {
            return Driver.FindElement(By.XPath($"//li/a[contains(text(), '{item.Value}')]"));
        }

        private IWebElement GetExpandableMenuItemByName(MenuItemType item)
        {
            return Driver.FindElement(By.XPath($"//ul[@id='top-menu']//a[contains(text(), '{item.Value}')]"));
        }

        private void ClickMenuItemByName(MenuItemType item)
        {
            var menuItem = GetMenuLinkByItemName(item);

            var parentElements = menuItem.FindElements(By.XPath("ancestor::ul[@class = 'sub-menu']"));
            if (parentElements.Count > 0)
            {
                menuItem.FindElement(By.XPath("ancestor::ul[@class = 'sub-menu']/preceding-sibling::a")).Click();
            }
//            menuItem.Click();
            var action = new Actions(Driver);
            action.MoveToElement(menuItem).Click().Perform();

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        private void HoverMenuItemByName(MenuItemType item)
        {
            var menuItem = GetExpandableMenuItemByName(item);
            var action = new Actions(Driver);
            action.MoveToElement(menuItem).Perform();
        }
    }
}
