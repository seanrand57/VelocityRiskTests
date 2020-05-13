using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels
{
    public class ClaimsPage : BasePage
    {
        public ClaimsPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://velocityrisk.com/claims/";
        }

        public void ClickExpandPanel()
        {
            var expandAllButton = Driver.FindElement(By.ClassName("expand_all_btn"));
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
            return Driver.FindElement(By.XPath("//span[contains(text(), '" + panelItemTitle + "')]"));
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
    }
}
