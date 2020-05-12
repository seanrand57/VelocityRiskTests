using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels.Components
{
    public class Header
    {
        protected readonly IWebDriver Driver;

        public Header(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
