using OpenQA.Selenium;

namespace Module8.Pages.CommonElements
{
    public class CookiesPopup : BasePage
    {
        private string cookiesPopupLocator = "//*[@id='onetrust-banner-sdk']";
        private IWebElement declineButton => GetElementAfterItVisible(By.XPath("//*[@id='onetrust-reject-all-handler']"));

        public CookiesPopup(IWebDriver driver) : base(driver)
        {

        }

        //public void ClickDecline() => declineButton.Click();

        public void DeclineCookies()
        {
            declineButton.Click();
            WaitForElementNotVisible(By.XPath(cookiesPopupLocator));
        }
    }
}
