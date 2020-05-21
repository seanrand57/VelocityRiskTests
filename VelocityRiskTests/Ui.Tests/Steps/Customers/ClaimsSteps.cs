using OpenQA.Selenium;
using Shouldly;
using Ui.Tests.PageObjectModels;
using Ui.Tests.PersistenceModels;

namespace Ui.Tests.Steps.Customers
{
    public class ClaimsSteps : BaseSteps<ClaimsPage>
    {
        public ClaimsSteps(IWebDriver driver) : base(driver)
        {
            Page = new ClaimsPage(Driver);
        }

        public override void NavigateTo()
        {
            MenuBar.HoverCustomersMenuItem();
            MenuBar.ClickCustomersClaimsMenuItem();
        }

        public void GivenPanelItemPresented(PanelItem panelItem)
        {
            var isPanelPresented = Page.GetPanel(panelItem.Title).Displayed;
            isPanelPresented.ShouldBeTrue($"It was not possible to find panel item : {panelItem.Title} on UI");
        }

        public void GivenIExpandPanelItem(PanelItem panelItem)
        {
            // expand panel
            Page.ClickPanel(panelItem.Title);
        }

        public void ThenVerifyPanelContent(PanelItem panelItem)
        {
            var actualContent = Page.GetPanelContent(panelItem.Title);
            panelItem.Content.ShouldBe(actualContent, $"It was not possible to find expected content for : {panelItem.Title} on UI");

            // collapse panel
            Page.ClickPanel(panelItem.Title);
        }
    }
}
