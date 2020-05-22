using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.Steps.TestData;

namespace Ui.Tests.Steps
{
    public class HomePageSteps : BaseSteps
    {
        private HomePage _homePage;

        public HomePageSteps(IWebDriver driver) : base(driver)
        {
            _homePage = new HomePage(Driver);
        }

        public void VerifyLogoIsPresent()
        {
            _homePage.Logo.Displayed.ShouldBeTrue("Velocity risk logo should be present.");
        }

        public void VerifyNavBarIsOrange()
        {
            var navBar = _homePage.NavBar;
            var navBarColor = navBar.GetCssValue("background-color");
            navBarColor.ShouldBe(HomePageTestData.NavBarColor, "NavBar should be orange");
        }
    }
}
