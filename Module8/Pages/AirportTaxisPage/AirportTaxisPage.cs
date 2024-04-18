using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Module8.Pages.AirportTaxisPage
{
    public class AirportTaxisPage : BasePage
    {
        private TextboxElement pickupLocationInputField => new TextboxElement(By.XPath("//input[@id='pickupLocation']"));
        private TextboxElement destinationInputField => new TextboxElement(By.XPath("//input[@id='dropoffLocation']"));
        private PoliWebElement pickupLocationFirstResult => new PoliWebElement(By.XPath("//button[@data-test='rw-autocomplete__link--0']"));
        private PoliWebElement destinationFirstResult => new PoliWebElement(By.XPath("//button[@data-test='rw-autocomplete__link--0']"));
        private PoliWebElement pickupDateField => new PoliWebElement(By.XPath("//button[@data-test='rw-date-field__link--pickup']"));
        public List<IWebElement> enabledPickupDates => GetListOfElements(By.XPath("//*[@class='rw-c-date-picker__calendar-cell']"));
        private PoliWebElement pickupTimeField => new PoliWebElement(By.XPath("//button[@data-test='rw-time-field--pickup']"));
        //private SelectElement pickupHourDropdown => new SelectElement(GetElement(By.XPath("//select[@id='pickupHour']")));
        private DropDownElement pickupHourDropdown => new DropDownElement(By.XPath("//select[@id='pickupHour']"));
        private ButtonElement confirmTimeButton => new ButtonElement(By.XPath("//*[@data-test='rw-time-picker__confirm-button']"));        
        private ButtonElement searchButton => new ButtonElement(By.XPath("//*[@class='ui-layout ui-layout--gutter-']//*[@name='searchButton']"));        

        public AirportTaxisPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterPickupLocation(string location) => pickupLocationInputField.EnterText(location);

        public void EnterDestination(string destination) => destinationInputField.EnterText(destination);

        public void SelectFirstResultPickupLocation() => pickupLocationFirstResult.Click();

        public void SelectFirstResultDestination() => destinationFirstResult.Click();

        public void ClickPickupDateField() => pickupDateField.Click();

        public void SelectPickupDatTomorrow() => enabledPickupDates[2].Click();

        public void ClickPickupTimeField() => pickupTimeField.Click();

        public void ConfirmTime() => confirmTimeButton.ClickWhenReady();

        public void SelectpickupHourOptionByText(string option) => pickupHourDropdown.SelectByText(option);

        public void ClickSearchButton() => searchButton.ClickWhenReady(); 
    }
}