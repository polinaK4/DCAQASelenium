using OpenQA.Selenium;
using System.Xml.Linq;

namespace Module8.Pages.AttractionsPage
{
    public class AttractionDetailPage : BasePage
    {
        //private IWebElement selectedDateTile => ScrollToGetElement(By.XPath("//button[@aria-pressed='true']"));
        private IWebElement selectedDateDayOfTheMonth => GetElementAfterItVisible(By.XPath("//button[@aria-pressed='true']/div[2]"));
        private IWebElement selectedDateMounth => GetElementAfterItVisible(By.XPath("//button[@aria-pressed='true']/div[3]"));

        public AttractionDetailPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetSelectedByDefaultDateDay() => selectedDateDayOfTheMonth.Text;

        public string GetSelectedByDefaultDateMonth() => selectedDateMounth.Text;
    }
}
