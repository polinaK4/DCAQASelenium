using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.CommonElements
{
    public class FromToDateSelector : BasePage
    {
        private string gridSellLocator = "//*[@class='d4babb55ef']//div[2]/table//tr[1]/td[{0}]"; //tr - weeks (1-5) | td - days (1-7)
        private PoliWebElement Grigsells(String day) => new PoliWebElement(By.XPath(String.Format(gridSellLocator, day)));
        public FromToDateSelector(IWebDriver driver) : base(driver)
        {

        }

        public void SelectDayOfTheWeek(string day) => Grigsells(day).Click();
    }
}
