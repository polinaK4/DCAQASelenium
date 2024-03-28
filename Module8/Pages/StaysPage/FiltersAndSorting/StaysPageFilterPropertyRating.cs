using OpenQA.Selenium;

namespace Module8.Pages.StaysPage.FiltersAndSorting
{
    public class StaysPageFilterPropertyRating : BasePage
    {
        private IWebElement propertyRating5stars => ScrollToGetElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='class']//input[@name='class=5']"));


        public StaysPageFilterPropertyRating(IWebDriver driver) : base(driver)
        {

        }

        public void ClickPropertyRating5stars() => propertyRating5stars.Click();
    }
}
