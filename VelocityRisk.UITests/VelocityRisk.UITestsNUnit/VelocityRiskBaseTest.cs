using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using VelocityRisk.UITestsNUnit.PageObjectModels;

namespace nunit.tests
{
    public class VelocityRiskBaseTest
    {
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void BaseSetUp() 
        {
            _driver = new ChromeDriver(); 

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        } 

        [OneTimeTearDown]
        public void BaseTearDown() 
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
