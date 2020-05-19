using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;
using Ui.Tests.Resources;

namespace Ui.Tests.Steps
{
    public class ManageYourPolicySteps : BaseSteps
    {
        private ManageYourPolicyPage _manageYourPolicyPage;

        public ManageYourPolicySteps(IWebDriver driver) : base(driver)
        {
            _manageYourPolicyPage = new ManageYourPolicyPage(Driver);
        }

        public void ClickCustomesManageYourPolicyMenuItem()
        {
            SetCurrentTabsCount();
            MenuBar.HoverCustomersMenuItem();
            MenuBar.ClickCustomersManageYourPolicyMenuItem();
            SwitchToNewOpenedTab();
        }

        public new void VerifyNewTabIsOpened()
        {
            base.VerifyNewTabIsOpened();
        }

        public void VerifyNewTabIsLoginPage(string expectedUrl)
        {
            Driver.Url.ShouldContain(expectedUrl,
                string.Format(ShouldlyCustomMessages.UrlOfCurrentTabShouldContainText_Formatted, expectedUrl));
        }

        public void VerifyNewTabIsUnderHttpsProtocol()
        {
            VerifyProtocolIsHttps();
        }

        public void VerifyNewTabPageTitle(string expectedText)
        {
            Driver.Title.ShouldBe(expectedText, $"Title of the current tab should be '{expectedText}'");
            
        }

        public void VerifyNewTabPageHeader(string expectedText)
        {
            WaitUntilElementIsVisible(_manageYourPolicyPage.HeaderElement);
            _manageYourPolicyPage.HeaderElement.Text.ShouldContain(expectedText, "Header of the current tab's page should " +
                $"contain text '{expectedText}'");
        }
    }
}
