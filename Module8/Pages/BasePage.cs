using Module8.Helpers;
using Module8.Wrappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Module8.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //public IWebElement GetElementAfterItVisible(By element)
        //{
        //    return driver.WaitForElementVisible(element, 20);
        //}

        public List<IWebElement> GetListOfElements(By element)
        { 
            return driver.FindElements(element).ToList();
        }

        public void WaitForExpectedText(PoliWebElement element, string expectedText)
        {
            driver.WaitForTextToBePresentInElement(element, 10, expectedText);
        }

        public void WaitForElementName(PoliWebElement element, string expectedText)
        {
            driver.WaitForParticularElementName(element, 10, expectedText);
        }

        public void WaitForExpectedValueAtribute(PoliWebElement element, string expectedText)
        {
            driver.WaitForTextToBePresentInValueAttribute(element, 10, expectedText);
        }

        public void WaitForExpectedElementsCount(By element, int expectedCount)
        {
            driver.WaitUntilElementCountIs(element, 10, expectedCount);
        }

        public void WaitForElementNotVisible(By locator)
        {
            driver.WaitForElementNotVisible(locator, 10);
        }



        public void FindAndFocusSpecificElementUsingArrowDownKey(int targetElementNumber)
        {
            driver.FindAndFocusSpecificElementUsingArrowDownKey(targetElementNumber);
        }

        public void FindElementByComparingAndFocusUsingArrowDownKey(List<PoliWebElement> elements, string expectedValue)
        {
            driver.FindElementByComparingAndFocusUsingArrowDownKey(elements, expectedValue);
        }

        public void ClickElementUsingJavaScript(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
