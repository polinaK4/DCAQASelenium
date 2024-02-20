﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Module5
{
    public class BrowserFactory
    {
        [ThreadStatic]
        private static IWebDriver driver;

        public static IWebDriver GetDriver(BrowserType browserType)
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