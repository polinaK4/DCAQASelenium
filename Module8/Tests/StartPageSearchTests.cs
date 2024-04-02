using Module8.Pages.CommonElements;
using Module8.Pages.HomePage;
using Module8.Pages.StaysPage.FiltersAndSorting;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module8.Tests
{
    public class StartPageSearchTests : BaseTest
    {
        private Header header;
        private SearchElements searchElements;
        private CookiesPopup cookiesPopup;
        private StaysPageFilters staysPageFilters;
        private StaysPageSorting staysPageSorting;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://booking.com/");
            searchElements = new SearchElements(driver);
            cookiesPopup = new CookiesPopup(driver);            
            cookiesPopup.ClickDecline();
        }

        [Test]
        public void SearchHotels()
        {            
            searchElements.EnterDestination("Krakow");
            var fromToDateSelector = searchElements.ClickDateSelector();
            fromToDateSelector.SelectDayOfTheWeek("1");
            fromToDateSelector.SelectDayOfTheWeek("4");
            var staysPageHotelsResults = searchElements.ClickSearchButton();
            ClassicAssert.GreaterOrEqual(staysPageHotelsResults.GetHotelCardsCount(), 1);            
        }

        [Test]
        public void SearchingForHotelsInASpecificCityWithFilters()
        {
            staysPageFilters = new StaysPageFilters(driver);
            staysPageSorting = new StaysPageSorting(driver);
            searchElements.EnterDestination("Zakopane");
            var fromToDateSelector = searchElements.ClickDateSelector();
            fromToDateSelector.SelectDayOfTheWeek("1");
            fromToDateSelector.SelectDayOfTheWeek("4");
            searchElements.ClickToOpenOcupancyConfig();
            searchElements.ClickToIncreaseAdults();
            searchElements.ClickToIncreaseAdults();
            ClassicAssert.AreEqual("4", searchElements.GetAdultsValue());
            searchElements.ClickToIncreaseChildren();
            ClassicAssert.AreEqual("1", searchElements.GetChildrenValue());
            searchElements.SelectChildrenAge("1", "8 years old");
            searchElements.ClickToOpenOcupancyConfig();            
            searchElements.ClickToIncreaseRooms();
            ClassicAssert.AreEqual("2", searchElements.GetRoomsValue());
            var staysPageHotelsResults = searchElements.ClickSearchButton();
            staysPageHotelsResults.ClickToCloseGeniusPopup();          
            staysPageFilters.ClickPropertyRating5stars();
            staysPageHotelsResults.CheckHotelsRating("5 out of 5");
            staysPageSorting.SelectSortingPricelowestFirst();
            staysPageSorting.CheckPricesSortingAsc();
            staysPageFilters.ClickFacilitiesShowMoreLessButton();
            staysPageFilters.ClickFacilitiesFitnessCentre();
            staysPageHotelsResults.CheckAppliedFilters("Fitness centre");
        }

        [Test]
        public void SearchSelectAndAttemptToBookAHotel()
        {
            searchElements.EnterDestination("Zakopane");
            var fromToDateSelector = searchElements.ClickDateSelector();
            fromToDateSelector.SelectDayOfTheWeek("1");
            fromToDateSelector.SelectDayOfTheWeek("4");
            searchElements.ClickToOpenOcupancyConfig();
            searchElements.ClickToIncreaseAdults();
            searchElements.ClickToIncreaseAdults();
            ClassicAssert.AreEqual("4", searchElements.GetAdultsValue());
            var staysPageHotelsResults = searchElements.ClickSearchButton();
            staysPageHotelsResults.ClickToCloseGeniusPopup();
            string firstResultTitle = staysPageHotelsResults.GetFirstResultTitle();
            var staysPageSelectedHotelDetails = staysPageHotelsResults.ClickFirstResultLink();
            SwitchToAnotherTab();
            ClassicAssert.AreEqual(firstResultTitle, staysPageSelectedHotelDetails.GetSelectedHotelTitle());
            staysPageSelectedHotelDetails.ClickReserveYourSelectionsButton();
            var staysPageReservePage = staysPageSelectedHotelDetails.ClickIllReserveButton();
            staysPageReservePage.EnterFirstName("John");
            staysPageReservePage.EnterLastName("Doe");
            staysPageReservePage.EnterEmail("john.doe@email.com");
            staysPageReservePage.EnterPhone("555555555");
            var staysPageFinalDetailsReservation = staysPageReservePage.ClickFinalDetailsButton();
            staysPageFinalDetailsReservation.ClickCheckYourBookingButton();
            ClassicAssert.AreEqual(true, staysPageFinalDetailsReservation.VerifyPopupBookAndPayEnabled());    
        }

        [Test]
        public void VerifyingLanguageChange()
        {
            header = new Header(driver);
            header.ClickLanguageButton();
            header.ClickRussianLanguageButton();
            header.CheckStaysLinkTitle("Жилье"); 
        }

        [Test]
        public void VerifyInvalidLogin()
        {
            var signInPage = header.ClickSignInButton();
            signInPage.EnterEmail("tststst@test.com");
            var createPasswordPage = signInPage.ClickContinueWithEmailButton();
            ClassicAssert.AreEqual(true, createPasswordPage.CheckPasswordFieldDisplayed());
            ClassicAssert.AreEqual(true, createPasswordPage.CheckConfirmPasswordFieldDisplayed());
        }
    }
}