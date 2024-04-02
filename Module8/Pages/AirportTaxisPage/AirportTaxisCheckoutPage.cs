using OpenQA.Selenium;

namespace Module8.Pages.AirportTaxisPage
{
    public class AirportTaxisCheckoutPage : BasePage
    {
        private IWebElement pickupLocationField => GetElementAfterItVisible(By.XPath("//*[@data-test='pick-up-location__title']"));
        private IWebElement destinationField => GetElementAfterItVisible(By.XPath("//*[@data-test='drop-off-location__title']"));
        private IWebElement taxiDescription => GetElement(By.XPath("//*[@data-testid='your-vehicle__vehicleDescription']"));
        

        public AirportTaxisCheckoutPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetPickupLocationTitle() => pickupLocationField.Text;

        public string GetDestinationTitle() => destinationField.Text;

        public string GetTaxiDescription() => taxiDescription.Text;
    }
}