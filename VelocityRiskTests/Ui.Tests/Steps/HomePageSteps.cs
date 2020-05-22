using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;

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
            var velocityLogoImage = _homePage.Logo;
            var isLogoPresent = velocityLogoImage.Displayed;
            isLogoPresent.ShouldBeTrue("Velocity risk logo should be present.");
        }

        public void VerifyNavBarIsOrange()
        {
            var navBar = _homePage.NavBar;
            var navBarColor = navBar.GetCssValue("background-color");
            navBarColor.ShouldBe("rgba(245, 127, 38, 1)", "NavBar should be orange");
        }
    }
}
