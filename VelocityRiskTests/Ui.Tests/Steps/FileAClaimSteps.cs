using System.Linq;
using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.Steps.Customers;

namespace Ui.Tests.Steps
{
    public class FileAClaimSteps: ClaimsSteps
    {
        public FileAClaimSteps(IWebDriver driver) : base(driver) { }

        public void ClickCustomersClaimsMenuItem()
        {
            MenuBar.ClickCustomersClaimsMenuItem();
        }

        public void VerifyOneLinkFromFireAClaimSection(string expectedUrl, string linkName)
        {
            var actualLink = Page.GetLinkFromFileAClaimSection(linkName);
            VerifyClickNavigation(actualLink, expectedUrl, $"It was not possible to open {linkName} page.");
        }
    }
}
