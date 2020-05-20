using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PersistenceModels;

namespace Ui.Tests
{
    public class CorporateWebsiteTests : BaseTest
    {
        public static IEnumerable<MenuItem> MenuInfoExpected { get; } = DataContext.LoadMenuItems();

        public static IEnumerable<PanelItem> PanelInfoExpected { get; } = DataContext.LoadPanelItems();

        private MainPage _mainPage;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mainPage = new MainPage(Driver);
            
        }

        [SetUp]
        public void Init()
        {
            _mainPage.NavigateTo();
        }

        [Test]
        [TestCaseSource("MenuInfoExpected")]
        public void MenuItemsAreCorrectTest(MenuItem menuItem)
        {
            var mainPage = new MainPage(Driver);
            var isMenuElement = mainPage.MenuPresents(menuItem.Name);
            isMenuElement.ShouldBeTrue($"It was not possible to find menu item : {menuItem.Name} on UI");

            mainPage.ClickMenuItemByName(menuItem.Name);

            var actualUrl = GetUrl();
            actualUrl.ShouldBe(menuItem.Link, $"It was not possible to find expected link for menu item : {menuItem.Name} on UI");
        }

        [Test]
        [TestCaseSource("PanelInfoExpected")]
        public void PanelItemsAreCorrectTest(PanelItem panelItem)
        {
            var claimsPage = new ClaimsPage(Driver);
            var isPanelElement = claimsPage.IsPanelElementPresent(panelItem.Title);
            isPanelElement.ShouldBeTrue($"It was not possible to find panel item : {panelItem.Title} on UI");

            // expand panel
            claimsPage.ClickPaneITitleByName(panelItem.Title);

            var actualContent = claimsPage.GetPanelContent(panelItem.Title);
            panelItem.Content.ShouldBe(actualContent, $"It was not possible to find expected content for : {panelItem.Title} on UI");

            // collapse panel
            claimsPage.ClickPaneITitleByName(panelItem.Title);
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
        private void MoveToElement(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        //CASE 5
        //Under Customers menu item -> Claims, then expand the file a claim accordion.
        //Validate the text which is there and the links for personal lines(homeowners) 
        //and small business.

        //Extending the above test ensure the links for personal lines
        //and small business claims 
        //go to the follow on pages which open in a new tab. 
        //Validate the new tab is velocity risks my claim look up.


        [Test]
        public void Test_Case_5_HomeownersLinksAreCorrectTest()
        {
            _mainPage.ClickMenuItemByName("Claims");
            var claimsPage = new ClaimsPage(Driver);
            claimsPage.ClickPaneITitleByName("File a claim");            

            // scroll down
            var element = claimsPage.GetQuestionsOnAnExistingClaimElement();
            MoveToElement(element);

            var fileAClaimSectionLinks = claimsPage.GetLinksFromFileAClaimSection();
            var homeownersLink = fileAClaimSectionLinks[0];
            var smallCommercialLink = fileAClaimSectionLinks[1];
            var largeCommercialLink = fileAClaimSectionLinks[2];

            homeownersLink.Click();
            var homeownersLinkUrl = GetUrl();
            homeownersLinkUrl.ShouldContain("https://www.claimlookup.com/");

            smallCommercialLink.Click();
            var smallCommercialLinkUrl = GetUrl();
            smallCommercialLinkUrl.ShouldContain("https://www.claimlookup.com/");

            largeCommercialLink.Click();
            var largeCommercialLinkUrl = GetUrl();
            largeCommercialLinkUrl.ShouldContain("https://www.claimlookup.com/");
        }


        //On the about us page -> validate the leadership team has images and also the names listed 
        //such as Phil Bowie, Rod Harden etc. clicking on their image and validating their title and location.

        //CASE 7:
        //1. Navigate to "About us" page(from Home Page -> "About us" -> "Who we are")
        //For each of 6 team members(using Data Driver approach):
        //2. Verify the image isDisplayed()
        //3.Verify the Name isDisplayed()
        //4.Verify the Name is as expected
        //5.Mouseover(click) the image

        //6. Verify the job title is displayed()
        //7.Verify the Job title is as expected
        //8.Verify the Location isDispalyed()
        //9. Verify Location is as expected
        [Test]

        public void Test_Case_7_AboutUsPageLeadershipTeamImagesAndNamesAreCorrectTest()
        {
            //Act
             _mainPage.ClickOnWhoWeAreMenuItemLink();

            var whoWeArePage = new WhoWeArePage(Driver);

            var leadershipTeamElement = whoWeArePage.MeetOurLeadershipTeamElement;
            var leadershipTeamImages = whoWeArePage.LeadershipTeamInfo;

            MoveToElement(leadershipTeamElement);

            foreach (var teamMember in leadershipTeamImages)
            {
                // check image
                teamMember.IsImageDisplayed.ShouldBeTrue($"It was not possible to find image card for team member {teamMember.TeamMemberName} :  on UI");

                // check name
                teamMember.IsTeamMemberNameDisplayed.ShouldBeTrue($"It was not possible to find name card for team member : {teamMember.TeamMemberName} on UI");
                //teamMember.TeamMemberName.ShouldBe();

                // check job title
                teamMember.IsJobTitleDisplayed.ShouldBeTrue($"It was not possible to find name card for team member : {teamMember.TeamMemberName} on UI");
                //teamMember.JobTitle.ShouldBe();

                teamMember.IsLocationDisplayed.ShouldBeTrue($"It was not possible to find name card for team member : {teamMember.TeamMemberName} on UI");
                //teamMember.Location.ShouldBe();
            }
        }

        //CASE 9:
        //1. Navigate to Home Page
        //2. Verify Velocity Logo image is present(div.header_logo img[alt='Velocity Logo']).isPresent()
        //3. Verify nav bar color is orange(div.header_orange).getCssVlaue('background') == '#F57F26'
        [Test]
        public void Test_Case_9_VelocityLogoImageAndNavBarAreCorrect()
        {
            var velocityLogoImage = _mainPage.GetLogo();
            var isLogoPresent = velocityLogoImage.Displayed;
            isLogoPresent.ShouldBeTrue();

            var navBar = _mainPage.GetNavBar();
            var navBarColor = navBar.GetCssValue("background-color");

            navBarColor.ShouldBe("rgba(245, 127, 38, 1)");
        }
    }
}
