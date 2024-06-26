﻿using OpenQA.Selenium;

namespace Module8.Pages.FlightsPage
{
    public class FlightPageSearchResults : BasePage
    {
        private string firstCardDepartureAirportLocator = "//*[@id='flight-card-0']//*[@data-testid='flight_card_segment_departure_airport_{0}']";
        private IWebElement FirstCardDepartureAiport(String segment) => GetElementAfterItVisible(By.XPath(String.Format(firstCardDepartureAirportLocator, segment)));

        private string firstCardDestinationAirportLocator = "//*[@id='flight-card-0']//*[@data-testid='flight_card_segment_destination_airport_{0}']";
        private IWebElement FirstCardDestinationAiport(String segment) => GetElementAfterItVisible(By.XPath(String.Format(firstCardDestinationAirportLocator, segment)));

        public FlightPageSearchResults(IWebDriver driver) : base(driver)
        {

        }

        public string GetDepartureAiportOfFirstResult(String segment) => FirstCardDepartureAiport(segment).Text;

        public string GetDestinationAiportOfFirstResult(String segment) => FirstCardDestinationAiport(segment).Text;
    }
}