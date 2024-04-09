using Module8.Pages.CarRentalsPage;
using Module8.Pages.CommonElements;
using Module8.Pages.CommonElements.Header;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module8.Tests
{
    public class CarRentalsTests : BaseTest
    {
        private Header headerElements;
        private CookiesPopup cookiesPopup;
        private CarRentalsPage carRentalsPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://booking.com/");
            headerElements = new Header(driver);
            cookiesPopup = new CookiesPopup(driver);
            carRentalsPage = new CarRentalsPage(driver);
            cookiesPopup.ClickDecline();
        }

        [Test]
        public void NegativeChecksForCarRentals()
        {
            headerElements.ClickCarRentalsLink();
            carRentalsPage.ClickSearchButton();
            ClassicAssert.AreEqual("Please provide a pick-up location", carRentalsPage.GetErrorPickupEmptyText());
            carRentalsPage.EnterPickupLocation("asdfg");
            carRentalsPage.ClickSearchButton();
            ClassicAssert.AreEqual("Please provide a pick-up location", carRentalsPage.GetErrorPickupEmptyText());
        }
    }
}