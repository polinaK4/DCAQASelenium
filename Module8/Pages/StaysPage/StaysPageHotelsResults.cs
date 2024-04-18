using Module8.PoliWebElements;
using Module8.Wrappers;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage
{
    public class StaysPageHotelsResults : BasePage
    {
        private ButtonElement geniusPopupCancelButton => new ButtonElement(By.XPath("//button[@aria-label='Dismiss sign-in info.']"));
        private PoliWebElement firstResultLink => new PoliWebElement(By.XPath("//*[@data-testid='property-card'][1]//a[@data-testid='title-link']"));
        private PoliWebElement firstResultTitle => new PoliWebElement(By.XPath("//*[@data-testid='property-card'][1]//div[@data-testid='title']"));
        private List<IWebElement> hotelCards => GetListOfElements(By.XPath("//*[@data-testid='property-card']")).ToList();
        private List<IWebElement> hotelsRatings => GetListOfElements(By.XPath("//*[@class='b3f3c831be']"));
        private List<IWebElement> appliedFilters => GetListOfElements(By.XPath("//*[@class='d8ce5fca2f']/span"));        

        public StaysPageHotelsResults(IWebDriver driver) : base(driver)
        {

        }

        public void ClickToCloseGeniusPopup() => geniusPopupCancelButton.ClickWhenReady();

        public StaysPageSelectedHotelDetails ClickFirstResultLink()
        {
            firstResultLink.Click();
            return new StaysPageSelectedHotelDetails(driver);
        }

        public string GetFirstResultTitle() => firstResultTitle.Text;

        public int GetHotelCardsCount() => hotelCards.Count;

        public void CheckHotelsRating(string expectedLabel)
        {
            foreach (var rating in hotelsRatings)
            {
                string actualLabel = rating.GetAttribute("aria-label");
                ClassicAssert.AreEqual(expectedLabel, actualLabel);
            }
        }

        public bool CheckAppliedFilters(string expectedFilter)
        {
            bool match = false;
            foreach (var filter in appliedFilters)
            {
                if (filter.Text == expectedFilter)
                {
                    match = true;
                }
            }
            return match;
        }
    }
}