using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels
{
    public class AgentPage : BasePage
    {
        private const string PAGE_URL = "https://velocityrisk.com/for-agents/";

        public AgentPage(IWebDriver driver) : base(driver) { }
    }
}
