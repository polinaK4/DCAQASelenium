using OpenQA.Selenium;

namespace Module8.Pages.FlightsPage
{
    public class FlightsPage : BasePage
    {
        private IWebElement multiCityCheckbox => GetElementAfterItVisible(By.XPath("//*[@data-ui-name='search_type_multistop']/label/span[2]"));       

        public FlightsPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickMultiCityCheckbox() => multiCityCheckbox.Click();        
    }
}
