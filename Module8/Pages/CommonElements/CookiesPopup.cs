using OpenQA.Selenium;

namespace Module8.Pages.CommonElements
{
    public class CookiesPopup : BasePage
    {
        private IWebElement declineButton => GetElementAfterItVisible(By.XPath("//*[@id='onetrust-reject-all-handler']"));

        public CookiesPopup(IWebDriver driver) : base(driver)
        {

        }

        public void ClickDecline() => declineButton.Click();
    }
}
