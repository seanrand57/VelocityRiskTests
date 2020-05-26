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
            // todo: use method from BaseSteps once it will be added there
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior:'auto', block: 'center', inline: 'center'})",
                _whoWeArePage.MeetOurLeadershipTeamElement);

            MouseHoverToElement(_whoWeArePage.MeetOurLeadershipTeamElement);
        }     

        public void VerifyIsTeamMemberExists(string name)
        {
            var imageCardElement = _whoWeArePage.GetImageCardByName(name);
            imageCardElement.ShouldNotBeNull($"There is no {name} on UI.");
        }

        public void VerifyIsTeamMemberImageDisplayed(string name)
        {
            var imageCardElement = _whoWeArePage.IsTeamMemberImageDisplayedByName(name);
            imageCardElement.ShouldBeTrue($"There element with name {name} is not displayed on UI.");
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
            var isJobDisplayed = _whoWeArePage.IsJobTitleDisplayedByName(name);
            isJobDisplayed.ShouldBeTrue($"The job title element for {name} is not displayed on UI.");

            var jobTitle = _whoWeArePage.GetJobTitleByName(name);
            jobTitle.ShouldBe(expectedJobTitle.ToUpper(), $"There is no job title: {expectedJobTitle} for name: {name} on UI.");
        }

        public void VerifyTeamMemberLocation(string name, string expectedLocation)
        {
            var isLocationElementDisplayed = _whoWeArePage.IsLocationDisplayedByName(name);
            isLocationElementDisplayed.ShouldBeTrue($"The location element for {name} is not displayed on UI.");

            var locationTitle = _whoWeArePage.GetLocationByName(name);
            locationTitle.ShouldBe(expectedLocation.ToUpper(), $"There is no location: {expectedLocation} for name: {name} on UI.");
        }
    }
}
