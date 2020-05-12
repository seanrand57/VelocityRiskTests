using OpenQA.Selenium;

namespace VelocityRiskTests.DataModels.PageObjectModels.Components
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
