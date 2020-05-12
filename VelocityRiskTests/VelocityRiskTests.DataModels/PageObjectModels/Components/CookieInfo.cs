﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace VelocityRiskTests.DataModels.PageObjectModels.Components
{
    public class CookieInfo
    {
        protected readonly IWebDriver Driver;

        [FindsBy(How = How.XPath, Using = "(//span a)[0]")]
        private IWebElement _disclaimer;

        [FindsBy(How = How.XPath, Using = "(//span a)[1]")]
        private IWebElement _termsOfUse;

        [FindsBy(How = How.XPath, Using = "(//span a)[2]")]
        private IWebElement _privacyPolicy;

        [FindsBy(How = How.Id, Using = "cookie_action_close_header")]
        private IWebElement _accept;

        public CookieInfo(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
