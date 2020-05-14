using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Ui.Tests.PageObjectModels
{
    public class MakePaymentPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@value='Pay with Check']")]
        private IWebElement _payWithCheck;

        [FindsBy(How = How.XPath, Using = "//input[@value='Pay with Credit Card']")]
        private IWebElement _payWithCreditCard;

        public MakePaymentPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://portal.icheckgateway.com/Velocity/";
        }
    }
}
