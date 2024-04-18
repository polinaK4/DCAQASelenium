using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.CarRentalsPage
{
    public class CarRentalsPage : BasePage
    {
        private ButtonElement searchButton => new ButtonElement(By.XPath("//*[@data-testid='searchbox-toolbox-submit-button']"));
        private PoliWebElement errorPickupEmpty => new PoliWebElement(By.XPath("//*[@data-testid='searchbox-toolbox-error-pick-up-validation-medium']"));
        private TextboxElement pickupInputField => new TextboxElement(By.XPath("//*[@data-testid='searchbox-toolbox-fts-pickup']"));        

        public CarRentalsPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickSearchButton() => searchButton.ClickWhenReady();
        public string GetErrorPickupEmptyText() => errorPickupEmpty.Text;

        public void EnterPickupLocation(string location) => pickupInputField.EnterText(location);
    }
}
