using Module8.Pages.StaysPage.Reservation;
using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage
{
    public class StaysPageSelectedHotelDetails : BasePage
    {
        private PoliWebElement selectedHotelTitle => new PoliWebElement(By.XPath("//*[@id='hp_hotel_name']//h2"));
        private ButtonElement reserveYourSelectionsButton => new ButtonElement(By.XPath("//*[@class='submitButton']/a"));
        private ButtonElement illReserveButton => new ButtonElement(By.XPath("//*[@class='hprt-reservation-cta']/button"));

        public StaysPageSelectedHotelDetails(IWebDriver driver) : base(driver)
        {

        }        

        public string GetSelectedHotelTitle() => selectedHotelTitle.Text;

        public void ClickReserveYourSelectionsButton() => reserveYourSelectionsButton.ClickWhenReady();

        public StaysPageReservePage ClickIllReserveButton()
        {
            illReserveButton.ClickWhenReady();
            return new StaysPageReservePage(driver);
        }
    }
}
