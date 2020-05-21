using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;

namespace Ui.Tests.Steps
{
    public class FileAClaimSteps: BaseSteps
    {
        private ClaimsPage _claimsPage;

        public FileAClaimSteps(IWebDriver driver) : base(driver)
        {
            _claimsPage = new ClaimsPage(Driver);
        }

        public void ClickFileAClaimAccordion()
        {
            MenuBar.ClickCustomersClaimsMenuItem();
            _claimsPage.ClickFileAClaimMenuItem();
        }

        public void ScrollDown()
        {
            var element = _claimsPage.GetQuestionsOnAnExistingClaimElement();
            MouseHoverToElement(element);
        }

        public void VerifyLink(IWebElement linkElement)
        {
            linkElement.Click();
            VerifyNewTabIsOpened(1);
            SwitchToLastOpenedTab();
            Driver.Url.ShouldContain("https://www.claimlookup.com/");
            Driver.Close();
            SwitchBackToDefaultTab();
        }

        public void VerifyHomeownersLink()
        {
            var fileAClaimSectionLinks = _claimsPage.GetLinksFromFileAClaimSection();
            var homeownersLink = fileAClaimSectionLinks[0];
            VerifyLink(homeownersLink);
        }

        public void VerifySmallCommercialLink()
        {
            var fileAClaimSectionLinks = _claimsPage.GetLinksFromFileAClaimSection();
            var smallCommercialLink = fileAClaimSectionLinks[1];
            VerifyLink(smallCommercialLink);
        }
        public void VerifyLargeCommercialLink()
        {
            var fileAClaimSectionLinks = _claimsPage.GetLinksFromFileAClaimSection();
            var largeCommercialLink = fileAClaimSectionLinks[2];
            VerifyLink(largeCommercialLink);
        }
    }
}
