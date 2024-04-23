using OpenQA.Selenium;
using Module8.Wrappers;
using Module8.Helpers;

namespace Module8.Pages.StaysPage.FiltersAndSorting
{
    public class StaysPageSorting : BasePage
    {
        private PoliWebElement topSortingDropDown => driver.ScrollAndGetElement(By.XPath("//*[@data-testid='sorters-dropdown-trigger']"));
        private PoliWebElement priceLowestFirstOption => driver.ScrollAndGetElement(By.XPath("//button[@data-id='price']"));
        private List<PoliWebElement> hotelsPrices => driver.GetPoliWebElementList(By.XPath("//*[@data-testid='price-and-discounted-price']"));

        public StaysPageSorting(IWebDriver driver) : base(driver)
        {

        }

        public void SelectSortingPricelowestFirst()
        {
            topSortingDropDown.Click();
            priceLowestFirstOption.Click();
        }

        public List<string> IsHotelsPricesAscending() => hotelsPrices.Select(price => price.Text).ToList();
    }
}
