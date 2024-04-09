using Module8.Pages.CommonElements;
using Module8.Pages.StaysPage;
using OpenQA.Selenium;

namespace Module8.Pages.StartPage.SearchElements
{
    public class SearchElements : BasePage
    {
        private IWebElement searchInput => GetElement(By.XPath("//input[@name='ss']"));
        private List<IWebElement> searchAutocompleteResults => GetListOfElements(By.XPath("//*[@data-testid='autocomplete-result']/div/div[1]"));
        private IWebElement checkInOutDateSelector => ScrollToGetElement(By.XPath("//*[@data-testid='date-display-field-start']"));
        private IWebElement searchButton => GetElement(By.XPath("//button[@type='submit']"));
        private IWebElement occupancyConfig => GetElement(By.XPath("//*[@data-testid='occupancy-config']"));

        public SearchElements(IWebDriver driver) : base(driver)
        {

        }

        public void FocusDestinationInputUsingTab() => FindAndFocusElementUsingTabKey(searchInput, "name");

        public void EnterDestination(string destination) => searchInput.SendKeys(destination);

        public void SelectCheckInOutNextMonthUsingArrowKey() => FindAndFocusSpecificElementUsingArrowDownKey(2);

        public void SelectCheckInOutDatePlus5UsingArrowKey() => FindAndFocusSpecificElementUsingArrowDownKey(4);

        public FromToDateSelector ClickDateSelector()
        {
            ClickElementAfterClickable(checkInOutDateSelector);
            return new FromToDateSelector(driver);
        }

        public StaysPageHotelsResults ClickSearchButton()
        {
            searchButton.Click();
            return new StaysPageHotelsResults(driver);
        }

        public void FocusSearchButtonUsingTab() => FindAndFocusElementUsingTabKey(searchButton, "type");

        public GuestsConfig ClickToOpenGuestsConfig()
        {
            occupancyConfig.Click();
            return new GuestsConfig(driver);
        }        

        public string GetInputStringValue() => searchInput.GetAttribute("value");

        public void FindandFocusAutocompleteResultUsingArrowDownKey(string expectedValue) => FindElementByComparingAndFocusUsingArrowDownKey(searchAutocompleteResults, expectedValue);
    }
}
