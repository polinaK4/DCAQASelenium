using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium.Support.Extensions;
using System.Xml.Linq;

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

        public static List<PoliWebElement> WaitTillElementsCountAndGetList(this IWebDriver driver, By by, int timeoutInSeconds, int count)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => drv.FindElements(by).Count >= count);
            return driver.FindElements(by).Select(el => el.ToPoliWebElement()).ToList();;
        }

        //public static PoliWebElement ScrollAndGetElement(this IWebDriver driver, By by)
        //{
        //    IWebElement element = driver.FindElement(by);
        //    driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
        //    return element.ToPoliWebElement();
        //}

        //public static IWebElement WaitForElementVisible(this IWebDriver driver, By by, int timeoutInSeconds)
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    return wait.Until(ExpectedConditions.ElementIsVisible(by));
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

        //public static void WaitForTextNotToBePresentInElement(this IWebDriver driver, IWebElement element, int timeoutInSeconds, string expectedText)
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    wait.Until(el => element.Text != expectedText == true);
        //}
    }
}
