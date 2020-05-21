using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;

namespace Ui.Tests.Steps.Customers
{
    public class ManageYourPolicySteps : BaseSteps<ManageYourPolicyPage>
    {
        public ManageYourPolicySteps(IWebDriver driver) : base(driver)
        {
            Page = new ManageYourPolicyPage(Driver);
        }

        public void ClickCustomersManageYourPolicyMenuItem()
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
            WaitUntilElementIsVisible(Page.HeaderElement);
            Page.HeaderElement.Text.ShouldContain(expectedText,
                $"Url of the current tab should contain text '{expectedText}'");
        }
    }
}
