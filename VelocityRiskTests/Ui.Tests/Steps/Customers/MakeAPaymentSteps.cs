using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;
using Ui.Tests.Resources;

namespace Ui.Tests.Steps
{
    public class MakeAPaymentSteps : BaseSteps
    {
        public MakeAPaymentSteps(IWebDriver driver) : base(driver)
        {
        }

        public void ClickCustomesMakeAPaymentMenuItem()
        {
            SetCurrentTabsCount();
            MenuBar.HoverCustomersMenuItem();
            MenuBar.ClickCustomersMakePaymentMenuItem();
            SwitchToNewOpenedTab();
        }

        public new void VerifyNewTabIsOpened()
        {
            base.VerifyNewTabIsOpened();
        }

        public void VerifyNewTabIsLoginPage(string expectedUrl)
        {
            Driver.Url.ShouldContain(expectedUrl);
        }

        public void VerifyNewTabIsUnderHttpsProtocol()
        {
            VerifyProtocolIsHttps();
        }

        public void VerifyCustomerHasOptionToPayByCreditCardOrCheck()
        {
            var makePaymentPage = new MakePaymentPage(Driver);

            WaitUntilElementIsVisible(makePaymentPage.PayWithCheck);
            makePaymentPage.PayWithCheck.Click();
            WaitUntilElementIsVisible(makePaymentPage.CheckOrCreditCardForm);
            
            Driver.Navigate().Back();

            WaitUntilElementIsVisible(makePaymentPage.PayWithCreditCard);
            makePaymentPage.PayWithCreditCard.Click();
            WaitUntilElementIsVisible(makePaymentPage.CheckOrCreditCardForm);
        }
    }
}
