using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;

namespace Ui.Tests.Steps
{
    public class FileAClaimSteps: BaseSteps<ClaimsPage>
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
            MouseHoverToElement(_claimsPage.QuestionsOnAnExistingClaimElement);
        }

        private void VerifyLink(IWebElement linkElement, string url)
        {
            linkElement.Click();
            VerifyNewTabIsOpened(1);
            SwitchToLastOpenedTab();
            Driver.Url.ShouldContain(url);
            Driver.Close();
            SwitchBackToDefaultTab();
        }

        public void VerifyHomeownersLink(string url)
        {
            var homeownersLink = _claimsPage.GetLinkFromFileAClaimSection("homeowners");
            VerifyLink(homeownersLink, url);
        }

        public void VerifySmallCommercialLink(string url)
        {
            var smallCommercialLink = _claimsPage.GetLinkFromFileAClaimSection("small commercial");
            VerifyLink(smallCommercialLink, url);
        }
        public void VerifyLargeCommercialLink(string url)
        {
            var largeCommercialLink = _claimsPage.GetLinkFromFileAClaimSection("large commercial");
            VerifyLink(largeCommercialLink, url);
        }
    }
}
