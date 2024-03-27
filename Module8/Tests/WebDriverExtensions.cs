using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Module8.Tests
{
    public static class WebDriverExtensions
    {
        public static IWebElement WaitForElementVisible(this IWebDriver driver, By locator, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForTextToBePresentInElement(this IWebDriver driver, IWebElement element, int timeoutInSeconds, string expectedText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => {
                ExpectedConditions.TextToBePresentInElement(element, expectedText);
                return true;
            });
        }

        public static void WaitForParticularElementName(this IWebDriver driver, IWebElement element, int timeoutInSeconds, string expectedText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => {
                element.Text.Equals(expectedText);
                return true;
            });        
        }

        public static void WaitForTextToBePresentInValueAttribute(this IWebDriver driver, IWebElement element, int timeoutInSeconds, string expectedText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => {
                element.GetAttribute("value");
                return expectedText;
            });
        }

        public static IWebElement WaitForElementBeClickable(this IWebDriver driver, IWebElement element, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitUntilElementCountIs(this IWebDriver driver, By locator, int timeoutInSeconds, int expectedCount)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));           
            wait.Until(d => d.FindElements(locator).Count == expectedCount);
        }
    }
}
