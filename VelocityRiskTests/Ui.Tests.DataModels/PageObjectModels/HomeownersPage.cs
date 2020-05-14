using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
        
        [FindsBy(How = How.XPath, Using = "//h3[text() ='Homeowners']/following-sibling::a")]
        public IWebElement HomeownersMoreInfoLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[text() ='Rental Properties']/following-sibling::a")]
        public IWebElement RentalPropertiesMoreInfoLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[text() ='Condominiums']/following-sibling::a")]
        public IWebElement CondominiumsMoreInfoLink { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "faq_button open-modal-popup")]
        public IWebElement GetStartedButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "faq_button")]
        public IWebElement MakePaymentButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Manage Account")]
        public IWebElement ManageAccountButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "expand_text")]
        public IWebElement ExpandAllButton { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "faq_button_part homeowners_banner_buttonpart")]
        public IWebElement CustomerDropDownItems { get; set; }

        [FindsBy(How = How.ClassName, Using = "modal_popupbutton open-modal-popup")]
        public IWebElement ContactUsButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "National Weather Service")]
        public IWebElement NationalWeatherServiceLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "NOAA National Hurricane Center")]
        public IWebElement NOAANationalHurricaneCenterLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "USGS World EQ Maps")]
        public IWebElement USGSWorldEQMapsLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Northern California EQ Data")]
        public IWebElement NothernCaliforniaEQDataLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Southern California EQ Data")]
        public IWebElement SouthernCaliforniaEQDataLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Pacific Northwest EQ Data")]
        public IWebElement PacificNorthwestEQDataLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Intermountain West EQ Data")]
        public IWebElement IntermountainWestEQDataLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "FEMA Flood Maps")]
        public IWebElement FEMAFloodMapsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='contact_title']/a")]
        public IWebElement ReportClaimLink { get; set; }
    }
}
