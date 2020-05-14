using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels.Components
{
    public class MenuItem
    {
        private MenuItem(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static MenuItem Agents => new MenuItem("Agents");
        public static MenuItem Homeowners => new MenuItem("Homeowners");
        public static MenuItem BusinessLargeCommercial => new MenuItem("Large Commercial");
        public static MenuItem BusinessSmallCommercial => new MenuItem("Small Commercial");
        public static MenuItem CustomersClaims => new MenuItem("Claims");
        public static MenuItem CustomersManageYourPolicy => new MenuItem("Manage Your Policy");
        public static MenuItem CustomersMakePayment=> new MenuItem("Make a Payment");
        public static MenuItem NotesAndNews=> new MenuItem("Notes and News");
    }

    public class MenuBar : BaseComponent
    {
        public MenuBar(IWebDriver driver) : base(driver) { }

        public bool IsMenuItemPresented(MenuItem item)
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

        public void ClickAgentsMenuItem() => ClickMenuItemByName(MenuItem.Agents);

        public void ClickHomeownersMenuItem() => ClickMenuItemByName(MenuItem.Homeowners);

        public void ClickBusinessLargeCommercialsMenuItem() => ClickMenuItemByName(MenuItem.BusinessLargeCommercial);

        public void ClickBusinessSmallCommercialsMenuItem() => ClickMenuItemByName(MenuItem.BusinessSmallCommercial);

        public void ClickCustomersClaimsMenuItem() => ClickMenuItemByName(MenuItem.CustomersClaims);

        public void ClickCustomersManageYourPolicyMenuItem() => ClickMenuItemByName(MenuItem.CustomersManageYourPolicy);

        public void ClickCustomersMakePaymentMenuItem() => ClickMenuItemByName(MenuItem.CustomersMakePayment);

        public void ClickNotesAndNewsMenuItem() => ClickMenuItemByName(MenuItem.NotesAndNews);

        private IWebElement GetMenuLinkByItemName(MenuItem item)
        {
            return Driver.FindElement(By.XPath($"/li/a[contains(text(), '{item.Value}')]"));
        }

        private void ClickMenuItemByName(MenuItem item)
        {
            var menuItem = GetMenuLinkByItemName(item);

            var parentElements = menuItem.FindElements(By.XPath("ancestor::ul[@class = 'sub-menu']"));
            if (parentElements.Count > 0)
            {
                menuItem.FindElement(By.XPath("ancestor::ul[@class = 'sub-menu']/preceding-sibling::a")).Click();
            }
            menuItem.Click();
        }
    }
}
