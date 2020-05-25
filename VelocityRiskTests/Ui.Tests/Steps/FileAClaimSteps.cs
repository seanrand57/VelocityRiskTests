using System.Linq;
using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;

namespace Ui.Tests.Steps
{
    public class FileAClaimSteps: BaseSteps<ClaimsPage>
    {
        public FileAClaimSteps(IWebDriver driver) : base(driver)
        {
            Page = new ClaimsPage(Driver);
        }

        public void ClickFileAClaimAccordion()
        {
            MenuBar.ClickCustomersClaimsMenuItem();
            Page.ClickFileAClaimMenuItem();
        }

        public void ScrollTo()
        {
            MouseHoverToElement(Page.QuestionsOnAnExistingClaimElement);
        }

        private void VerifyLink(IWebElement actualLinkElement, string expectedUrl)
        {
            var tabsCount = TabsCount == 0 ? Driver.WindowHandles.Count : TabsCount;
            TabsCount = Driver.WindowHandles.Count;

            ScrollToElement(actualLinkElement);
            WaitForClickable(actualLinkElement);
            actualLinkElement.Click();

            while (TabsCount == tabsCount)
            {
                TabsCount = Driver.WindowHandles.Count;
            }

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Driver.Url.ShouldContain(expectedUrl, "It was not possible to open an expected link.");
            Driver.Close();

            TabsCount = Driver.WindowHandles.Count;
            SwitchBackToDefaultTab();
        }

        public void VerifyHomeownersLink(string expectedUrl)
        {
            var actualHomeownersLink = Page.GetLinkFromFileAClaimSection("homeowners");
            VerifyLink(actualHomeownersLink, expectedUrl);
        }

        public void VerifySmallCommercialLink(string expectedUrl)
        {
            var actualSmallCommercialLink = Page.GetLinkFromFileAClaimSection("small commercial");
            VerifyLink(actualSmallCommercialLink, expectedUrl);
        }

        public void VerifyLargeCommercialLink(string expectedUrl)
        {
            var actualLargeCommercialLink = Page.GetLinkFromFileAClaimSection("large commercial");
            VerifyLink(actualLargeCommercialLink, expectedUrl);
        }
    }
}
