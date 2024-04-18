using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.FlightsPage
{
    public class FlightsPageSearch : BasePage
    {
        private List<IWebElement> multipleDestinationsForms => GetListOfElements(By.XPath("//*[@data-ui-name='segments_list_item']"));
        //from:
        private string fromSelectorLocator = "//*[@data-ui-name='input_location_from_segment_{0}']";
        private PoliWebElement FromSelectorBySegment(String segment) => new PoliWebElement(By.XPath(String.Format(fromSelectorLocator, segment)));

        private string fromValueLocator = "//*[@data-ui-name='input_location_from_segment_{0}']/div[1]//b";
        private PoliWebElement FromValueBySegment(String segment) => new PoliWebElement(By.XPath(String.Format(fromValueLocator, segment)));
        //to:
        private string toSelectorLocator = "//*[@data-ui-name='input_location_to_segment_{0}']";
        private PoliWebElement ToSelectorBySegment(String segment) => new PoliWebElement(By.XPath(String.Format(toSelectorLocator, segment)));

        private string toValueLocator = "//*[@data-ui-name='input_location_to_segment_{0}']/div[1]//b";
        private PoliWebElement ToValueBySegment(String segment) => new PoliWebElement(By.XPath(String.Format(toValueLocator, segment)));


        private string dateSelectorLocator = "//*[@data-ui-name='button_date_segment_{0}']";
        private PoliWebElement DateSelectorBySegment(String segment) => new PoliWebElement(By.XPath(String.Format(dateSelectorLocator, segment)));
        
        private TextboxElement locationInput => new TextboxElement(By.XPath("//*[@data-ui-name='input_text_autocomplete']"));
        private PoliWebElement firstSuggestedAirportResult => new PoliWebElement(By.XPath("//*[@id='flights-searchbox_suggestions']/li[2]"));

        private string nextMonth1stWeekGridSellLocator = "//*[@data-ui-name='calendar_body']/div/div[2]//tbody/tr[1]/td[@role='gridcell'][{0}]";
        private PoliWebElement DateGrigsells(String day) => new PoliWebElement(By.XPath(String.Format(nextMonth1stWeekGridSellLocator, day)));

        private ButtonElement multiCityAddFlightButton => new ButtonElement(By.XPath("//*[@data-ui-name='button_segment_add']"));

        private string removeFlightButtonLocator = "//*[@data-ui-name='button_remove_segment_{0}']";
        private PoliWebElement RemoveFlightButtonBySegment(String segment) => new PoliWebElement(By.XPath(String.Format(removeFlightButtonLocator, segment)));

        private ButtonElement searchButton => new ButtonElement(By.XPath("//*[@data-ui-name='button_search_submit']"));

        public FlightsPageSearch(IWebDriver driver) : base(driver)
        {

        }

        public int CountDestinationsForms() => multipleDestinationsForms.Count;

        public void ClickFromSelector(String segment) => FromSelectorBySegment(segment).Click();

        public void ClickToSelector(String segment) => ToSelectorBySegment(segment).Click();

        public void ClickDateSelector(String segment) => DateSelectorBySegment(segment).Click();

        public void InputLocation(string location) => locationInput.EnterText(location);

        public void ClickFirstSuggestedSearchResult() => firstSuggestedAirportResult.Click();

        public void ClickSpecificDate(String day) => DateGrigsells(day).Click();

        public void ClickMultiCityAddFlightButton() => multiCityAddFlightButton.ClickWhenReady();

        public void ClickRemoveButtonForSegment(String segment) => RemoveFlightButtonBySegment(segment).Click();

        public void ClickSearchButton() => searchButton.ClickWhenReady();

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