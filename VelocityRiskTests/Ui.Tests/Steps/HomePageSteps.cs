using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.Steps.TestData;
using Ui.Tests.PersistenceModels;

namespace Ui.Tests.Steps
{
    public class HomePageSteps : BaseSteps<HomePage>
    {
        public HomePageSteps(IWebDriver driver) : base(driver)
        {
            Page = new HomePage(Driver);
        }

        public void VerifyLogoIsPresent()
        {
            Page.Logo.Displayed.ShouldBeTrue("Velocity risk logo should be present.");
        }

        public void VerifyNavBarIsOrange()
        {
            var navBar = _homePage.NavBar;
            var navBarColor = navBar.GetCssValue("background-color");
            navBarColor.ShouldBe(HomePageTestData.NavBarColor, "NavBar should be orange");
        }

        public void GivenMenuItemPresented(MenuItem menuItem)
        {
            var isMenuElement = Page.MenuPresents(menuItem.Name);
            isMenuElement.ShouldBeTrue($"It was not possible to find menu item : {menuItem.Name} on UI");
        }

        public void GivenIClickMenuItem(MenuItem menuItem)
        {
            Page.ClickMenuItemByName(menuItem.Name);
        }

        public void ThenUrlIsAsExpected(MenuItem menuItem)
        {
            var actualUrl = GetUrl();
            actualUrl.ShouldBe(menuItem.Link, $"It was not possible to find expected link for menu item : {menuItem.Name} on UI");
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
