using OpenQA.Selenium;

namespace Module8.Pages.CarRentalsPage
{
    public class CarRentalsPage : BasePage
    {
        private IWebElement searchButton => GetElementAfterItVisible(By.XPath("//*[@data-testid='searchbox-toolbox-submit-button']"));
        private IWebElement errorPickupEmpty => GetElementAfterItVisible(By.XPath("//*[@data-testid='searchbox-toolbox-error-pick-up-validation-medium']"));
        private IWebElement pickupInputField => GetElement(By.XPath("//*[@data-testid='searchbox-toolbox-fts-pickup']"));        

        public CarRentalsPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickSearchButton() => searchButton.Click();
        public string GetErrorPickupEmptyText() => errorPickupEmpty.Text;

        public void EnterPickupLocation(string location) => pickupInputField.SendKeys(location);
    }
}
