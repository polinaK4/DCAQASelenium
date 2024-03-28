using Module8.Pages.Authorization;
using Module8.Pages.CommonElements;
using Module8.Pages.HomePage;
using Module8.Pages.StaysPage;
using Module8.Pages.StaysPage.FiltersAndSorting;
using Module8.Pages.StaysPage.Reservation;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module8.Tests
{
    public class StartPageSearchTests : BaseTest
    {
        private Header header;
        private SearchElements searchElements;
        private CookiesPopup cookiesPopup;
        private FromToDateSelector dateSelector;
        private StaysPageFilterPropertyRating staysPageFiltersPropertyRating;
        private StaysCommonElements staysCommonElements;
        private StaysPageSorting staysPageSorting;
        private StaysPageFilterFacilities staysPageFilterFacilities;
        private StaysPageHotelsResults staysPageHotelsResults;
        private StaysPageSelectedHotelDetails staysPageSelectedHotelDetails;
        private StaysPageReservePage staysPageReservePage;
        private StaysPageFinalDetailsReservation staysPageFinalDetailsReservation;
        private SignInPage signInPage;
        private CreatePasswordPage createPasswordPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://booking.com/");
            searchElements = new SearchElements(driver);
            cookiesPopup = new CookiesPopup(driver);
            //dateSelector = new FromToDateSelector(driver);
            staysPageFiltersPropertyRating = new StaysPageFilterPropertyRating(driver);
            staysCommonElements = new StaysCommonElements(driver);
            staysPageSorting = new StaysPageSorting(driver);
            staysPageFilterFacilities = new StaysPageFilterFacilities(driver);
            //staysPageHotelsResults = new StaysPageHotelsResults(driver);
            staysPageSelectedHotelDetails = new StaysPageSelectedHotelDetails(driver);
            staysPageReservePage = new StaysPageReservePage(driver);
            staysPageFinalDetailsReservation = new StaysPageFinalDetailsReservation(driver);
            signInPage = new SignInPage(driver);
            header = new Header(driver);
            createPasswordPage= new CreatePasswordPage(driver);
            cookiesPopup.ClickDecline();
        }

        [Test]
        public void SearchHotels()
        {            
            searchElements.EnterDestination("Krakow");
            var fromToDateSelector = searchElements.ClickDateSelector();
            fromToDateSelector.SelectDayOfTheWeek("1");
            fromToDateSelector.SelectDayOfTheWeek("4");
            //dateSelector.SelectDayOfTheWeek("1");
            //dateSelector.SelectDayOfTheWeek("4");
            var staysPageHotelsResults = searchElements.ClickSearchButton();
            ClassicAssert.GreaterOrEqual(staysPageHotelsResults.GetHotelCardsCount(), 1);            
        }

        [Test]
        public void SearchingForHotelsInASpecificCityWithFilters()
        {
            searchElements.EnterDestination("Zakopane");
            searchElements.ClickDatesSelector();
            dateSelector.SelectDayOfTheWeek("1");
            dateSelector.SelectDayOfTheWeek("4");
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
            searchElements.ClickSearchButton();
            staysCommonElements.ClickToCloseGeniusPopup();
            staysPageFiltersPropertyRating.ClickPropertyRating5stars();
            staysPageHotelsResults.CheckHotelsRating("5 out of 5");
            staysPageSorting.SelectSortingPricelowestFirst();
            staysPageSorting.CheckPricesSortingAsc();
            staysPageFilterFacilities.ClickFacilitiesShowMoreLessButton();
            staysPageFilterFacilities.ClickFacilitiesFitnessCentre();
            staysPageHotelsResults.CheckAppliedFilters("Fitness centre");
        }

        [Test]
        public void SearchSelectAndAttemptToBookAHotel()
        {
            searchElements.EnterDestination("Zakopane");
            searchElements.ClickDatesSelector();
            dateSelector.SelectDayOfTheWeek("1");
            dateSelector.SelectDayOfTheWeek("4");
            searchElements.ClickToOpenOcupancyConfig();
            searchElements.ClickToIncreaseAdults();
            searchElements.ClickToIncreaseAdults();
            ClassicAssert.AreEqual("4", searchElements.GetAdultsValue());
            searchElements.ClickSearchButton();
            staysCommonElements.ClickToCloseGeniusPopup();
            string firstResultTitle = staysPageHotelsResults.GetFirstResultTitle();
            staysPageHotelsResults.ClickFirstResultLink();
            SwitchToAnotherTab();
            ClassicAssert.AreEqual(firstResultTitle, staysPageSelectedHotelDetails.GetSelectedHotelTitle());
            staysPageSelectedHotelDetails.ClickReserveYourSelectionsButton();
            staysPageSelectedHotelDetails.ClickIllReserveButton();
            staysPageReservePage.EnterFirstName("John");
            staysPageReservePage.EnterLastName("Doe");
            staysPageReservePage.EnterEmail("john.doe@email.com");
            staysPageReservePage.EnterPhone("555555555");
            staysPageReservePage.ClickFinalDetailsButton();
            staysPageFinalDetailsReservation.ClickCheckYourBookingButton();
            ClassicAssert.AreEqual(true, staysPageFinalDetailsReservation.VerifyPopupBookAndPayEnabled());    
        }

        [Test]
        public void VerifyingLanguageChange()
        {
            header.ClickLanguageButton();
            header.ClickRussianLanguageButton();
            header.CheckStaysLinkTitle("Жилье"); 
        }

        [Test]
        public void VerifyInvalidLogin()
        {
            header.ClickSignInButton();
            signInPage.EnterEmail("tststst@test.com");
            signInPage.ClickContinueWithEmailButton();
            ClassicAssert.AreEqual(true, createPasswordPage.CheckPasswordFieldDisplayed());
            ClassicAssert.AreEqual(true, createPasswordPage.CheckConfirmPasswordFieldDisplayed());
        }
    }
}