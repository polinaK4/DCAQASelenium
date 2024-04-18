using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.AttractionsPage
{
    public class AttractionDetailPage : BasePage
    {
        private PoliWebElement selectedDateDayOfTheMonth => new PoliWebElement(By.XPath("//button[@aria-pressed='true']/div[2]"));
        private PoliWebElement selectedDateMounth => new PoliWebElement(By.XPath("//button[@aria-pressed='true']/div[3]"));

        public AttractionDetailPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetSelectedByDefaultDateDay() => selectedDateDayOfTheMonth.Text;

        public string GetSelectedByDefaultDateMonth() => selectedDateMounth.Text;
    }
}
