using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.AttractionsPage
{
    public class AttractionStartPage : BasePage
    {
        private TextboxElement searchInput => new TextboxElement(By.XPath("//input[@name='query']"));
        private PoliWebElement datesSelector => new PoliWebElement(By.XPath("//*[@class='css-10zpq3d']"));
        private ButtonElement searchButton => new ButtonElement(By.XPath("//button[@data-testid='search-button']"));
        private PoliWebElement searchBarFirstResult => new PoliWebElement(By.XPath("//*[@class='css-od6awi']/ul[1]/li[2]/a"));   

        public AttractionStartPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterDestination(string destination) => searchInput.EnterText(destination);

        public void ClickDateSelector() => datesSelector.Click();

        public void ClickSearchButton() => searchButton.ClickWhenReady();

        public void ClickSearchBarFirstResult() => searchBarFirstResult.Click();
    }
}
