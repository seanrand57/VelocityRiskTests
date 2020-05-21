using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ui.Tests.PageObjectModels
{
    public class WhoWeArePage : BasePage
    {
        public WhoWeArePage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://velocityrisk.com/meet-our-team/";
        }

        public IWebElement MeetOurLeadershipTeamElement => Driver.FindElement(By.ClassName("filter_inner_part"));

        public ReadOnlyCollection<IWebElement> LeadershipTeamImages => Driver.FindElements(By.XPath("//a[contains(@class, 'filter_image_part')]"));

        public List<ImageCard> LeadershipTeamInfo
        {
            get
            {
                var leadershipTeamInfo = new List<ImageCard>();
                foreach (var teamMemberInfo in LeadershipTeamImages)
                {
                    var imageCardInfo = new ImageCard();

                    var imageCard = teamMemberInfo.FindElement(By.TagName("img"));
                    imageCardInfo.IsImageDisplayed = imageCard.Displayed;

                    // check name
                    var teamMemberItemName = teamMemberInfo.FindElement(By.ClassName("filter_image_title"));
                    imageCardInfo.IsTeamMemberNameDisplayed = teamMemberItemName.Displayed;
                    imageCardInfo.TeamMemberName = teamMemberItemName.Text;                    

                    teamMemberInfo.Click();

                    // check job title
                    var jobTitleAndLocationItem = teamMemberInfo.FindElements(By.ClassName("filter_image_state"));
                    var jobTitleItem = jobTitleAndLocationItem[0];
                    imageCardInfo.IsJobTitleDisplayed = jobTitleItem.Displayed;
                    imageCardInfo.JobTitle = jobTitleItem.Text;

                    // location
                    var locationItem = jobTitleAndLocationItem[1];
                    imageCardInfo.IsLocationDisplayed = locationItem.Displayed;
                    imageCardInfo.Location = locationItem.Text;

                    leadershipTeamInfo.Add(imageCardInfo);
                }
                return leadershipTeamInfo;
            }
            set { }
        }      
    }

    public class ImageCard
    {
        public bool IsImageDisplayed { get; set; }
        public string TeamMemberName { get; set; }
        public bool IsTeamMemberNameDisplayed { get; set; }
        public string JobTitle { get; set; }
        public bool IsJobTitleDisplayed { get; set; }
        public string Location { get; set; }
        public bool IsLocationDisplayed { get; set; }
    }
}
