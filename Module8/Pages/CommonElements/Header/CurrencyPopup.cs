using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.CommonElements.Header
{
    public class CurrencyPopup : BasePage
    {
        private List<IWebElement> currenciesButtons => GetListOfElements(By.XPath("//*[@data-testid='selection-item']"));
        private List<IWebElement> currenciesValues => GetListOfElements(By.XPath("//*[@data-testid='selection-item']/div/div[1]/span/div"));

        public CurrencyPopup(IWebDriver driver) : base(driver)
        {

        }

        public void FindAndFocusCurrencyButtonUsingArrowDown() => FindAndFocusSpecificElementUsingArrowDownKey(currenciesButtons.Count);

        public string GetLastCurrencyValue() => currenciesValues.Last().Text;
    }
}
