using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;

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
            MenuBar.HoverCustomersMenuItem();
            MenuBar.ClickCustomersManageYourPolicyMenuItem();
        }

        public void VerifyNewTabPageTitle(string expectedText)
        {
            Driver.Title.ShouldBe(expectedText, $"Title of the current tab should be '{expectedText}'");
        }

        public void VerifyNewTabPageHeader(string expectedText)
        {
            WaitUntilElementIsVisible(_manageYourPolicyPage.HeaderElement);
            _manageYourPolicyPage.HeaderElement.Text.ShouldContain(expectedText,
                $"Url of the current tab should contain text '{expectedText}'");
        }
    }
}
