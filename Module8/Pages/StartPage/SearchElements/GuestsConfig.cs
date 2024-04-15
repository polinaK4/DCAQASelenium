using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Module8.Pages.StartPage.SearchElements
{
    public class GuestsConfig : BasePage
    {    
        private IWebElement adultsIncreaseButton => GetElementAfterItVisible(By.XPath("//*[@class='a7a72174b8'][1]//div[@class='bfb38641b0']/button[2]"));
        private IWebElement adultsNumberValue => GetElement(By.XPath("//*[@class='a7a72174b8'][1]//*[@class='d723d73d5f']"));
        private IWebElement childrenIncreaseButton => GetElementAfterItVisible(By.XPath("//*[@class='a7a72174b8'][2]//div[@class='bfb38641b0']/button[2]"));
        private string childrenAgeLocator = "//*[@name='age'][{0}]";
        private SelectElement childrenAgeSelector(string childNumber) => new SelectElement(GetElement(By.XPath(string.Format(childrenAgeLocator, childNumber))));
        private IWebElement childrenNumberValue => GetElement(By.XPath("//*[@class='a7a72174b8'][2]//*[@class='d723d73d5f']"));
        private IWebElement roomsIncreaseButton => GetElementAfterItVisible(By.XPath("//*[@class='a7a72174b8'][3]//div[@class='bfb38641b0']/button[2]"));
        private IWebElement roomsNumberValue => GetElement(By.XPath("//*[@class='a7a72174b8'][3]//*[@class='d723d73d5f']"));

        public GuestsConfig(IWebDriver driver) : base(driver)
        {

        }

        public void ClickToIncreaseAdults() => adultsIncreaseButton.Click();

        public string GetAdultsValue() => adultsNumberValue.Text;

        public void ClickToIncreaseChildren() => childrenIncreaseButton.Click();

        public void SelectChildrenAge(string childNumber, string age) => childrenAgeSelector(childNumber).SelectByText(age);

        public string GetChildrenValue() => childrenNumberValue.Text;

        public void ClickToIncreaseRooms() => roomsIncreaseButton.Click();

        public string GetRoomsValue() => roomsNumberValue.Text;
    }
}
