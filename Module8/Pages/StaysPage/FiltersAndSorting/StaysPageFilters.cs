using Module8.Helpers;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage.FiltersAndSorting
{
    public class StaysPageFilters : BasePage
    {
        private PoliWebElement facilitiesShowMoreLessButton => driver.ScrollAndGetElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='hotelfacility']//button"));
        private PoliWebElement fitnessCentre => driver.ScrollAndGetElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='hotelfacility']//input[@name='hotelfacility=11']"));
        private PoliWebElement propertyRating5stars => driver.ScrollAndGetElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='class']//input[@name='class=5']"));

        public StaysPageFilters(IWebDriver driver) : base(driver)
        {

        }

        public void ClickFacilitiesShowMoreLessButton() => facilitiesShowMoreLessButton.Click();

        public void ClickFacilitiesFitnessCentre() => fitnessCentre.Click();

        public void ClickPropertyRating5stars() => propertyRating5stars.Click();
 
    }
}
