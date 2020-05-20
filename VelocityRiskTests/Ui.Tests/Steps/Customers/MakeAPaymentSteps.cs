using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;

namespace Ui.Tests.Steps
{
    public class MakeAPaymentSteps : BaseSteps
    {
        private int _currentTabsCount;

        public MakeAPaymentSteps(IWebDriver driver) : base(driver)
        {
        }

        public void ClickCustomesMakeAPaymentMenuItem()
        {
            _currentTabsCount = GetCurrentTabsCount();
            MenuBar.HoverCustomersMenuItem();
            MenuBar.ClickCustomersMakePaymentMenuItem();
            SwitchToNewOpenedTab();
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
