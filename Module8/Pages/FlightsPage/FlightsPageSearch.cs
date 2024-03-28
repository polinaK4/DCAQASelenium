using OpenQA.Selenium;

namespace Module8.Pages.FlightsPage
{
    public class FlightsPageSearch : BasePage
    {
        private List<IWebElement> multipleDestinationsForms => GetListOfElements(By.XPath("//*[@data-ui-name='segments_list_item']"));
        //from:
        private string fromSelectorLocator = "//*[@data-ui-name='input_location_from_segment_{0}']";
        private IWebElement FromSelectorBySegment(String segment) => GetElement(By.XPath(String.Format(fromSelectorLocator, segment)));

        private string fromValueLocator = "//*[@data-ui-name='input_location_from_segment_{0}']/div[1]//b";
        private IWebElement FromValueBySegment(String segment) => GetElement(By.XPath(String.Format(fromValueLocator, segment)));
        //to:
        private string toSelectorLocator = "//*[@data-ui-name='input_location_to_segment_{0}']";
        private IWebElement ToSelectorBySegment(String segment) => GetElement(By.XPath(String.Format(toSelectorLocator, segment)));

        private string toValueLocator = "//*[@data-ui-name='input_location_to_segment_{0}']/div[1]//b";
        private IWebElement ToValueBySegment(String segment) => GetElement(By.XPath(String.Format(toValueLocator, segment)));


        private string dateSelectorLocator = "//*[@data-ui-name='button_date_segment_{0}']";
        private IWebElement DateSelectorBySegment(String segment) => GetElement(By.XPath(String.Format(dateSelectorLocator, segment)));
        
        private IWebElement locationInput => GetElementAfterItVisible(By.XPath("//*[@data-ui-name='input_text_autocomplete']"));
        private IWebElement firstSuggestedAirportResult => GetElementAfterItVisible(By.XPath("//*[@id='flights-searchbox_suggestions']/li[2]"));

        private string nextMonth1stWeekGridSellLocator = "//*[@data-ui-name='calendar_body']/div/div[2]//tbody/tr[1]/td[@role='gridcell'][{0}]";
        private IWebElement DateGrigsells(String day) => GetElement(By.XPath(String.Format(nextMonth1stWeekGridSellLocator, day)));

        private IWebElement multiCityAddFlightButton => GetElement(By.XPath("//*[@data-ui-name='button_segment_add']"));

        private string removeFlightButtonLocator = "//*[@data-ui-name='button_remove_segment_{0}']";
        private IWebElement RemoveFlightButtonBySegment(String segment) => GetElement(By.XPath(String.Format(removeFlightButtonLocator, segment)));

        private IWebElement searchButton => GetElement(By.XPath("//*[@data-ui-name='button_search_submit']"));

        public FlightsPageSearch(IWebDriver driver) : base(driver)
        {

        }

        public int CountDestinationsForms() => multipleDestinationsForms.Count;

        public void ClickFromSelector(String segment) => FromSelectorBySegment(segment).Click();

        public void ClickToSelector(String segment) => ToSelectorBySegment(segment).Click();

        public void ClickDateSelector(String segment) => DateSelectorBySegment(segment).Click();

        public void InputLocation(string location) => locationInput.SendKeys(location);

        public void ClickFirstSuggestedSearchResult() => firstSuggestedAirportResult.Click();

        public void ClickSpecificDate(String day) => DateGrigsells(day).Click();

        public void ClickMultiCityAddFlightButton() => multiCityAddFlightButton.Click();

        public void ClickRemoveButtonForSegment(String segment) => RemoveFlightButtonBySegment(segment).Click();

        public void ClickSearchButton() => searchButton.Click();

        public string GetValueFrom(String segment) => FromValueBySegment(segment).Text;

        public string GetValueTo(String segment) => ToValueBySegment(segment).Text;


        public void EnterFromLocationAndSelectFirstAirport(String segment, string location)
        {
            ClickFromSelector(segment);
            InputLocation(location);
            ClickFirstSuggestedSearchResult();
        }

        public void EnterToLocationAndSelectFirstAirport(String segment, string location)
        {
            ClickToSelector(segment);
            InputLocation(location);
            ClickFirstSuggestedSearchResult();
        }

        public void SelectDate(String segment, String day)
        {
            ClickDateSelector(segment);
            ClickSpecificDate(day);
        }
    }
}