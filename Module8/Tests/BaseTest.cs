using Module8.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Module8.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = BrowserFactory.GetDriver(BrowserType.Chrome);
            //driver = BrowserFactory.GetDriver(BrowserType.Firefox);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            BrowserFactory.CloseDriver();
        }

        public void VerifyUrl(string url)
        {
            string pageURL = driver.Url;
            ClassicAssert.AreEqual(url, pageURL);
        }

        public void VerifyUrlStartsWith(string url)
        {
            string pageURL = driver.Url;
            StringAssert.StartsWith(url, pageURL);
        }

        public void SwitchToAnotherTab()
        {
            string currentWindowHandle = driver.CurrentWindowHandle;
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != currentWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                }
            }
        }

        public void ClickEnterKeyOnFocusedElement()
        {
            Actions actions = new Actions(driver);
            IWebElement activeElement = driver.SwitchTo().ActiveElement();
            activeElement.SendKeys(Keys.Enter);
        }

        public void EnterTextToFocusedElement(string inputText)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(inputText)
                .Perform();
        }

        public void FocusNextElementUsingTabKey()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Tab)
                .Perform();
        }

        public void ClickArrowUpButton()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.ArrowUp)
                .Perform();
        }

        public double CheckScrollPosition()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            double value = Convert.ToDouble(executor.ExecuteScript("return window.pageYOffset;"));            
            double valueRounded = Math.Round(value, 2);
            return valueRounded;
        }

        public void ClickShiftAndTabButtons()
        {
            Actions actions = new Actions(driver);
            actions.KeyDown(Keys.Shift)
                .SendKeys(Keys.Tab)
                .KeyUp(Keys.Shift)
                .Perform();
        }
    }
}