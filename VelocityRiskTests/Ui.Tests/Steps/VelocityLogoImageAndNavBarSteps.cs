using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;

namespace Ui.Tests.Steps
{
    public class VelocityLogoImageAndNavBarSteps : BaseSteps
    {
        private HomePage _homePage;

        public VelocityLogoImageAndNavBarSteps(IWebDriver driver) : base(driver)
        {
            _homePage = new HomePage(Driver);
        }

        public void VerifyLogoIsPresent()
        {
            var velocityLogoImage = _homePage.GetLogo();
            var isLogoPresent = velocityLogoImage.Displayed;
            isLogoPresent.ShouldBeTrue("Velocity risk logo should be present.");
        }

        public void VerifyNavBarIsOrange()
        {
            var navBar = _homePage.GetNavBar();
            var navBarColor = navBar.GetCssValue("background-color");
            navBarColor.ShouldBe("rgba(245, 127, 38, 1)", "NavBar should be orange");
        }
    }
}
