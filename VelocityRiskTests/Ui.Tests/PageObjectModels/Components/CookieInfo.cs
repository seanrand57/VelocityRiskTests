using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Ui.Tests.PageObjectModels.Components
{
    public class CookieInfo : BaseComponent
    {
        [FindsBy(How = How.XPath, Using = "(//span a)[0]")]
        public IWebElement Disclaimer;

        [FindsBy(How = How.XPath, Using = "(//span a)[1]")]
        public IWebElement TermsOfUse;

        [FindsBy(How = How.XPath, Using = "(//span a)[2]")]
        public IWebElement PrivacyPolicy;

        [FindsBy(How = How.Id, Using = "cookie_action_close_header")]
        public IWebElement Accept;

        public CookieInfo(IWebDriver driver) : base(driver) { }
    }
}
