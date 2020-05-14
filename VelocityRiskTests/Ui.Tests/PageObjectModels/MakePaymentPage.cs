using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Ui.Tests.PageObjectModels
{
    public class MakePaymentPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@value='Pay with Check']")]
        public IWebElement PayWithCheck;

        [FindsBy(How = How.XPath, Using = "//input[@value='Pay with Credit Card']")]
        public IWebElement PayWithCreditCard;

        public MakePaymentPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://portal.icheckgateway.com/Velocity/";
        }
    }
}
