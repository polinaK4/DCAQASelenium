using OpenQA.Selenium;

namespace Module8.Pages.StaysPage
{
    public class StaysCommonElements : BasePage
    {
        private IWebElement geniusPopupCancelButton => GetElementAfterItVisible(By.XPath("//button[@aria-label='Dismiss sign-in info.']"));

        public StaysCommonElements(IWebDriver driver) : base(driver)
        {

        }

        public void ClickToCloseGeniusPopup() => geniusPopupCancelButton.Click();
    }
}
