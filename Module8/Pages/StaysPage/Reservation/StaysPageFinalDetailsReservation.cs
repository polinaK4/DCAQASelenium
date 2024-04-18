using Module8.PoliWebElements;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage.Reservation
{
    public class StaysPageFinalDetailsReservation : BasePage
    {
        private ButtonElement checkYourBookingButton => new ButtonElement(By.XPath("//button[@name='review']"));
        private ButtonElement overviewPopupBookAndPayButton => new ButtonElement(By.XPath("//*[@id='booking-overview__modal']//button[@name='book']"));

        public StaysPageFinalDetailsReservation(IWebDriver driver) : base(driver)
        {

        }

        public void ClickCheckYourBookingButton() => checkYourBookingButton.ClickWhenReady();

        public bool VerifyPopupBookAndPayEnabled() => overviewPopupBookAndPayButton.Enabled;
    }
}