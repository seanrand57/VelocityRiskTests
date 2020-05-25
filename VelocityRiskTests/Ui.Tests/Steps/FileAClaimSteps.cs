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

        //public void ScrollTo()
        //{
        //    MouseHoverToElement(Page.QuestionsOnAnExistingClaimElement);
        //}

        private void VerifyLink(IWebElement actualLinkElement, string expectedUrl)
        {
            var tabsCount = TabsCount == 0 ? Driver.WindowHandles.Count : TabsCount;
            TabsCount = Driver.WindowHandles.Count;

            ScrollToElement(actualLinkElement);
            WaitUntilElementIsVisible(actualLinkElement);
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

        public void VerifyOneLinkFromFireAClaimSection(string expectedUrl,
            string linkName)
        {
            var actualLink = Page.GetLinkFromFileAClaimSection(linkName);
            VerifyLink(actualLink, expectedUrl);
        }
    }
}
