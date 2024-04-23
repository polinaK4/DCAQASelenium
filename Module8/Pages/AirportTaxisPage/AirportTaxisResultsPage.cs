using Module8.Helpers;
using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.AirportTaxisPage
{
    public class AirportTaxisResultsPage : BasePage
    {
        private PoliWebElement pickupLocationField => new PoliWebElement(By.XPath("//input[@name='pickup']"));
        private TextboxElement destinationField => new TextboxElement(By.XPath("//input[@name='dropoff']"));

        private string taxiOptionsLocator = "//*[@class='SRM_527ba3f0']";
        public List<PoliWebElement> taxiOptions => driver.GetPoliWebElementList(By.XPath(taxiOptionsLocator));
        public List<PoliWebElement> taxiOptionsTitles => driver.GetPoliWebElementList(By.XPath("//*[@class='SRM_f48a68a6 taxi-and-price__title']"));
        private PoliWebElement showMoreButton => driver.ScrollAndGetElement(By.XPath("//*[@data-test='taxi-car-card-wrapper__expandable-cta']"));
        private PoliWebElement continueButton => driver.ScrollAndGetElement(By.XPath("//*[@data-test='continue-action-bar__continue-button']"));     

        public AirportTaxisResultsPage(IWebDriver driver) : base(driver)
        {

        }

        public void VerifyPickupLocationValue(string expectedText) => WaitForExpectedValueAtribute(pickupLocationField, expectedText);

        public void VerifyDestinationValue(string expectedText) => WaitForExpectedValueAtribute(destinationField, expectedText);

        public void VerifyTaxiOptionsCount(int expectedCount) => WaitForExpectedElementsCount(By.XPath(taxiOptionsLocator), expectedCount);

        public void ClickShowMoreButton() => showMoreButton.Click();

        public void SelectLastTaxiOption() => taxiOptions.Last().Click();

        public string GetLastTaxiOptionTitle() => taxiOptionsTitles.Last().Text;

        public void ClickContinueButton() => continueButton.Click();
    }
}
