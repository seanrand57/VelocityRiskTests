using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ui.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [OneTimeSetUp]
        public void BaseSetUp()
        {
            Driver = new ChromeDriver();

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