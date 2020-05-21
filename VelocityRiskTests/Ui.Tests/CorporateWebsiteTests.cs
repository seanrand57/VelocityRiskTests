using System.Collections.Generic;
using NUnit.Framework;
using Ui.Tests.PersistenceModels;
using Ui.Tests.Steps;
using Ui.Tests.Steps.TestData;
using Ui.Tests.Steps.Customers;
using Ui.Tests.Steps.TestData.Customers;

namespace Ui.Tests
{
    public class CorporateWebsiteTests : BaseTest
    {
        public static IEnumerable<MenuItem> MenuInfoExpected { get; } = DataContext.LoadMenuItems();

        public static IEnumerable<PanelItem> PanelInfoExpected { get; } = DataContext.LoadPanelItems();

        public static IEnumerable<ImageCard> ImageCardInfoExpected { get; } = DataContext.LoadImageCards();

        // private BaseSteps _baseSteps;
        private HomePageSteps _homePageSteps;
        private ClaimsSteps _claimsSteps;
        private ManageYourPolicySteps _manageYourPolicySteps;
        private MakeAPaymentSteps _makeAPaymentSteps;
        private int _tabsCountBeforeEachTest;

        private FileAClaimSteps _fileAClaimSteps;
        private HomePageSteps _homePageSteps;
        private AboutUsPageSteps _aboutUsPageSteps;

        [OneTimeSetUp]
        public void Initialize()
        {
            _homePageSteps = new HomePageSteps(Driver);
            _claimsSteps = new ClaimsSteps(Driver);
            _makeAPaymentSteps = new MakeAPaymentSteps(Driver);
            _manageYourPolicySteps = new ManageYourPolicySteps(Driver);

            _tabsCountBeforeEachTest = 1;

            _fileAClaimSteps = new FileAClaimSteps(Driver);
            _homePageSteps = new HomePageSteps(Driver);
            _aboutUsPageSteps = new AboutUsPageSteps(Driver);
        }

        [SetUp]
        public void BeforEachTest()
        {
            // any instance will work, since the Driver instance is common for all
            _homePageSteps.NavigateTo();
        }

        [TearDown]
        public void AfterEachTest()
        {
            // any instance will work, since the Driver instance is common for all
            _homePageSteps.CloseAllNewlyOpenedTabs();
        }

        [Test]
        [TestCaseSource(nameof(MenuInfoExpected))]
        public void TestCase_2_MainMenu_ItemsAreCorrect(MenuItem menuItem)
        {
            _homePageSteps.GivenMenuItemPresented(menuItem);
            _homePageSteps.GivenIClickMenuItem(menuItem);
            _homePageSteps.ThenUrlIsAsExpected(menuItem);
        }

        [Test]
        [TestCaseSource(nameof(PanelInfoExpected))]
        public void TestCase_4_Claims_PanelItemsAreCorrect(PanelItem panelItem)
        {
            _claimsSteps.NavigateTo();
            _claimsSteps.GivenPanelItemPresented(panelItem);
            _claimsSteps.GivenIExpandPanelItem(panelItem);
            _claimsSteps.ThenVerifyPanelContent(panelItem);
        }

        [Test]
        public void TestCase_10_Customers_ManageYourPolicy()
        {
            _manageYourPolicySteps.ClickCustomersManageYourPolicyMenuItem();
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
            _makeAPaymentSteps.ClickCustomersMakeAPaymentMenuItem();
            _makeAPaymentSteps.VerifyNewTabIsOpened(_tabsCountBeforeEachTest);
            _makeAPaymentSteps.SwitchToLastOpenedTab();
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

        [Test]
        public void Test_Case_5_FileAClaimLinksAreCorrectTest()
        {
            _fileAClaimSteps.ClickFileAClaimAccordion();
            _fileAClaimSteps.ScrollDown();
            _fileAClaimSteps.VerifyHomeownersLink(FileAClaimTestData.FileAClaimExpectedUrl);
            _fileAClaimSteps.VerifySmallCommercialLink(FileAClaimTestData.FileAClaimExpectedUrl);
            _fileAClaimSteps.VerifyLargeCommercialLink(FileAClaimTestData.FileAClaimExpectedUrl);             
        }


        [Test]
        [TestCaseSource("ImageCardInfoExpected")]
        public void Test_Case_7_AboutUsPageLeadershipTeamImagesAndNamesAreCorrectTest(PersistenceModels.ImageCard imageCardItem)
        {
            _aboutUsPageSteps.NavigateToPage();
            _aboutUsPageSteps.NavigateToLeadershipTeamView();
            _aboutUsPageSteps.VerifyIsTeamMemberExists(imageCardItem.TeamMemberName);

            _aboutUsPageSteps.VerifyIsTeamMemberImageDisplayed(imageCardItem.TeamMemberName);
            _aboutUsPageSteps.VerifyIsTeamMemberNameDisplayed(imageCardItem.TeamMemberName);

            _aboutUsPageSteps.ClickOnNameCard(imageCardItem.TeamMemberName);

            _aboutUsPageSteps.VerifyTeamMemberJobTitle(imageCardItem.TeamMemberName, imageCardItem.JobTitle);

            _aboutUsPageSteps.VerifyTeamMemberLocation(imageCardItem.TeamMemberName, imageCardItem.Location);
        }

        [Test]
        public void Test_Case_9_VelocityLogoImageAndNavBarAreCorrect()
        {
            _homePageSteps.VerifyLogoIsPresent();
            _homePageSteps.VerifyNavBarIsOrange();
        }
    }
}