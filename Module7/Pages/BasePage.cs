using OpenQA.Selenium;

namespace Module7.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetElement(By element)
        {
            return driver.FindElement(element);
        }

        public List<IWebElement> GetListOfElements(By element)
        {
            return driver.FindElements(element).ToList();
        }
    }
}
