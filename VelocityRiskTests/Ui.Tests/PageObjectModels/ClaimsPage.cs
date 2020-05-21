using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Ui.Tests.PageObjectModels
{
    public class ClaimsPage : HomePage
    {
        public ClaimsPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://velocityrisk.com/claims/";
        }

        public void ClickFileAClaimMenuItem() => ClickPanel("File a claim");

        public void ExpandAllPanels()
        {
            var expandAllButton = Driver.FindElement(By.ClassName("expand_all_btn"));
            WaitForClickable(expandAllButton);
            expandAllButton.Click();
        }

        public void ClickPanel(string name)
        {
            var spanElement = GetPanel(name);
            var divElement = spanElement.FindElement(By.XPath("ancestor::div[@class = 'customer_drop_block']"));
            ScrollToElement(divElement);

            var aElement = divElement.FindElement(By.XPath("a[@class = 'customer_head_part']"));
            WaitForClickable(aElement);

            aElement.Click();
        }

        public IWebElement GetPanel(string title)
        {
            return Driver.FindElement(By.XPath("//span[contains(text(), '" + title + "')]"));
        }

        public string GetPanelContent(string title)
        {
            var panelItem = GetPanel(title);
            var panelElement = panelItem.FindElement(By.XPath("ancestor::div[@class = 'customer_drop_block']/div"));

            return panelElement.GetAttribute("innerText");
        }

        public IWebElement QuestionsOnAnExistingClaimElement => Driver.FindElement(By.Id("questions-on-an-existing-claim"));

        public IWebElement GetLinkFromFileAClaimSection(string linkName) => Driver.FindElement(By.XPath($"//p/strong[contains(text(), '{linkName}')]/following-sibling::a[contains(@class, 'underline')]"));
    }
}
