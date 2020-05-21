using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PersistenceModels;
using Ui.Tests.Steps;
using Ui.Tests.Steps.TestData.Customers;

namespace Ui.Tests
{
    public class CorporateWebsiteTests : BaseTest
    {
        public static IEnumerable<MenuItem> MenuInfoExpected { get; } = DataContext.LoadMenuItems();

        public static IEnumerable<PanelItem> PanelInfoExpected { get; } = DataContext.LoadPanelItems();

        private BaseSteps _baseSteps;
        private ManageYourPolicySteps _manageYourPolicySteps;
        private MakeAPaymentSteps _makeAPaymentSteps;
        private int _tabsCountBeforeEachTest;

        private FileAClaimSteps _fileAClaimSteps;
        private VelocityLogoImageAndNavBarSteps _velocityLogoImageAndNavBarSteps;

        [OneTimeSetUp]
        public void Initialize()
        {
            _baseSteps = new BaseSteps(Driver);
            _makeAPaymentSteps = new MakeAPaymentSteps(Driver);
            _manageYourPolicySteps = new ManageYourPolicySteps(Driver);
            _tabsCountBeforeEachTest = 1;

            _fileAClaimSteps = new FileAClaimSteps(Driver);
            _velocityLogoImageAndNavBarSteps = new VelocityLogoImageAndNavBarSteps(Driver);
        }

        [SetUp]
        public void BeforEachTest()
        {
            _baseSteps.GoToHomePage();
        }

        [TearDown]
        public void AfterEachTest()
        {
            _baseSteps.CloseAllNewlyOpenedTabs();
        }

        [Test]
        [TestCaseSource("MenuInfoExpected")]
        public void MenuItemsAreCorrectTest(MenuItem menuItem)
        {
            var homePage = new HomePage(Driver);
            homePage.NavigateTo();

            var isMenuElement = homePage.MenuPresents(menuItem.Name);
            isMenuElement.ShouldBeTrue($"It was not possible to find menu item : {menuItem.Name} on UI");

            homePage.ClickMenuItemByName(menuItem.Name);

            var actualUrl = GetUrl();
            actualUrl.ShouldBe(menuItem.Link, $"It was not possible to find expected link for menu item : {menuItem.Name} on UI");
        }

        [Test]
        [TestCaseSource("PanelInfoExpected")]
        public void PanelItemsAreCorrectTest(PanelItem panelItem)
        {
            var claimsPage = new ClaimsPage(Driver);
            claimsPage.NavigateTo();

            var isPanelElement = claimsPage.IsPanelElementPresent(panelItem.Title);
            isPanelElement.ShouldBeTrue($"It was not possible to find panel item : {panelItem.Title} on UI");

            // expand panel
            claimsPage.ClickPaneITitleByName(panelItem.Title);

            var actualContent = claimsPage.GetPanelContent(panelItem.Title);
            panelItem.Content.ShouldBe(actualContent, $"It was not possible to find expected content for : {panelItem.Title} on UI");

            // collapse panel
            claimsPage.ClickPaneITitleByName(panelItem.Title);
        }

        [Test]
        public void TestCase_10_Customers_ManageYourPolicy()
        {
            _manageYourPolicySteps.ClickCustomesManageYourPolicyMenuItem();
            _manageYourPolicySteps.VerifyNewTabIsOpened(_tabsCountBeforeEachTest);
            _manageYourPolicySteps.SwitchToLastOpenedTab();
            _manageYourPolicySteps.VerifyPageUrlWithoutProtocol(ManageYourPolicyTestData.LoginPageUrlWithoutProtocol);
            _manageYourPolicySteps.VerifyProtocolIsHttps();
            _manageYourPolicySteps.VerifyNewTabPageTitle(ManageYourPolicyTestData.LoginPageTitleText);
            _manageYourPolicySteps.VerifyNewTabPageHeader(ManageYourPolicyTestData.LoginPageHeaderText);
        }
         
        [Test]
        public void TestCase_11_Customers_MakeAPayment()
        {
            _makeAPaymentSteps.ClickCustomesMakeAPaymentMenuItem();
            _makeAPaymentSteps.VerifyNewTabIsOpened(_tabsCountBeforeEachTest);
            _manageYourPolicySteps.SwitchToLastOpenedTab();
            _makeAPaymentSteps.VerifyProtocolIsHttps();
            _makeAPaymentSteps.VerifyCustomerHasOptionToPayByCreditCardOrCheck();
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

        [Test]
        public void Test_Case_5_FileAClaimLinksAreCorrectTest()
        {
            _fileAClaimSteps.ClickFileAClaimAccordion();
            _fileAClaimSteps.ScrollDown();
            _fileAClaimSteps.VerifyHomeownersLink();
            _fileAClaimSteps.VerifySmallCommercialLink();
            _fileAClaimSteps.VerifyLargeCommercialLink();             
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
            var homePage = new HomePage(Driver);
            homePage.NavigateTo();
            homePage.ClickOnWhoWeAreMenuItemLink();

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

        [Test]
        public void Test_Case_9_VelocityLogoImageAndNavBarAreCorrect()
        {
            _velocityLogoImageAndNavBarSteps.VerifyLogoIsPresent();
            _velocityLogoImageAndNavBarSteps.VerifyNavBarIsOrange();
        }
    }
}