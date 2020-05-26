using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        public string PageUrl;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
