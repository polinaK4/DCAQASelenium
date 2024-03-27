using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Module8.Pages.HomePage
{
    public class SearchElements : BasePage
    {        
        private IWebElement searchInput => GetElement(By.XPath("//input[@name='ss']"));
        private IWebElement checkInOutDateSelector => ScrollToGetElement(By.XPath("//*[@data-testid='date-display-field-start']"));
        private IWebElement searchButton => GetElement(By.XPath("//button[@type='submit']"));
        private IWebElement occupancyConfig => GetElement(By.XPath("//*[@data-testid='occupancy-config']"));
        private IWebElement adultsIncreaseButton => GetElementAfterItVisible(By.XPath("//*[@class='a7a72174b8'][1]//div[@class='bfb38641b0']/button[2]"));
        private IWebElement adultsNumberValue => GetElement(By.XPath("//*[@class='a7a72174b8'][1]//*[@class='d723d73d5f']"));        
        private IWebElement childrenIncreaseButton => GetElementAfterItVisible(By.XPath("//*[@class='a7a72174b8'][2]//div[@class='bfb38641b0']/button[2]"));
        private string childrenAgeLocator = "//*[@name='age'][{0}]";
        private SelectElement childrenAgeSelector(String childNumber) => new SelectElement(GetElement(By.XPath(String.Format(childrenAgeLocator, childNumber))));
        private IWebElement childrenNumberValue => GetElement(By.XPath("//*[@class='a7a72174b8'][2]//*[@class='d723d73d5f']"));
        private IWebElement roomsIncreaseButton => GetElementAfterItVisible(By.XPath("//*[@class='a7a72174b8'][3]//div[@class='bfb38641b0']/button[2]"));
        private IWebElement roomsNumberValue => GetElement(By.XPath("//*[@class='a7a72174b8'][3]//*[@class='d723d73d5f']"));

        public SearchElements(IWebDriver driver) : base(driver)
        {     
            
        }

        public void EnterDestination(string destination) => searchInput.SendKeys(destination);

        public void ClickDatesSelector() => ClickElementAfterClickable(checkInOutDateSelector);      

        public void ClickSearchButton() => searchButton.Click();

        public void ClickToOpenOcupancyConfig() => occupancyConfig.Click();

        public void ClickToIncreaseAdults() => adultsIncreaseButton.Click();

        public string GetAdultsValue() => adultsNumberValue.Text;

        public void ClickToIncreaseChildren() => childrenIncreaseButton.Click();

        public void SelectChildrenAge(String childNumber, string age) => childrenAgeSelector(childNumber).SelectByText(age);

        public string GetChildrenValue() => childrenNumberValue.Text;

        public void ClickToIncreaseRooms() => roomsIncreaseButton.Click();

        public string GetRoomsValue() => roomsNumberValue.Text;
    }
}
