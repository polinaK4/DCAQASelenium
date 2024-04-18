using Module8.PoliWebElements;
using OpenQA.Selenium;

namespace Module8.Pages.CommonElements
{
    public class CookiesPopup : BasePage
    {
        private string cookiesPopupLocator = "//*[@id='onetrust-banner-sdk']";
        private ButtonElement declineButton => new ButtonElement(By.XPath("//*[@id='onetrust-reject-all-handler']"));

        public CookiesPopup(IWebDriver driver) : base(driver)
        {

        }

        public void DeclineCookies()
        {
            declineButton.ClickWhenReady();
            WaitForElementNotVisible(By.XPath(cookiesPopupLocator));
        }
    }
}
