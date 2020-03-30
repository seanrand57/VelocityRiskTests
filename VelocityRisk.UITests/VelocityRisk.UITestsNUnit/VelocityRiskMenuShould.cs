using nunit.tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VelocityRisk.Persistence;
using VelocityRisk.Persistence.Models;
using VelocityRisk.UITestsNUnit.PageObjectModels;

namespace VelocityRisk.UITestsNUnit
{
    public class VelocityRiskMenuShould : VelocityRiskBaseTest
    {
        private MainPage _mainPage;

        private static VelocityRiskDbContext _context;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mainPage = new MainPage(_driver);
        }

        [SetUp]
        public void Init()
        {           
            _mainPage.NavigateTo();
        }
        
        public static IEnumerable<object[]> MenuInfoExpected
        {
            get
            {
                _context = new VelocityRiskDbContext();
                return _context.MenuItems.Select(x => new[] { x }).ToArray();
            }
        }

        [Test]
        [TestCaseSource("MenuInfoExpected")]
        public void MenuItemsAreCorrectTest(MenuItem menuItem)
        {
            var isMenuElement = _mainPage.IsMenuPresents(menuItem.Name);
            isMenuElement.ShouldBeTrue($"It was not possible to find menu item : {menuItem.Name} on UI");

            _mainPage.ClickMenuItemByName(menuItem.Name);

            var actualUrl = GetUrl();

            actualUrl.ShouldBe(menuItem.Link, $"It was not possible to find expected link for menu item : {menuItem.Name} on UI");            
        }

        private string GetUrl()
        {
            ReadOnlyCollection<string> allTabs = _driver.WindowHandles;
            var actualUrl = _driver.Url;
            // because some links are opened in new tabs we need to select tab and get url
            if (allTabs.Count > 1)
            {
                _driver.SwitchTo().Window(allTabs[1]);
                actualUrl = _driver.Url;
                _driver.Close();
                _driver.SwitchTo().Window(allTabs[0]);
            }
            return actualUrl;
        }
    }
}