using Module8.Helpers;
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

        public IWebElement GetElement(By element)
        {
            return driver.FindElement(element);
        }

        public IWebElement GetElementAfterItVisible(By element)
        {
            return driver.WaitForElementVisible(element, 20);
        }

        public List<IWebElement> GetListOfElements(By element)
        {
            return driver.FindElements(element).ToList();
        }

        public void WaitForExpectedText(IWebElement element, string expectedText)
        {
            driver.WaitForTextToBePresentInElement(element, 10, expectedText);
        }

        public void WaitForElementName(IWebElement element, string expectedText)
        {
            driver.WaitForParticularElementName(element, 10, expectedText);
        }

        public void WaitForExpectedValueAtribute(IWebElement element, string expectedText)
        {
            driver.WaitForTextToBePresentInValueAttribute(element, 10, expectedText);
        }

        public void WaitForExpectedElementsCount(By element, int expectedCount)
        {
            driver.WaitUntilElementCountIs(element, 10, expectedCount);
        }

        public void ClickElementAfterClickable(IWebElement element)
        {
            driver.WaitForElementBeClickable(element, 10).Click();
        }

        public void WaitForElementNotVisible(By locator)
        {
            driver.WaitForElementNotVisible(locator, 10);
        }

        public IWebElement ScrollToGetElement(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }

        public void FindAndFocusSpecificElementUsingArrowDownKey(int targetElementNumber)
        {
            driver.FindAndFocusSpecificElementUsingArrowDownKey(targetElementNumber);
        }

        public void FindElementByComparingAndFocusUsingArrowDownKey(List<IWebElement> elements, string expectedValue)
        {
            driver.FindElementByComparingAndFocusUsingArrowDownKey(elements, expectedValue);
        }

        public void EnterTextAndWaitItDisplayed(string inputText, IWebElement element)
        {
            driver.EnterTextToFocusedElement(inputText);
            driver.WaitForTextToBePresentInValueAttribute(element, 5, inputText);
        }

        public void ClickElementUsingJavaScript(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
