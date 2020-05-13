using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
        
        [FindsBy(How = How.XPath, Using = "//div[@class='commercial_subpart commercialfirst_subpart']/div[@class='commercial_content']/a")]
        public IWebElement HomeownersLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='commercial_subpart commercialfirst_subpart']/div[@class='commercial_content']/a")]
        public IWebElement RentalPropertiesLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='commercial_subpart commercialfirst_subpart']/div[@class='commercial_content']/a")]
        public IWebElement CondominiumsLink { get; set; }

        public IWebElement GetStartedButton { get; set; }
        public IWebElement MakePaymentButton { get; set; }
        public IWebElement ManageAccountButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "expand_text")]
        public IWebElement ExpandAllButton { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "faq_button_part homeowners_banner_buttonpart")]
        public IWebElement CustomerDropDownItems { get; set; }

        [FindsBy(How = How.ClassName, Using = "modal_popupbutton open-modal-popup")]
        public IWebElement ContactUsButton { get; set; }

        public List<EarthquakeItem> EarthquakePart { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='contact_title']/a")]
        public IWebElement ReportClaimLink { get; set; }

    }
}
