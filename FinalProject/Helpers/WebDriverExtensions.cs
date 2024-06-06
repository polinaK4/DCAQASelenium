using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using FinalProject.Pages.WebElements;

namespace FinalProject.Helpers
{
    public static class WebDriverExtensions
    {
        public static void WaitForElementExistance(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(dr => dr.FindElements(by).Count != 0 == true);
        }

        public static IWebElement GetElement(this IWebDriver driver, By by)
        {
            WaitForElementExistance(driver, by, 10);
            IWebElement element = driver.FindElement(by);
            return element;
        }

        public static PoliWebElement ToPoliWebElement(this IWebElement element)
        {
            return new PoliWebElement(element);
        }

        public static List<PoliWebElement> GetPoliWebElementList(this IWebDriver driver, By by)
        {
            var result = driver.FindElements(by).Select(el => el.ToPoliWebElement()).ToList();
            return result;
        }

        public static DropdownElement ToDropdownElement(this IWebElement element)
        {
            return new DropdownElement(element);
        }

        public static List<DropdownElement> GetDropdownElementList(this IWebDriver driver, By by, int expectedMinCount)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElements(by).Count >= expectedMinCount);
            return driver.FindElements(by).Select(el => el.ToDropdownElement()).ToList();            
        }

        public static List<PoliWebElement> GetPoliWebElementList(this IWebDriver driver, By by, int expectedMinCount)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElements(by).Count >= expectedMinCount);
            return driver.FindElements(by).Select(el => el.ToPoliWebElement()).ToList();;
        }

        //public static PoliWebElement ScrollAndGetElement(this IWebDriver driver, By by)
        //{
        //    IWebElement element = driver.FindElement(by);
        //    driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
        //    return element.ToPoliWebElement();
        //}

        public static void WaitForElementCanBeSelected(this IWebDriver driver, PoliWebElement element, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d =>
            {
                ExpectedConditions.ElementToBeSelected(element);
                return true;
            });
        }

        public static void WaitForTextToBePresentInElement(this IWebDriver driver, IWebElement element, int timeoutInSeconds, string expectedText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d =>
            {
                ExpectedConditions.TextToBePresentInElement(element, expectedText);
                return true;
            });
        }
    }
}
