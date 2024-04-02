using NUnit.Framework.Legacy;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage.FiltersAndSorting
{
    public class StaysPageSorting : BasePage
    {
        private IWebElement topSortingDropDown => ScrollToGetElement(By.XPath("//*[@data-testid='sorters-dropdown-trigger']"));
        private IWebElement priceLowestFirstOption => GetElementAfterItVisible(By.XPath("//button[@data-id='price']"));
        private List<IWebElement> hotelsPrices => GetListOfElements(By.XPath("//*[@data-testid='price-and-discounted-price']"));

        public StaysPageSorting(IWebDriver driver) : base(driver)
        {

        }

        public void SelectSortingPricelowestFirst()
        {
            topSortingDropDown.Click();
            priceLowestFirstOption.Click();
        }

        public void CheckPricesSortingAsc() => ClassicAssert.That(hotelsPrices, Is.Ordered.Ascending);
    }
}
