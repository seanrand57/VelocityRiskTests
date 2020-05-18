using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;

namespace Ui.Tests.Steps
{
    public class ManageYourPolicySteps : BaseSteps
    {
        public ManageYourPolicySteps(IWebDriver driver) : base(driver) { }

        public void ClickCustomesManageYourPolicyMenuItem()
        {
            var menuBar = new MenuBar(Driver);
            SetCurrentTabsCount();
            menuBar.HoverCustomersMenuItem();
            menuBar.ClickCustomersManageYourPolicyMenuItem();
            SwitchToNewOpenedTab();
        }

        public void VerifyNewTabIsOpened()
        {
            IsLinkOpenedOnNewTab().ShouldBeTrue();
        }

        public void VerifyNewTabIsLoginPage()
        {
            Driver.Url.ShouldContain("://portal.velocityrisk.com/Login.aspx?ReturnUrl=%2f");
        }

        public void VerifyNewTabIsUnderHttpsProtocol()
        {
            VerifyProtocolIsHttps();
        }

        public void VerifyNewTabPageTitleAndHeader()
        {
            Driver.Title.ShouldBe("Login Page");
            WaitUntilElementIsVisible(By.XPath("//header"), 3);
            var header = new ManageYourPolicyPage(Driver).HeaderElement;
            header.Text.ShouldContain("Customer Portal");
        }
    }
}
