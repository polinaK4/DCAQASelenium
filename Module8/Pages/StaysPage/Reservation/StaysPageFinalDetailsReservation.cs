using OpenQA.Selenium;

namespace Module8.Pages.StaysPage.Reservation
{
    public class StaysPageFinalDetailsReservation : BasePage
    {
        private IWebElement checkYourBookingButton => GetElementAfterItVisible(By.XPath("//button[@name='review']"));
        private IWebElement overviewPopupBookAndPayButton => GetElementAfterItVisible(By.XPath("//*[@id='booking-overview__modal']//button[@name='book']"));
        

        public StaysPageFinalDetailsReservation(IWebDriver driver) : base(driver)
        {

        }

        public void ClickCheckYourBookingButton() => checkYourBookingButton.Click();

        public bool VerifyPopupBookAndPayEnabled() => overviewPopupBookAndPayButton.Enabled;
    }
}
