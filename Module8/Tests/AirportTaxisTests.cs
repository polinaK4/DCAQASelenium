using Module8.Pages.AirportTaxisPage;
using Module8.Pages.CommonElements;
using Module8.Pages.CommonElements.Header;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module8.Tests
{
    public class AirportTaxisTests : BaseTest
    {
        private Header header;
        private CookiesPopup cookiesPopup;
        private AirportTaxisPage airportTaxisPage;
        private AirportTaxisResultsPage airportTaxisResultsPage;
        private AirportTaxisCheckoutPage airportTaxisCheckoutPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://booking.com/");
            header = new Header(driver);
            cookiesPopup = new CookiesPopup(driver);
            airportTaxisPage = new AirportTaxisPage(driver);
            airportTaxisResultsPage = new AirportTaxisResultsPage(driver);
            airportTaxisCheckoutPage = new AirportTaxisCheckoutPage(driver);
            cookiesPopup.ClickDecline();
        }

        [Test]
        public void BookingAnAirportTaxi()
        {
            header.ClickAirportTaxisLink();
            airportTaxisPage.EnterPickupLocation("Paris - Charles de Gaulle Airport");
            airportTaxisPage.SelectFirstResultPickupLocation();
            airportTaxisPage.EnterDestination("Etretat Beach");
            airportTaxisPage.SelectFirstResultDestination();
            airportTaxisPage.ClickPickupDateField();
            airportTaxisPage.SelectPickupDatTomorrow();
            airportTaxisPage.ClickPickupTimeField();
            airportTaxisPage.SelectpickupHourOptionByText("11");
            airportTaxisPage.ConfirmTime();
            airportTaxisPage.ClickSearchButton();
            airportTaxisResultsPage.VerifyPickupLocationValue("Paris Charles de Gaulle Airport, Roissy-en-France, FR");
            airportTaxisResultsPage.VerifyDestinationValue("Plage d' Étretat, Étretat, FR");
            airportTaxisResultsPage.VerifyTaxiOptionsCount(3);
            airportTaxisResultsPage.ClickShowMoreButton();
            airportTaxisResultsPage.SelectLastTaxiOption();
            string lasttaxiOptionTitle = airportTaxisResultsPage.GetLastTaxiOptionTitle();
            airportTaxisResultsPage.ClickContinueButton();
            ClassicAssert.AreEqual("Charles de Gaulle Airport (CDG)", airportTaxisCheckoutPage.GetPickupLocationTitle());
            ClassicAssert.AreEqual("Plage d' Étretat", airportTaxisCheckoutPage.GetDestinationTitle());
            StringAssert.Contains(lasttaxiOptionTitle, airportTaxisCheckoutPage.GetTaxiDescription());
        }
    }
}
