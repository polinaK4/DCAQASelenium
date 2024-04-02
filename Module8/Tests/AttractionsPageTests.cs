using Module8.Pages.AttractionsPage;
using Module8.Pages.CommonElements;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module8.Tests
{
    public class AttractionsPageTests : BaseTest
    {
        private Header header;
        private CookiesPopup cookiesPopup;
        private AttractionStartPage attractionStartPage;
        private FromToDateSelector dateSelector;
        private AttractionsResultPage attractionsResultPage;
        private AttractionDetailPage attractionDetailPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://booking.com/");
            header = new Header(driver);
            cookiesPopup = new CookiesPopup(driver);
            attractionStartPage = new AttractionStartPage(driver);
            dateSelector = new FromToDateSelector(driver);
            attractionsResultPage = new AttractionsResultPage(driver);
            attractionDetailPage = new AttractionDetailPage(driver);
            cookiesPopup.ClickDecline();
        }

        [Test]
        public void SearchingForAttractionsInASpecificCity()
        {
            header.ClickAttractionsLink();
            attractionStartPage.EnterDestination("London");
            attractionStartPage.ClickSearchBarFirstResult();
            attractionStartPage.ClickDateSelector();
            dateSelector.SelectDayOfTheWeek("1");
            dateSelector.SelectDayOfTheWeek("4");
            attractionStartPage.ClickSearchButton();
            attractionsResultPage.CheckDatesInputValue("Apr 1 - Apr 4");
            attractionsResultPage.CheckDestinationInputValue("London");
            attractionsResultPage.ClickAttractionsFirstResult();
            SwitchToAnotherTab();
            ClassicAssert.AreEqual("1", attractionDetailPage.GetSelectedByDefaultDateDay());
            ClassicAssert.AreEqual("Apr", attractionDetailPage.GetSelectedByDefaultDateMonth());
        }
    }
}