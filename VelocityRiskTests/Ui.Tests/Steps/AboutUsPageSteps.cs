using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;

namespace Ui.Tests.Steps
{
    public class AboutUsPageSteps : BaseSteps
    {
        private WhoWeArePage _whoWeArePage;

        public AboutUsPageSteps(IWebDriver driver) : base(driver)
        {
            _whoWeArePage = new WhoWeArePage(Driver);
        }

        public void NavigateToPage()
        {
            GoToHomePage();
            var homePage = new HomePage(Driver);
            homePage.ClickOnWhoWeAreMenuItemLink();            
        }

        public void NavigateToLeadershipTeamView()
        {
            var leadershipTeamElement = _whoWeArePage.MeetOurLeadershipTeamElement;
            MouseHoverToElement(leadershipTeamElement);
        }

        public void VerifyImage()
        {

        }

        public void VerifyName()
        {

        }

        public void VerifyTitle()
        {

        }

        public void VerifyLocation()
        {

        }
    }
}
