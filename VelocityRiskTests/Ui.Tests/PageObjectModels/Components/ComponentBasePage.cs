using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels.Components
{
    public class ComponentBasePage
    {
        protected readonly IWebDriver Driver;

        public ComponentBasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
