using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace Ui.Tests
{
    public abstract class BaseTest
    {
        protected BrowserName _browserName;

        protected IWebDriver Driver;

        public IWebDriver GetDriver => Driver;

        [OneTimeSetUp]
        public void BaseSetUp()
        {
            switch(_browserName)
            {
                case BrowserName.Chrome:
                    Driver = new ChromeDriver();
                    return;
                case BrowserName.InternetExplorer:
                    Driver = new InternetExplorerDriver(new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        RequireWindowFocus = true
                    });
                    return;
            }

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void BaseTearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}