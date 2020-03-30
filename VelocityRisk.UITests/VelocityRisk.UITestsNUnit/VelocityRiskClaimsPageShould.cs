using nunit.tests;
using NUnit.Framework;
using Shouldly; 
using System.Collections.Generic;
using System.Linq; 
using VelocityRisk.Persistence;
using VelocityRisk.Persistence.Models;
using VelocityRisk.UITestsNUnit.PageObjectModels;

namespace VelocityRisk.UITestsNUnit
{
    public class VelocityRiskClaimsPageShould : VelocityRiskBaseTest
    { 
        private ClaimsPage _claimsPage;
 
        private static VelocityRiskDbContext _context;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {            
            _claimsPage = new ClaimsPage(_driver);
            _claimsPage.NavigateTo();

            // use this method to populate panelInfo table db
            //_claimsPage.PopulateDb();
        }

        public static IEnumerable<object[]> PanelInfoExpected
        {
            get
            {
                _context = new VelocityRiskDbContext();
                return _context.PanelItems.Select(x => new[] { x }).ToArray();
            }
        }

        [Test]
        [TestCaseSource("PanelInfoExpected")]
        public void PanelItemsAreCorrectTest(PanelItem panelItem)
        {
            // panelItem is one record from the db            
            var isPanelElement = _claimsPage.IsPanelElementPresent(panelItem.Title);
            isPanelElement.ShouldBeTrue($"It was not possible to find panel item : {panelItem.Title} on UI");


            _claimsPage.ClickPaneITitleByName(panelItem.Title);
            var content = _claimsPage.GetPanelContent(panelItem.Title);
            panelItem.Content.ShouldBe(content, $"It was not possible to find expected content for : {panelItem.Title} on UI");

            // close item panel
            _claimsPage.ClickPaneITitleByName(panelItem.Title);
        }
    } 
}
