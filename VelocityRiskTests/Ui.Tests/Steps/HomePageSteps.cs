using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.Steps.TestData;
using Ui.Tests.PersistenceModels;
using Ui.Tests.Steps.TestData.Customers;

namespace Ui.Tests.Steps
{
    public class HomePageSteps : BaseSteps<HomePage>
    {
        public HomePageSteps(IWebDriver driver) : base(driver)
        {
            Page = new HomePage(Driver);
        }

        public void VerifyLogoIsPresent()
        {
            Page.Logo.Displayed.ShouldBeTrue("Velocity risk logo should be present.");
        }

        public void VerifyNavBarIsOrange()
        {
            var navBar = Page.NavBar;
            var navBarColor = navBar.GetCssValue("background-color");
            navBarColor.ShouldBe(HomePageTestData.NavBarColor, "NavBar should be orange");
        }

        public void GivenNavigatedWithoutSsl()
        {
            const string url = "http://www.velocityrisk.com";
            Page.PageUrl = url;
        }

        public void GivenMenuItemPresented(MenuItem menuItem)
        {
            var isMenuElement = Page.MenuPresents(menuItem.Name);
            isMenuElement.ShouldBeTrue($"It was not possible to find menu item : {menuItem.Name} on UI");
        }

        public void GivenIClickMenuItem(MenuItem menuItem)
        {
            Page.ClickMenuItemByName(menuItem.Name);
        }

        public void ThenUrlIsAsExpected(MenuItem menuItem)
        {
            var actualUrl = GetUrl();
            actualUrl.ShouldBe(menuItem.Link, $"It was not possible to find expected link for menu item : {menuItem.Name} on UI");
        }

        #region Footer Steps

        public void ThenVerifyCorporateOfficeAddress()
        {
            var actualAddress = Page.GetCorporateOfficeAddress();
            actualAddress.ShouldBe(CopyrightTestData.CorporateOfficeAddress, "It was not possible to find an expected address.");

            var actualLinkedInUrl = Page.GetLinkedInLink();
            actualLinkedInUrl.ShouldBe(CopyrightTestData.LinkedInHref, "It was not possible to find an expected LinkedIn link.");

            var actualFacebooknUrl = Page.GetFacebookLink();
            actualFacebooknUrl.ShouldBe(CopyrightTestData.FacebookHref, "It was not possible to find an expected Facebook link.");

            var actualTwitterUrl = Page.GetTwitterLink();
            actualTwitterUrl.ShouldBe(CopyrightTestData.TwitterHref, "It was not possible to find an expected Twitter link.");

            var actualInstagramUrl = Page.GetInstagramLink();
            actualInstagramUrl.ShouldBe(CopyrightTestData.InstagramHref, "It was not possible to find an expected Instagram link.");
        }

        public void ThenVerifySocialLinks()
        {
            VerifyClickNavigation(Page.Footer.CorporateOfficeLinkedIn, CopyrightTestData.LinkedInUrl, "It was not possible to open an expected LinkedIn link.");
            VerifyClickNavigation(Page.Footer.CorporateOfficeFacebook, CopyrightTestData.FacebookUrl, "It was not possible to open an expected Facebook link.");
            VerifyClickNavigation(Page.Footer.CorporateOfficeTwitter, CopyrightTestData.TwitterUrl, "It was not possible to open an expected Twitter link.");
            VerifyClickNavigation(Page.Footer.CorporateOfficeInstagram, CopyrightTestData.InstagramUrl, "It was not possible to open an expected Instagram link.");
        }

        public void ThenVerifyReportClaim()
        {
            var actualNumber = Page.GetReportClaimPhoneNumberText();
            actualNumber.ShouldBe(CopyrightTestData.ReportClaimPhoneNumber, "It was not possible to find expected phone number to report a claim.");

            var actualLink = Page.GetReportClaimLink();
            actualLink.ShouldBe(CopyrightTestData.ReportClaimPhoneLink, "It was not possible to find an expected link for the phone number to report a claim.");

            VerifyClickNavigation(Page.Footer.ReportClaimOnlineLink, CopyrightTestData.ReportClaimOnlineUrl, "It was not possible to find an expected URL to report a claim online.");
        }

        public void ThenVerifyProductInquiries()
        {
            var actualPersonalLinesText = Page.GetPersonalLinesNumberText();
            actualPersonalLinesText.ShouldBe(CopyrightTestData.PersonalLinesPhoneNumber, "It was not possible to find expected phone number for personal lines.");

            var actualSmallComercialsText = Page.GetSmallComercialNumberText();
            actualSmallComercialsText.ShouldBe(CopyrightTestData.SmallCommercialPhoneNumber, "It was not possible to find expected phone number for small commercial.");

            var actualLargeComercialsText = Page.GetLargeCommercialNumberText();
            actualLargeComercialsText.ShouldBe(CopyrightTestData.LargeCommercialPhoneNumber, "It was not possible to find expected phone number for large commercial.");


            var actualPersonalLinesLink = Page.GetPersonalLinesNumberLink();
            actualPersonalLinesLink.ShouldBe(CopyrightTestData.PersonalLinesPhoneNumberLink, "It was not possible to find expected phone number for personal lines.");

            var actualSmallComercialsLink = Page.GetSmallComercialNumberLink();
            actualSmallComercialsLink.ShouldBe(CopyrightTestData.SmallCommercialPhoneNumberLink, "It was not possible to find expected phone number for small commercial.");

            var actualLargeComercialsLink = Page.GetLargeCommercialNumberLink();
            actualLargeComercialsLink.ShouldBe(CopyrightTestData.LargeCommercialPhoneNumberLink, "It was not possible to find expected phone number for large commercial.");
        }

        public void ThenVerifyCopyright()
        {
            VerifyClickNavigation(Page.Footer.Disclaimer, CopyrightTestData.DisclaimerUrl, "It was not possible to find an expected URL for disclaimer.");
            VerifyClickNavigation(Page.Footer.TermsOfUse, CopyrightTestData.TermsOfUseUrl, "It was not possible to find an expected URL for terms of use.");
            VerifyClickNavigation(Page.Footer.PrivacyPolicy, CopyrightTestData.PrivacyPolicyUrl, "It was not possible to find an expected URL for privacy policy.");
        }

        public void ThenVerifyCookiePresented()
        {
            Page.CookieInfo.Accept.Displayed.ShouldBe(true, "It was not possible to find an expected cookie message.");

            VerifyClickNavigation(Page.CookieInfo.Disclaimer, CopyrightTestData.DisclaimerUrl, "It was not possible to open an expected disclaimer page.");
            VerifyClickNavigation(Page.CookieInfo.TermsOfUse, CopyrightTestData.TermsOfUseUrl, "It was not possible to open an expected terms of use page.");
            VerifyClickNavigation(Page.CookieInfo.PrivacyPolicy, CopyrightTestData.PrivacyPolicyUrl, "It was not possible to open an expected privacy policy page.");
        }

        #endregion Footer Steps

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
    }
}
