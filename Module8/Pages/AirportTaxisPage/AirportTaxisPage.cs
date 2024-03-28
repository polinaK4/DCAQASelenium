using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Module8.Pages.AirportTaxisPage
{
    public class AirportTaxisPage : BasePage
    {
        private IWebElement pickupLocationInputField => GetElementAfterItVisible(By.XPath("//input[@id='pickupLocation']"));
        private IWebElement destinationInputField => GetElementAfterItVisible(By.XPath("//input[@id='dropoffLocation']"));
        private IWebElement pickupLocationFirstResult => GetElementAfterItVisible(By.XPath("//button[@data-test='rw-autocomplete__link--0']"));
        private IWebElement destinationFirstResult => GetElementAfterItVisible(By.XPath("//button[@data-test='rw-autocomplete__link--0']"));
        private IWebElement pickupDateField => GetElement(By.XPath("//button[@data-test='rw-date-field__link--pickup']"));
        public List<IWebElement> enabledPickupDates => GetListOfElements(By.XPath("//*[@class='rw-c-date-picker__calendar-cell']"));
        private IWebElement pickupTimeField => GetElement(By.XPath("//button[@data-test='rw-time-field--pickup']"));       
        private SelectElement pickupHourDropdown => new SelectElement(GetElement(By.XPath("//select[@id='pickupHour']")));
        private IWebElement confirmTimeButton => GetElement(By.XPath("//*[@data-test='rw-time-picker__confirm-button']"));        
        private IWebElement searchButton => GetElement(By.XPath("//*[@class='ui-layout ui-layout--gutter-']//*[@name='searchButton']"));        

        public AirportTaxisPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterPickupLocation(string location) => pickupLocationInputField.SendKeys(location);

        public void EnterDestination(string destination) => destinationInputField.SendKeys(destination);

        public void SelectFirstResultPickupLocation() => pickupLocationFirstResult.Click();

        public void SelectFirstResultDestination() => destinationFirstResult.Click();

        public void ClickPickupDateField() => pickupDateField.Click();

        public void SelectPickupDatTomorrow() => enabledPickupDates[2].Click();

        public void ClickPickupTimeField() => pickupTimeField.Click();

        public void ConfirmTime() => confirmTimeButton.Click();

        public void SelectpickupHourOptionByText(string option) => pickupHourDropdown.SelectByText(option);

        public void ClickSearchButton() => searchButton.Click(); 
    }
}