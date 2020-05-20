using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PageObjectModels.Components;

namespace Ui.Tests.Steps
{
    public class MakeAPaymentSteps : BaseSteps
    {
        public MakeAPaymentSteps(IWebDriver driver) : base(driver)
        {
        }

        public void ClickCustomesMakeAPaymentMenuItem()
        {
            MenuBar.HoverCustomersMenuItem();
            MenuBar.ClickCustomersMakePaymentMenuItem();
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
