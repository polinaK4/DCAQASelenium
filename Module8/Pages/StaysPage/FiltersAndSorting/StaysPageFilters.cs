using Module8.PoliWebElements;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage.FiltersAndSorting
{
    public class StaysPageFilters : BasePage
    {
        //private IWebElement facilitiesShowMoreLessButton => ScrollToGetElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='hotelfacility']//button"));
        private ButtonElement facilitiesShowMoreLessButton => new ButtonElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='hotelfacility']//button"));

        //private IWebElement fitnessCentre => ScrollToGetElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='hotelfacility']//input[@name='hotelfacility=11']"));
        private ButtonElement fitnessCentre => new ButtonElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='hotelfacility']//input[@name='hotelfacility=11']"));

        //private IWebElement propertyRating5stars => ScrollToGetElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='class']//input[@name='class=5']"));
        private ButtonElement propertyRating5stars => new ButtonElement(By.XPath("//*[@class='b4b4b2787f']/div[@data-testid='filters-sidebar'][1]/div[@data-filters-group='class']//input[@name='class=5']"));

        public StaysPageFilters(IWebDriver driver) : base(driver)
        {

        }

        public void ClickFacilitiesShowMoreLessButton() => facilitiesShowMoreLessButton.ScrollAndClickWhenReady();

        public void ClickFacilitiesFitnessCentre() => fitnessCentre.ScrollAndClickWhenReady();

        public void ClickPropertyRating5stars() => propertyRating5stars.ScrollAndClickWhenReady();
    }
}
