using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels.Components
{
    public class Footer
    {
        protected readonly IWebDriver Driver;

        public Footer(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
