using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;

namespace Ui.Tests.Steps
{
    public class MakeAPaymentSteps : BaseSteps
    {
        public MakeAPaymentSteps(IWebDriver driver) : base(driver) { }

        public void ClickCustomesMakeAPaymentMenuItem()
        {
            var menuBar = new MenuBar(Driver);
            SetCurrentTabsCount();
            menuBar.HoverCustomersMenuItem();
            menuBar.ClickCustomersMakePaymentMenuItem();
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

        public void VerifyCustomerHasOptionToPayByCreditCardOrCheck()
        {
            var page = new MakePaymentPage(Driver);

            var payByCheckButtonLocator = By.XPath("//input[@value='Pay with Check']");
            WaitUntilElementIsVisible(payByCheckButtonLocator, 10);
            page.PayWithCheck.Click();
            var formLocator = By.XPath("//form");
            WaitUntilElementIsVisible(formLocator, 10);
            Driver.Navigate().Back();
            var payByCreditCardButtonLocator = By.XPath("//input[@value='Pay with Credit Card']");
            WaitUntilElementIsVisible(payByCreditCardButtonLocator, 10);
            page.PayWithCreditCard.Click();
            WaitUntilElementIsVisible(formLocator, 10);
        }
    }
}
