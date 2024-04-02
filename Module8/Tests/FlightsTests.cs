using Module8.Pages.CommonElements;
using Module8.Pages.FlightsPage;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module8.Tests
{
    public class FlightsTests : BaseTest
    {
        private Header headerElements;
        private CookiesPopup cookiesPopup;
        private FlightsPage flightsPage;
        private FlightsPageSearch flightsPageSearch;
        private FlightPageSearchResults flightPageSearchResults;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://booking.com/");
            headerElements = new Header(driver);
            cookiesPopup = new CookiesPopup(driver);
            flightsPage = new FlightsPage(driver);
            flightsPageSearch = new FlightsPageSearch(driver);
            flightPageSearchResults = new FlightPageSearchResults(driver);
            cookiesPopup.ClickDecline();
        }

        [Test]
        public void MultiCityFlightSearch()
        {
            headerElements.ClickFlightsLink();
            flightsPage.ClickMultiCityCheckbox();
            ClassicAssert.AreEqual(2, flightsPageSearch.CountDestinationsForms());
            flightsPageSearch.EnterFromLocationAndSelectFirstAirport("0", "Warsaw");
            flightsPageSearch.EnterToLocationAndSelectFirstAirport("0", "Rome");
            flightsPageSearch.SelectDate("0", "1");
            flightsPageSearch.EnterFromLocationAndSelectFirstAirport("1", "Rome");
            flightsPageSearch.EnterToLocationAndSelectFirstAirport("1", "Paris");
            flightsPageSearch.SelectDate("1", "2");
            flightsPageSearch.ClickMultiCityAddFlightButton();
            ClassicAssert.AreEqual(3, flightsPageSearch.CountDestinationsForms());
            flightsPageSearch.EnterFromLocationAndSelectFirstAirport("2", "Paris");
            flightsPageSearch.EnterToLocationAndSelectFirstAirport("2", "Warsaw");
            flightsPageSearch.SelectDate("2", "3");
            flightsPageSearch.ClickRemoveButtonForSegment("2");
            ClassicAssert.AreEqual(2, flightsPageSearch.CountDestinationsForms());
            string valueFromSegment0 = flightsPageSearch.GetValueFrom("0");
            string valueToSegment0 = flightsPageSearch.GetValueTo("0");
            string valueFromSegment1 = flightsPageSearch.GetValueFrom("1");
            string valueToSegment1 = flightsPageSearch.GetValueTo("1");
            flightsPageSearch.ClickSearchButton();
            ClassicAssert.AreEqual(valueFromSegment0, flightPageSearchResults.GetDepartureAiportOfFirstResult("0"));
            ClassicAssert.AreEqual(valueToSegment0, flightPageSearchResults.GetDestinationAiportOfFirstResult("0"));
            ClassicAssert.AreEqual(valueFromSegment1, flightPageSearchResults.GetDepartureAiportOfFirstResult("1"));
            ClassicAssert.AreEqual(valueToSegment1, flightPageSearchResults.GetDestinationAiportOfFirstResult("1"));
        }
    }
}