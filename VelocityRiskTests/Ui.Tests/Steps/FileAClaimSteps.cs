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
            MouseHoverToElement(MenuBar.CustomersMenuItemElement);
            MenuBar.CustomersClaimsMenuItemElement.Click();
            SwitchToLastOpenedTab();
        }

        public void VerifyOneLinkFromFireAClaimSection(string expectedUrl, string linkName)
        {
            var actualLink = Page.GetLinkFromFileAClaimSection(linkName);
            VerifyLink(actualLink, expectedUrl, $"It was not possible to open {linkName} page.");
        }
    }
}
