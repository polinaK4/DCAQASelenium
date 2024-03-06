using OpenQA.Selenium;

namespace Module7.Pages.Authorization
{
    public class LogOutPage : BasePage
    {
        private string logoutButtonLocator = "//a[contains(@href,'/logout')]";
        private IWebElement logoutButton => GetElement(By.XPath(logoutButtonLocator));

        public LogOutPage(IWebDriver driver) :base(driver)
        {
            
        }

        public void ClickLogoutButton() => logoutButton.Click();
    }
}
