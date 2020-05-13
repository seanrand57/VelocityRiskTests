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


        [FindsBy(How = How.LinkText, Using = "Velocity Flex Home")]
        public IWebElement VelocityFlexHomeLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Connecticut")]
        public IWebElement ConnecticutLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Florida")]
        public IWebElement FloridaLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "New Jersey")]
        public IWebElement NewJerseyLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "New York")]
        public IWebElement NewYorkLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "North Carolina")]
        public IWebElement NorthCarolinaLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Texas")]
        public IWebElement TexasLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "here")]
        public IWebElement SmallCommercialPortalLink { get; set; }


        [FindsBy(How = How.CssSelector, Using = "a[href='https://velocityrisk.com/wp-content/uploads/2018/08/Large-Commercial-Producer-Application.pdf']")]
        public IWebElement LargeCommercialButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Small Commercial')]")]
        public IWebElement SmallCommercialButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Personal Lines')]")]
        public IWebElement PersonalLinesButton { get; set; }
    }
}