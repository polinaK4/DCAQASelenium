using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage
{
    public class StaysPageHotelsResults : BasePage
    {
        private IWebElement firstResultLink => GetElementAfterItVisible(By.XPath("//*[@data-testid='property-card'][1]//a[@data-testid='title-link']"));
        private IWebElement firstResultTitle => GetElementAfterItVisible(By.XPath("//*[@data-testid='property-card'][1]//div[@data-testid='title']"));
        private List<IWebElement> hotelCards => GetListOfElements(By.XPath("//*[@data-testid='property-card']"));
        private List<IWebElement> hotelsRatings => GetListOfElements(By.XPath("//*[@class='b3f3c831be']"));
        private List<IWebElement> appliedFilters => GetListOfElements(By.XPath("//*[@class='d8ce5fca2f']/span"));        

        public StaysPageHotelsResults(IWebDriver driver) : base(driver)
        {

        }

        public void ClickFirstResultLink() => firstResultLink.Click();

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