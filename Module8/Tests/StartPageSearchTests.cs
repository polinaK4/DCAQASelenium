using Module8.Helpers;
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
        private GuestsConfig guestsConfig;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://booking.com/");
            searchElements = new SearchElements(driver);
            cookiesPopup = new CookiesPopup(driver);
            //cookiesPopup.ClickDecline();
            cookiesPopup.DeclineCookies();
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
        ///module9/ 
        [Test]
        public void NavigateToRegisterPageUsingKeyboard()
        {
            header = new Header(driver);
            driver.PressTabKey(7);
            driver.ClickEnterKeyOnFocusedElement();
            VerifyUrlStartsWith("https://account.booking.com/sign-in");
        }

        [Test]
        public void ChangeCurrencyWithKeyboardNavigation()
        {
            header = new Header(driver);
            currencyPopup = new CurrencyPopup(driver);
            driver.PressTabKey(3);
            driver.ClickEnterKeyOnFocusedElement();
            currencyPopup.FindAndFocusCurrencyButtonUsingArrowDown();
            string focusedCurrency = currencyPopup.GetLastCurrencyValue();
            driver.ClickEnterKeyOnFocusedElement();
            ClassicAssert.AreEqual(focusedCurrency, header.GetCurrentCurrencyValue());
        }

        [Test]
        public void SearchForStaysInASpecificLocation()
        {
            guestsConfig = new GuestsConfig(driver);
            staysPageHotelsResults = new StaysPageHotelsResults(driver);
            driver.PressTabKey(16);
            driver.EnterTextToFocusedElement("New York");
            driver.PressTabKey(1);
            driver.ClickEnterKeyOnFocusedElement();
            searchElements.SelectCheckInOutNextMonthUsingArrowKey();
            driver.ClickEnterKeyOnFocusedElement();
            driver.PressTabKey(3);
            driver.ClickEnterKeyOnFocusedElement();
            searchElements.SelectCheckInOutDatePlus5UsingArrowKey();
            driver.ClickEnterKeyOnFocusedElement();
            driver.PressTabKey(1);
            driver.ClickEnterKeyOnFocusedElement();
            driver.PressTabKey(1);
            driver.ClickArrowUpKey();
            driver.PressTabKey(3);
            driver.ClickEnterKeyOnFocusedElement();
            driver.PressTabKey(1);
            driver.ClickEnterKeyOnFocusedElement();
            ClassicAssert.GreaterOrEqual(staysPageHotelsResults.GetHotelCardsCount(), 1);
        }

        [Test]
        public void SelectingACityFromAutoComplete()
        {
            driver.PressTabKey(16);
            searchElements.EnterDestination("New Yo");
            searchElements.FindandFocusAutocompleteResultUsingArrowDownKey("New York Central Park");
            ClassicAssert.AreEqual("New York Central Park", searchElements.GetInputStringValue());
        }

        [Test]
        public void SkipToMainContent()
        {
            header = new Header(driver);
            driver.PressTabKey(1);
            header.ClickSkipToMainContentUsingJS();
            ClassicAssert.AreEqual(123.2, CheckScrollPosition());
            driver.ClickShiftAndTabButtons();
            ClassicAssert.AreEqual(0, CheckScrollPosition());
        }
    }
}