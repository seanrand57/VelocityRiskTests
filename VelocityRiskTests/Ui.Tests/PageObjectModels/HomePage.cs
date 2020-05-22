using OpenQA.Selenium;
using Ui.Tests.PageObjectModels.Components;

namespace Ui.Tests.PageObjectModels
{
    public class HomePage : BasePage
    {
        public MenuBar MenuBar { get; set; }

        public Header Header { get; set; }

        public Footer Footer { get; set; }

        public CookieInfo CookieInfo { get; set; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            MenuBar = new MenuBar(driver);
            Header = new Header(driver);
            Footer = new Footer(driver);
            CookieInfo = new CookieInfo(driver);

            PageUrl = "https://velocityrisk.com/";
        }

        public IWebElement GetMenuLinkByItemName(string menuItemName)
        {
            return Driver.FindElement(By.XPath("//a[contains(text(), '" + menuItemName + "')]"));
        }

        public IWebElement AboutUsMenuItem => Driver.FindElement(By.XPath("//ul[@id='Up']/li/a[contains(text(), 'About Us')]"));

        public IWebElement WhoWeAreMenuItem => Driver.FindElement(By.XPath("//ul[@class='sub-menu']/li/a[contains(text(), 'Who We Are')]"));
        
        public IWebElement Logo => Driver.FindElement(By.XPath("//div[@class='header_white_inner']//img"));
        public IWebElement NavBar => Driver.FindElement(By.ClassName("header_orange"));

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
            AboutUsMenuItem.Click();
            WhoWeAreMenuItem.Click();
        }

        #region Footer

        public string GetCorporateOfficeAddress()
        {
            return Footer.CorporateOfficeAddress.Text;
        }

        public string GetLinkedInLink()
        {
            return Footer.CorporateOfficeLinkedIn.GetAttribute("href");
        }

        public string GetFacebookLink()
        {
            return Footer.CorporateOfficeFacebook.GetAttribute("href");
        }

        public string GetTwitterLink()
        {
            return Footer.CorporateOfficeTwitter.GetAttribute("href");
        }

        public string GetInstagramLink()
        {
            return Footer.CorporateOfficeInstagram.GetAttribute("href");
        }

        public string GetReportClaimPhoneNumberText()
        {
            return Footer.ReportClaimPhoneNumber.Text;
        }

        public string GetReportClaimLink()
        {
            return Footer.ReportClaimPhoneNumber.GetAttribute("href");
        }

        public string GetPersonalLinesNumberText()
        {
            return Footer.PersonalLinesNumber.Text;
        }

        public string GetSmallComercialNumberText()
        {
            return Footer.SmallCommercialNumber.Text;
        }

        public string GetLargeCommercialNumberText()
        {
            return Footer.LargeCommercialNumber.Text;
        }

        public string GetPersonalLinesNumberLink()
        {
            return Footer.PersonalLinesNumber.GetAttribute("href");
        }

        public string GetSmallComercialNumberLink()
        {
            return Footer.SmallCommercialNumber.GetAttribute("href");
        }

        public string GetLargeCommercialNumberLink()
        {
            return Footer.LargeCommercialNumber.GetAttribute("href");
        }

        #endregion Footer
    }
}
