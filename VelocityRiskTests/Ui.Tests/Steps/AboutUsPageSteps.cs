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

        public void VerifyIsTeamMemberExists(string name)
        {
            var imageCardElement = _whoWeArePage.GetImageCardByName(name);
            imageCardElement.ShouldNotBeNull($"There is no {name} on UI.");
        }

        public void VerifyIsTeamMemberImageDisplayed(string name)
        {
            var imageCardElement = _whoWeArePage.GetImageCardByName(name);
            imageCardElement.Displayed.ShouldBeTrue($"There element with name {name} is not displayed on UI.");
        }

        public void VerifyIsTeamMemberNameDisplayed(string name)
        {
            var imageCardElement = _whoWeArePage.GetImageCardByName(name);
            imageCardElement.Displayed.ShouldBeTrue($"There element with name {name} is not displayed on UI.");
        }

        public void ClickOnNameCard(string name)
        {
            var imageCardElement = _whoWeArePage.GetImageCardByName(name);
            imageCardElement.Click();
        }

        public void VerifyTeamMemberJobTitle(string name, string expectedJobTitle)
        {
            var jobElement = _whoWeArePage.GetJobByName(name);
            jobElement.Text.ShouldBe(expectedJobTitle.ToUpper(), $"There is no job title: {expectedJobTitle} for name: {name} on UI.");
        }

        public void VerifyIsTeamMemberJobTitleDisplayed(string name)
        {
            var jobElement = _whoWeArePage.GetJobByName(name);
            jobElement.Displayed.ShouldBeTrue($"The job title element for {name} is not displayed on UI.");
        }

        public void VerifyTeamMemberLocation(string name, string expectedLocation)
        {
            var locationElement = _whoWeArePage.GetLocationByName(name);
            locationElement.Text.ShouldBe(expectedLocation.ToUpper(), $"There is no location: {expectedLocation} for name: {name} on UI.");
        }

        public void VerifyIsTeamMemberLocationDisplayed(string name)
        {
            var locationElement = _whoWeArePage.GetLocationByName(name);
            locationElement.Displayed.ShouldBeTrue($"The location element for {name} is not displayed on UI.");
        }
    }
}
