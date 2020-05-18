using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PersistenceModels;

namespace Ui.Tests
{
    public class CorporateWebsiteTests : BaseTest
    {
        public static IEnumerable<MenuItem> MenuInfoExpected { get; } = DataContext.LoadMenuItems();

        public static IEnumerable<PanelItem> PanelInfoExpected { get; } = DataContext.LoadPanelItems();

        [Test]
        [TestCaseSource("MenuInfoExpected")]
        public void MenuItemsAreCorrectTest(MenuItem menuItem)
        {
            var mainPage = new MainPage(Driver);
            mainPage.NavigateTo();

            var isMenuElement = mainPage.MenuPresents(menuItem.Name);
            isMenuElement.ShouldBeTrue($"It was not possible to find menu item : {menuItem.Name} on UI");

            mainPage.ClickMenuItemByName(menuItem.Name);

            var actualUrl = GetUrl();
            actualUrl.ShouldBe(menuItem.Link, $"It was not possible to find expected link for menu item : {menuItem.Name} on UI");
        }

        [Test]
        [TestCaseSource("PanelInfoExpected")]
        public void PanelItemsAreCorrectTest(PanelItem panelItem)
        {
            var claimsPage = new ClaimsPage(Driver);
            claimsPage.NavigateTo();

            var isPanelElement = claimsPage.IsPanelElementPresent(panelItem.Title);
            isPanelElement.ShouldBeTrue($"It was not possible to find panel item : {panelItem.Title} on UI");

            // expand panel
            claimsPage.ClickPaneITitleByName(panelItem.Title);

            var actualContent = claimsPage.GetPanelContent(panelItem.Title);
            panelItem.Content.ShouldBe(actualContent, $"It was not possible to find expected content for : {panelItem.Title} on UI");

            // collapse panel
            claimsPage.ClickPaneITitleByName(panelItem.Title);
        }

        [Test]
        public void TestCase_10_Customers_ManageOurPolicy()
        {
            // 1. Click "Customes -> Manage ur Policy" menu item
            NavigateToCorporateWebsiteBaseUrl();
            var customersMenuItemElementLocator = By.XPath("//a[contains(text(), 'Customers')]");
            var customersMenuItemElement = GetElemetByLocator(customersMenuItemElementLocator);
            WaitUntilElementIsVisible(customersMenuItemElementLocator, 3);
            MouseHoverToElement(customersMenuItemElement);
            var currentTabsCount = Driver.WindowHandles.Count;
            ClickOnElementByLocator(By.XPath("//a[contains(text(), 'Manage Your Policy')]"));
            SwitchToNewOpenedTab();

            // 2. Verify new tab is opened
            IsLinkOpenedOnNewTab(currentTabsCount).ShouldBeTrue();

            // 3. Verify new tab is /Login.asp page
            Driver.Url.ShouldContain("://portal.velocityrisk.com/Login.aspx?ReturnUrl=%2f");

            // 4. Verify new tab is under Https protocol
            Driver.Url.Split(':')[0].ShouldBe("https");

            // 5. Verify new tab page title and header (Customer Portal)
            Driver.Title.ShouldBe("Login Page");
            GetElemetByLocator(By.XPath("//header")).Text.ShouldContain("Customer Portal");

            BaseTearDown();
        }

        private void NavigateToCorporateWebsiteBaseUrl()
        {
            Driver.Navigate().GoToUrl(DataContext.BaseUrl);
        }

        // some links are opened in new tabs, we need to select a tab and get the url
        private string GetUrl()
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