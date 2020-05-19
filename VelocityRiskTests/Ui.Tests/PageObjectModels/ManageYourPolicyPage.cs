using OpenQA.Selenium;

namespace Ui.Tests.PageObjectModels
{
    public class ManageYourPolicyPage : HomePage
    {
        public ManageYourPolicyPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://portal.velocityrisk.com/Login.aspx?ReturnUrl=%2f";
        }

        public IWebElement HeaderElement => Driver.FindElement(By.XPath("//header"));
    }
}
