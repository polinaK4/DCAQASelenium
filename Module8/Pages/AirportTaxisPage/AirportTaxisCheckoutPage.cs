using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.AirportTaxisPage
{
    public class AirportTaxisCheckoutPage : BasePage
    {
        private PoliWebElement pickupLocationField => new PoliWebElement(By.XPath("//*[@data-test='pick-up-location__title']"));
        private PoliWebElement destinationField => new PoliWebElement(By.XPath("//*[@data-test='drop-off-location__title']"));
        private PoliWebElement taxiDescription => new PoliWebElement(By.XPath("//*[@data-testid='your-vehicle__vehicleDescription']"));        

        public AirportTaxisCheckoutPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetPickupLocationTitle() => pickupLocationField.Text;

        public string GetDestinationTitle() => destinationField.Text;

        public string GetTaxiDescription() => taxiDescription.Text;
    }
}