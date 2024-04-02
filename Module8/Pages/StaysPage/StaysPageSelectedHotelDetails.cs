using Module8.Pages.StaysPage.Reservation;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage
{
    public class StaysPageSelectedHotelDetails : BasePage
    {
        private IWebElement selectedHotelTitle => GetElementAfterItVisible(By.XPath("//*[@id='hp_hotel_name']//h2"));
        private IWebElement reserveYourSelectionsButton => GetElementAfterItVisible(By.XPath("//*[@class='submitButton']/a"));
        private IWebElement illReserveButton => GetElementAfterItVisible(By.XPath("//*[@class='hprt-reservation-cta']/button"));

        public StaysPageSelectedHotelDetails(IWebDriver driver) : base(driver)
        {

        }        

        public string GetSelectedHotelTitle() => selectedHotelTitle.Text;

        public void ClickReserveYourSelectionsButton() => reserveYourSelectionsButton.Click();

        public StaysPageReservePage ClickIllReserveButton()
        {
            illReserveButton.Click();
            return new StaysPageReservePage(driver);
        }
    }
}
