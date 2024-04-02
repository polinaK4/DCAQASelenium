using OpenQA.Selenium;

namespace Module8.Pages.AttractionsPage
{
    public class AttractionStartPage : BasePage
    {
        private IWebElement searchInput => GetElement(By.XPath("//input[@name='query']"));
        private IWebElement datesSelector => GetElement(By.XPath("//*[@class='css-10zpq3d']"));
        private IWebElement searchButton => GetElement(By.XPath("//button[@data-testid='search-button']"));
        private IWebElement searchBarFirstResult => GetElementAfterItVisible(By.XPath("//*[@class='css-od6awi']/ul[1]/li[2]/a"));   

        //private IWebElement searchBarPopup => GetElementAfterItVisible(By.XPath("//*[@class='css-od6awi']"));        

        //private List<IWebElement> searchBarResults => GetListOfElements(By.XPath("//a[@data-testid='search-bar-result']"));

        public AttractionStartPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterDestination(string destination) => searchInput.SendKeys(destination);

        public void ClickDateSelector() => datesSelector.Click();

        public void ClickSearchButton() => searchButton.Click();

        public void ClickSearchBarFirstResult() => searchBarFirstResult.Click();
    }
}
