using Module8.Helpers;
using Module8.Pages.CommonElements;
using Module8.Pages.StaysPage;
using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.StartPage.SearchElements
{
    public class SearchElements : BasePage
    {
        private TextboxElement searchInput => new TextboxElement(By.XPath("//input[@name='ss']"));
        private List<PoliWebElement> searchAutocompleteResults => driver.GetPoliWebElementList(By.XPath("//*[@data-testid='autocomplete-result']/div/div[1]"));
        private ButtonElement checkInOutDateSelector => new ButtonElement(By.XPath("//*[@data-testid='date-display-field-start']"));
        private ButtonElement searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private PoliWebElement occupancyConfig => new PoliWebElement(By.XPath("//*[@data-testid='occupancy-config']"));

        public SearchElements(IWebDriver driver) : base(driver)
        {

        }

        public void EnterDestination(string destination) => searchInput.EnterText(destination);

        public void SelectCheckInOutNextMonthUsingArrowKey() => FindAndFocusSpecificElementUsingArrowDownKey(2);

        public void SelectCheckInOutDatePlus5UsingArrowKey() => FindAndFocusSpecificElementUsingArrowDownKey(4);

        public FromToDateSelector ClickDateSelector()
        {
            checkInOutDateSelector.ClickWhenReady();
            return new FromToDateSelector(driver);
        }

        public StaysPageHotelsResults ClickSearchButton()
        {
            searchButton.ClickWhenReady();
            return new StaysPageHotelsResults(driver);
        }

        public GuestsConfig ClickToOpenGuestsConfig()
        {
            occupancyConfig.Click();
            return new GuestsConfig(driver);
        }        

        public string GetInputStringValue() => searchInput.GetAttribute("value");

        public void FindandFocusAutocompleteResultUsingArrowDownKey(string expectedValue) => FindElementByComparingAndFocusUsingArrowDownKey(searchAutocompleteResults, expectedValue);
    }
}
