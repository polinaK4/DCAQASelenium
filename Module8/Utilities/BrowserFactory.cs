using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Module8.Utilities
{
    public class BrowserFactory
    {
        [ThreadStatic]
        private static IWebDriver driver;
        public static BrowserType browserType { get; set; } = BrowserType.Chrome; 

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = CreateDriverInstance(browserType);
            }
            return driver;
        }

        private static IWebDriver CreateDriverInstance(BrowserType browserType)
        {
            IWebDriver driver = null;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new NotSupportedException($"Browser type '{browserType}' is not supported.");
            }
            return driver;
        }

        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox
    }
}
