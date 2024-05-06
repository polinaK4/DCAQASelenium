using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForExpectedText(IWebElement element, string expectedText)
        {
            driver.WaitForTextToBePresentInElement(element, 10, expectedText);
        }

        public void WaitElementBeSelected(PoliWebElement element)
        {
            driver.WaitForElementCanBeSelected(element, 10);
        }        
    }
}
