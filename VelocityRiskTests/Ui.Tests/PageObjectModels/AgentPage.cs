using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Ui.Tests.PageObjectModels
{
    public class AgentPage : BasePage
    {
        public AgentPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://velocityrisk.com/for-agents/";
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='#appointment_headline']")]
        public IWebElement GetStartedButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='http://velocityrisk.com/for-agents/#login_links']")]
        public IWebElement LogInButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='login_links']//a[contains(text(), 'Velocity Flex Home')]")]
        public IWebElement VelocityFlexHomeLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='login_links']//a[contains(text(), 'Connecticut')]")]
        public IWebElement ConnecticutLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='login_links']//a[contains(text(), 'Florida')]")]
        public IWebElement FloridaLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='login_links']//a[contains(text(), 'New Jersey')]")]
        public IWebElement NewJerseyLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='login_links']//a[contains(text(), 'New York')]")]
        public IWebElement NewYorkLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='login_links']//a[contains(text(), 'North Carolina')]")]
        public IWebElement NorthCarolinaLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='login_links']//a[contains(text(), 'Texas')]")]
        public IWebElement TexasLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='login_links']//a[contains(text(), 'here')]")]
        public IWebElement SmallCommercialPortalLink { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='cta_part']//span[contains(text(), 'Large Commercial')]")]
        public IWebElement LargeCommercialButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cta_part']//span[contains(text(), 'Small Commercial')]")]
        public IWebElement SmallCommercialButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cta_part']//span[contains(text(), 'Personal Lines')]")]
        public IWebElement PersonalLinesButton { get; set; }
    }
}