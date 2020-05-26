using System.Collections.Generic;
using NUnit.Framework;
using Ui.Tests.PersistenceModels;
using Ui.Tests.Steps;
using Ui.Tests.Steps.Customers;
using Ui.Tests.Steps.TestData.Customers;

namespace Ui.Tests
{
    public class CorporateWebsiteTests : BaseTest
    {
        public static IEnumerable<MenuItem> MenuInfoExpected { get; } = DataContext.LoadMenuItems();

        public static IEnumerable<PanelItem> PanelInfoExpected { get; } = DataContext.LoadPanelItems();

        public static IEnumerable<ImageCard> ImageCardInfoExpected { get; } = DataContext.LoadImageCards();

        private HomePageSteps _homePageSteps;
        private ClaimsSteps _claimsSteps;
        private ManageYourPolicySteps _manageYourPolicySteps;
        private MakeAPaymentSteps _makeAPaymentSteps;
        private int _tabsCountBeforeEachTest;

        private FileAClaimSteps _fileAClaimSteps;
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
        public void TestCase_01_SecuredConnection()
        {
            _homePageSteps.NavigateWithoutSsl();
            _homePageSteps.VerifyRedirectedToHttps();
        }

        [Test]
        [TestCaseSource(nameof(MenuInfoExpected))]
        public void TestCase_02_MainMenu_ItemsAreCorrect(MenuItem menuItem)
        {
            _homePageSteps.VerifyMenuItemPresented(menuItem);
            _homePageSteps.ClickMenuItem(menuItem);
            _homePageSteps.VerifyUrlIsAsExpected(menuItem);
        }

        [Test]
        public void TestCase_03_FooterItemsAreCorrect()
        {
            _homePageSteps.VerifyCorporateOfficeAddress();
            _homePageSteps.VerifyReportClaim();
            _homePageSteps.VerifyProductInquiries();
            _homePageSteps.VerifyCopyright();
        }

        [Test]
        [TestCaseSource(nameof(PanelInfoExpected))]
        public void TestCase_04_Claims_PanelItemsAreCorrect(PanelItem panelItem)
        {
            _claimsSteps.NavigateTo();
            _claimsSteps.VerifyPanelItemPresented(panelItem);
            _claimsSteps.ExpandPanelItem(panelItem);
            _claimsSteps.VerifyPanelContent(panelItem);
        }

        [Test]
        public void TestCase_05_FileAClaimLinksAreCorrectTest()
        {
            _fileAClaimSteps.ClickCustomersClaimsMenuItem();
            _fileAClaimSteps.ClickPanel("File a claim");
            _fileAClaimSteps.VerifyOneLinkFromFireAClaimSection(FileAClaimTestData.FileAClaimHomeownersExpectedUrl, "homeowners");
            _fileAClaimSteps.VerifyOneLinkFromFireAClaimSection(FileAClaimTestData.FileAClaimSmallCommercialExpectedUrl, "small commercial");
            _fileAClaimSteps.VerifyOneLinkFromFireAClaimSection(FileAClaimTestData.FileAClaimLargeCommercialExpectedUrl, "large commercial");
        }

        [Test]
        public void TestCase_06_Home_CookiePresented()
        {
            _homePageSteps.VerifyCookiePresented();
        }

        [Test]
        [TestCaseSource(nameof(ImageCardInfoExpected))]
        public void TestCase_07_AboutUsPageLeadershipTeamImagesAndNamesAreCorrectTest(ImageCard imageCardItem)
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
        public void TestCase_08_Footer_SocialLinksAreOpening()
        {
            _homePageSteps.VerifySocialLinks();
        }

        [Test]
        public void TestCase_09_VelocityLogoImageAndNavBarAreCorrect()
        {
            _homePageSteps.VerifyLogoIsPresent();
            _homePageSteps.VerifyNavBarIsOrange();
        }

        [Test]
        public void TestCase_10_Customers_ManageYourPolicy()
        {
            _manageYourPolicySteps.ClickCustomersManageYourPolicyMenuItem();
            _manageYourPolicySteps.VerifyNewTabIsOpened(_tabsCountBeforeEachTest);
            _manageYourPolicySteps.SwitchToLastOpenedTab();
            _manageYourPolicySteps.VerifyPageUrlWithoutProtocol(ManageYourPolicyTestData.LoginPageUrlWithoutProtocol);
            _manageYourPolicySteps.VerifyRedirectedToHttps();
            _manageYourPolicySteps.VerifyNewTabPageTitle(ManageYourPolicyTestData.LoginPageTitleText);
            _manageYourPolicySteps.VerifyNewTabPageHeader(ManageYourPolicyTestData.LoginPageHeaderText);
        }

        [Test]
        public void TestCase_11_Customers_MakeAPayment()
        {
            _makeAPaymentSteps.ClickCustomersMakeAPaymentMenuItem();
            _makeAPaymentSteps.VerifyNewTabIsOpened(_tabsCountBeforeEachTest);
            _makeAPaymentSteps.SwitchToLastOpenedTab();
            _makeAPaymentSteps.VerifyRedirectedToHttps();
            _makeAPaymentSteps.VerifyCustomerHasOptionToPayByCreditCardOrCheck();
        }
    }
}