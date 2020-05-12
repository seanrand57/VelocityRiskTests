using OpenQA.Selenium;

namespace VelocityRiskTests.DataModels.PageObjectModels.Components
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
