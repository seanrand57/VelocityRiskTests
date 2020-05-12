using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels
{
    public class AgentPage : ComponentBasePage
    {
        public AgentPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://velocityrisk.com/for-agents/";
        }
    }
}
