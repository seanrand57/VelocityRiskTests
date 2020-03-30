using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using VelocityRisk.Persistence;
using VelocityRisk.Persistence.Models;
using VelocityRisk.UITestsNUnit.PageObjectModels;

namespace mstest.tests
{
    [TestClass]
    public class VelocityRiskClaimsPageShould
    { 
        private static ClaimsPage _claimsPage;
        private static IWebDriver _driver;

        private static VelocityRiskDbContext _context; 

        [ClassInitialize]
        public static void OneTimeSetUp(TestContext context)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _claimsPage = new ClaimsPage(_driver);
            _claimsPage.NavigateTo();
        }

        public static IEnumerable<object[]> PanelItemsExpected
        {
            get
            {
                _context = new VelocityRiskDbContext();
                var item = _context.PanelItems.Select(x => new[] { x }).ToArray();
                return item;
            }
        }         

        [DataTestMethod]
        [DynamicData("PanelItemsExpected", DynamicDataSourceType.Property)]
        public void PanelItemsAreCorrectTest(PanelItem panelItem)
        {
            var panelElement = _claimsPage.IsPanelElementPresent(panelItem.Title);
            panelElement.ShouldBeTrue($"It was not possible to find panel item : {panelItem.Title} on UI");


            _claimsPage.ClickPaneITitleByName(panelItem.Title);
            var content = _claimsPage.GetPanelContent(panelItem.Title);
            panelItem.Content.ShouldBe(content, $"It was not possible to find expected content for : {panelItem.Title} on UI");

            // close item panel
            _claimsPage.ClickPaneITitleByName(panelItem.Title);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
