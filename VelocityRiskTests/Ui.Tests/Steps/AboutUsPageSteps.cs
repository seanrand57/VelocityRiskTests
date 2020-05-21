using OpenQA.Selenium;
using Shouldly;
using System.Collections.Generic;
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

        public List<ImageCard> GetTeamMembersInfo()
        {
            return _whoWeArePage.LeadershipTeamInfo;
        }

        public ImageCard FindExpectedItem(PersistenceModels.ImageCard imageCardItem)
        {
            var allTeamMembers = GetTeamMembersInfo();
            var currentItem = allTeamMembers.Find(x => x.TeamMemberName == imageCardItem.TeamMemberName
            && x.JobTitle == imageCardItem.JobTitle
            && x.Location == imageCardItem.Location);

            return currentItem;
        }
        
        public void VerifyItem(PersistenceModels.ImageCard imageCardItem)
        {
            var item = FindExpectedItem(imageCardItem);
            item.ShouldNotBeNull($"There is no {imageCardItem.TeamMemberName}, {imageCardItem.JobTitle}, {imageCardItem.Location} on UI.");

            item.ShouldNotBeNull($"There is no image card for {imageCardItem.TeamMemberName}.");
            item.IsImageDisplayed.ShouldBeTrue($"The image card for team member {imageCardItem.TeamMemberName} is not displayed on UI");
            
            item.IsTeamMemberNameDisplayed.ShouldBeTrue($"It was not possible to find name card for team member : {imageCardItem.TeamMemberName} on UI");
            item.TeamMemberName.ShouldBe(imageCardItem.TeamMemberName);

            item.IsJobTitleDisplayed.ShouldBeTrue($"It was not possible to find name card for team member : {imageCardItem.TeamMemberName} on UI");
            item.JobTitle.ShouldBe(imageCardItem.JobTitle);


            item.IsLocationDisplayed.ShouldBeTrue($"It was not possible to find name card for team member : {imageCardItem.TeamMemberName} on UI");
            item.Location.ShouldBe(imageCardItem.Location);
        }
    }
}
