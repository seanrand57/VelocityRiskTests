using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VelocityRisk.DataModels.PageObjectModels;
using VelocityRisk.Persistence;

namespace VelocityRisk.UITestsNUnit.PageObjectModels
{
    public class ClaimsPage : BasePage
    { 
        private const string pageUrl = "https://velocityrisk.com/claims/";

        public ClaimsPage(IWebDriver _driver) : base(_driver)  {}

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(pageUrl);
        }

        public void ClickExpandPanel()
        {
            var expandAllButton = _driver.FindElement(By.ClassName("expand_all_btn"));
            WaitForClickable(expandAllButton);
            expandAllButton.Click();
        }

        public void ClickPaneITitleByName(string panelItemName)
        {
            var spanElement = GetPanelLinkByItemName(panelItemName);
            var divElement = spanElement.FindElement(By.XPath("ancestor::div[@class = 'customer_drop_block']"));
            ScrollToElement(divElement);

            var aElement = divElement.FindElement(By.XPath("a[@class = 'customer_head_part']"));
            WaitForClickable(aElement);

            aElement.Click();
        }

        public IWebElement GetPanelLinkByItemName(string panelItemTitle)
        {
            return _driver.FindElement(By.XPath("//span[contains(text(), '" + panelItemTitle + "')]"));
        }

        public bool IsPanelElementPresent(string panelItemTitle)
        {
            try
            {
                return GetPanelLinkByItemName(panelItemTitle).Displayed;                 
            }
            catch
            {
                return false;
            }
        }

        public string GetPanelContent(string panelItemTitle)
        {
            var panelItem = GetPanelLinkByItemName(panelItemTitle);
            var panelElement = panelItem.FindElement(By.XPath("ancestor::div[@class = 'customer_drop_block']/div")); 

            return panelElement.GetAttribute("innerText");
        }

        #region Methods for db population  

        public ReadOnlyCollection<IWebElement> PanelContentElements
        {
            get
            {
                return _driver.FindElements(By.CssSelector("div.customer_desc_block"));
            }
        }

        public List<string> PanelContent
        {
            get
            {
                ClickExpandPanel();

                var panelsContent = new List<string>();

                foreach (var item in PanelContentElements)
                {
                    var panelContentText = item.GetAttribute("outerText");
                    panelsContent.Add(panelContentText);
                }

                return panelsContent;
            }
        }
        public void PopulateDb()
        {
            VelocityRiskDbContext _context  = new VelocityRiskDbContext();
            _context.PanelItems.Add(new Persistence.Models.PanelItem() { Title = "File a claim", Content = PanelContent[0] });
            _context.PanelItems.Add(new Persistence.Models.PanelItem() { Title = "Questions on an existing claim?", Content = PanelContent[1] });
            _context.PanelItems.Add(new Persistence.Models.PanelItem() { Title = "Our claims process", Content = PanelContent[2] });
            _context.PanelItems.Add(new Persistence.Models.PanelItem() { Title = "General FAQs", Content = PanelContent[3] });
            _context.PanelItems.Add(new Persistence.Models.PanelItem() { Title = "Property Claim FAQs", Content = PanelContent[4] });
            _context.PanelItems.Add(new Persistence.Models.PanelItem() { Title = "Additional Resources", Content = PanelContent[5] });

            _context.SaveChanges();
        }

        #endregion
    }
}