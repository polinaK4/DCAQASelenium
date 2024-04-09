using Module8.Pages.CommonElements;
using Module8.Pages.CommonElements.Header;
using Module8.Pages.StartPage.SearchElements;
using Module8.Pages.StaysPage;
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
        private CurrencyPopup currencyPopup;
        private StaysPageHotelsResults staysPageHotelsResults;

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
            var guestConfig = searchElements.ClickToOpenGuestsConfig();
            guestConfig.ClickToIncreaseAdults();
            guestConfig.ClickToIncreaseAdults();
            ClassicAssert.AreEqual("4", guestConfig.GetAdultsValue());
            guestConfig.ClickToIncreaseChildren();
            ClassicAssert.AreEqual("1", guestConfig.GetChildrenValue());
            guestConfig.SelectChildrenAge("1", "8 years old");
            searchElements.ClickToOpenGuestsConfig();
            guestConfig.ClickToIncreaseRooms();
            ClassicAssert.AreEqual("2", guestConfig.GetRoomsValue());
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
            var guestConfig = searchElements.ClickToOpenGuestsConfig();
            guestConfig.ClickToIncreaseAdults();
            guestConfig.ClickToIncreaseAdults();
            ClassicAssert.AreEqual("4", guestConfig.GetAdultsValue());
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
        //module9
        [Test]
        public void NavigateToRegisterPageUsingKeyboard()
        {
            header = new Header(driver);
            header.FindAndFocusFocusRegisterButtonUsingTab();
            ClickEnterKeyOnFocusedElement();
            VerifyUrlStartsWith("https://account.booking.com/sign-in");
        }

        [Test]
        public void ChangeCurrencyWithKeyboardNavigation()
        {
            header = new Header(driver);
            currencyPopup = new CurrencyPopup(driver);
            header.FindAndFocusCurrencyButtonUsingTab();
            ClickEnterKeyOnFocusedElement();
            currencyPopup.FindAndFocusCurrencyButtonUsingArrowDown();
            string focusedCurrency = currencyPopup.GetLastCurrencyValue();
            ClickEnterKeyOnFocusedElement();
            ClassicAssert.AreEqual(focusedCurrency, header.GetCurrentCurrencyValue());
        }

        [Test]
        public void SearchForStaysInASpecificLocation()
        {
            guestsConfig = new GuestsConfig(driver);
            staysPageHotelsResults = new StaysPageHotelsResults(driver);
            searchElements.FocusDestinationInputUsingTab();
            EnterTextToFocusedElement("New York");
            FocusNextElementUsingTabKey();
            ClickEnterKeyOnFocusedElement();
            searchElements.SelectCheckInOutNextMonthUsingArrowKey();
            ClickEnterKeyOnFocusedElement();
            FocusNextElementUsingTabKey();
            FocusNextElementUsingTabKey();
            FocusNextElementUsingTabKey();
            ClickEnterKeyOnFocusedElement();
            searchElements.SelectCheckInOutDatePlus5UsingArrowKey();
            ClickEnterKeyOnFocusedElement();
            FocusNextElementUsingTabKey();
            ClickEnterKeyOnFocusedElement();
            FocusNextElementUsingTabKey();
            ClickArrowUpButton();
            searchElements.FocusSearchButtonUsingTab();
            ClickEnterKeyOnFocusedElement();
            ClassicAssert.GreaterOrEqual(staysPageHotelsResults.GetHotelCardsCount(), 1);
        }

        [Test]
        public void SelectingACityFromAutoComplete()
        {
            searchElements.FocusDestinationInputUsingTab();
            EnterTextToFocusedElement("New Yo");
            searchElements.FindandFocusAutocompleteResultUsingArrowDownKey("New York Central Park");
            ClassicAssert.AreEqual(searchElements.GetInputStringValue(), "New York Central Park");
        }

        [Test]
        public void SkipToMainContent()
        {
            header = new Header(driver);
            FocusNextElementUsingTabKey();
            header.ClickSkipToMainContentUsingJS();
            ClassicAssert.AreEqual(123.2, CheckScrollPosition());
            ClickShiftAndTabButtons();
            ClassicAssert.AreEqual(0, CheckScrollPosition());
        }
    }
}