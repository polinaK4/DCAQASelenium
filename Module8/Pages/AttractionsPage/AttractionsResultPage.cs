using OpenQA.Selenium;

namespace Module8.Pages.AttractionsPage
{
    public class AttractionsResultPage : BasePage
    {
        private IWebElement attractionsFirstResult => GetElementAfterItVisible(By.XPath("//*[@data-testid='sr-list']/div/div[1]//a"));
        private IWebElement destinationInput => GetElementAfterItVisible(By.XPath("//input[@name='query']"));
        private IWebElement datesInput => GetElementAfterItVisible(By.XPath("//*[@class='css-tbiur0']"));

        public AttractionsResultPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickAttractionsFirstResult() => attractionsFirstResult.Click();

        public void CheckDatesInputValue(string expectedText) => WaitForExpectedText(datesInput, expectedText);

        public void CheckDestinationInputValue(string expectedText) => WaitForExpectedValueAtribute(destinationInput, expectedText);
    }
}
