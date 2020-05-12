using OpenQA.Selenium;

namespace VelocityRiskTests.DataModels.PageObjectModels.Components
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
