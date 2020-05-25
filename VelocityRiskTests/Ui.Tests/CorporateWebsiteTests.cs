using System.Collections.Generic;
using System.Linq;
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
            _homePageSteps.GivenNavigatedWithoutSsl();
            _homePageSteps.VerifyProtocolIsHttps();
        }

        [Test]
        [TestCaseSource(nameof(MenuInfoExpected))]
        public void TestCase_02_MainMenu_ItemsAreCorrect(MenuItem menuItem)
        {
            _homePageSteps.GivenMenuItemPresented(menuItem);
            _homePageSteps.GivenIClickMenuItem(menuItem);
            _homePageSteps.ThenUrlIsAsExpected(menuItem);
        }

        [Test]
        public void TestCase_03_FooterItemsAreCorrect()
        {
            // given navigated to home page
            _homePageSteps.ThenVerifyCorporateOfficeAddress();
            _homePageSteps.ThenVerifyReportClaim();
            _homePageSteps.ThenVerifyProductInquiries();
            _homePageSteps.ThenVerifyCopyright();
        }

        [Test]
        [TestCaseSource(nameof(PanelInfoExpected))]
        public void TestCase_04_Claims_PanelItemsAreCorrect(PanelItem panelItem)
        {
            _claimsSteps.NavigateTo();
            _claimsSteps.GivenPanelItemPresented(panelItem);
            _claimsSteps.GivenIExpandPanelItem(panelItem);
            _claimsSteps.ThenVerifyPanelContent(panelItem);
        }

        [Test]
        public void TestCase_05_FileAClaimLinksAreCorrectTest()
        {
            _fileAClaimSteps.ClickFileAClaimAccordion();
            _fileAClaimSteps.ScrollTo();
            _fileAClaimSteps.VerifyHomeownersLink(FileAClaimTestData.FileAClaimHomeownersExpectedUrl);
            _fileAClaimSteps.VerifySmallCommercialLink(FileAClaimTestData.FileAClaimSmallCommercialExpectedUrl);
            _fileAClaimSteps.VerifyLargeCommercialLink(FileAClaimTestData.FileAClaimLargeCommercialExpectedUrl);
        }

        [Test]
        public void TestCase_06_Home_CookiePresented()
        {
            // given navigated to home page
            _homePageSteps.ThenVerifyCookiePresented();
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
            // given navigated to home page
            _homePageSteps.ThenVerifySocialLinks();
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
    }
}