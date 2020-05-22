using OpenQA.Selenium;
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

        public IWebElement GetImageCardByName(string name) => Driver.FindElement(By.XPath($"//div[@class='overlay_content']/p[contains(text(), '{name}')]/parent::div"));

        public IWebElement GetJobByName(string name)
        {
            var imageCardDivElement = GetImageCardByName(name);
            var jobElement = imageCardDivElement.FindElement(By.XPath("//p[@class='filter_image_state'][1]"));
            return jobElement;
        }

        public IWebElement GetLocationByName(string name)
        {
            var imageCardDivElement = GetImageCardByName(name);
            var locationElement = imageCardDivElement.FindElement(By.XPath("//p[@class='filter_image_state'][2]"));
            return locationElement;
        }         
    }
}
