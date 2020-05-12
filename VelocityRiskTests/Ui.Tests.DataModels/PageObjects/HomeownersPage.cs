using OpenQA.Selenium;
using System.Collections.Generic;
using Ui.Tests.DataModels.Models;
using Ui.Tests.DataModels.PageFragment;

namespace Ui.Tests.DataModels.PageObjects
{
    public class HomeownersPage
    {
        private readonly IWebDriver _driver;
        private const string pageUrl = "https://velocityrisk.com/for-homeowners/";

        public HomeownersPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(pageUrl);
        }

        public List<CommercialSubpartItem> CommercialInnerPart { get; set; }

        public List<LinkFragment> CommercialButtons { get; set; }         

        public IWebElement ExpandAllButton { get; set; }

        public List<DropDownBlockItem> CustomerDropDownItems { get; set; }

        public IWebElement ContactUsButton { get; set; }

        public List<EarthquakeItem> EarthquakePart { get; set; }

        public IWebElement ReportClaimLink { get; set; }

    }
}
