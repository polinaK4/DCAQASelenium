using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.AttractionsPage
{
    public class AttractionsResultPage : BasePage
    {
        private PoliWebElement attractionsFirstResult => new PoliWebElement(By.XPath("//*[@data-testid='sr-list']/div/div[1]//a"));
        private TextboxElement destinationInput => new TextboxElement(By.XPath("//input[@name='query']"));
        private TextboxElement datesInput => new TextboxElement(By.XPath("//*[@class='css-tbiur0']"));

        public AttractionsResultPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickAttractionsFirstResult() => attractionsFirstResult.Click();

        public void CheckDatesInputValue(string expectedText) => WaitForExpectedText(datesInput, expectedText);

        public void CheckDestinationInputValue(string expectedText) => WaitForExpectedValueAtribute(destinationInput, expectedText);
    }
}
