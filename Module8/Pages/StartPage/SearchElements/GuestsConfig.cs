using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.StartPage.SearchElements
{
    public class GuestsConfig : BasePage
    {    
        private ButtonElement adultsIncreaseButton => new ButtonElement(By.XPath("//*[@class='a7a72174b8'][1]//div[@class='bfb38641b0']/button[2]"));
        private PoliWebElement adultsNumberValue => new PoliWebElement(By.XPath("//*[@class='a7a72174b8'][1]//*[@class='d723d73d5f']"));
        private ButtonElement childrenIncreaseButton => new ButtonElement(By.XPath("//*[@class='a7a72174b8'][2]//div[@class='bfb38641b0']/button[2]"));
        private string childrenAgeLocator = "//*[@name='age'][{0}]";
        private DropDownElement childrenAgeSelector(string childNumber) => new DropDownElement(By.XPath(string.Format(childrenAgeLocator, childNumber)));
        private PoliWebElement childrenNumberValue => new PoliWebElement(By.XPath("//*[@class='a7a72174b8'][2]//*[@class='d723d73d5f']"));
        private ButtonElement roomsIncreaseButton => new ButtonElement(By.XPath("//*[@class='a7a72174b8'][3]//div[@class='bfb38641b0']/button[2]"));
        private PoliWebElement roomsNumberValue => new PoliWebElement(By.XPath("//*[@class='a7a72174b8'][3]//*[@class='d723d73d5f']"));

        public GuestsConfig(IWebDriver driver) : base(driver)
        {

        }

        public void ClickToIncreaseAdults() => adultsIncreaseButton.ClickWhenReady();

        public string GetAdultsValue() => adultsNumberValue.Text;

        public void ClickToIncreaseChildren() => childrenIncreaseButton.ClickWhenReady();

        public void SelectChildrenAge(string childNumber, string age) => childrenAgeSelector(childNumber).SelectByText(age);

        public string GetChildrenValue() => childrenNumberValue.Text;

        public void ClickToIncreaseRooms() => roomsIncreaseButton.ClickWhenReady();

        public string GetRoomsValue() => roomsNumberValue.Text;
    }
}
