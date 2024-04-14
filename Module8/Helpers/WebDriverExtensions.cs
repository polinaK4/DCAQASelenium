using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace Module8.Helpers
{
    public static class WebDriverExtensions
    {
        public static IWebElement WaitForElementVisible(this IWebDriver driver, By locator, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementNotVisible(this IWebDriver driver, By locator, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
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

        public static void WaitForParticularElementName(this IWebDriver driver, IWebElement element, int timeoutInSeconds, string expectedText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d =>
            {
                element.Text.Equals(expectedText);
                return true;
            });
        }

        public static void WaitForTextToBePresentInValueAttribute(this IWebDriver driver, IWebElement element, int timeoutInSeconds, string expectedText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d =>
            {
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

        public static void PressTabKey(this IWebDriver driver, int clicks)
        {
            Actions actions = new Actions(driver);
            for (int i = 0; i < clicks; i++)
            {
                actions.SendKeys(Keys.Tab)
                        .Perform();
            }
        }

        public static void ClickEnterKeyOnFocusedElement(this IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Enter)
                        .Perform();
        }

        public static void FindAndFocusSpecificElementUsingArrowDownKey(this IWebDriver driver, int targetElementNumber)
        {
            Actions actions = new Actions(driver);
            int activeElementCount = 0;
            while (activeElementCount != targetElementNumber)
            {
                actions.SendKeys(Keys.ArrowDown)
                    .Perform();
                activeElementCount++;
            }
        }

        public static void EnterTextToFocusedElement(this IWebDriver driver, string inputText)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(inputText)
                .Perform();
        }

        public static void FindElementByComparingAndFocusUsingArrowDownKey(this IWebDriver driver, List<IWebElement> elements, string expectedValue)
        {
            Actions actions = new Actions(driver);
            foreach (IWebElement element in elements)
            {
                actions.SendKeys(Keys.ArrowDown)
                        .Perform();
                if (element.Text == expectedValue)
                {
                    break;
                }
            }
        }

        public static void ClickArrowUpKey(this IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.ArrowUp)
                .Perform();
        }

        public static void ClickShiftAndTabButtons(this IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.KeyDown(Keys.Shift)
                .SendKeys(Keys.Tab)
                .KeyUp(Keys.Shift)
                .Perform();
        }
    }
}
