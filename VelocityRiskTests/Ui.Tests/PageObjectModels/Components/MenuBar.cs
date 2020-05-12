using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels.Components
{
    public class MenuBar
    {
        protected readonly IWebDriver Driver;

        public MenuBar(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
