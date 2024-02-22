using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Module5
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

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            BrowserFactory.CloseDriver();
        }

        public void ScrollAndOpenLink(string linkXpath)
        {
            IWebElement link = driver.FindElement(By.XPath($"//a[contains(@href,'{linkXpath}')]"));
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void VerifyUrl(string url)
        {
            string pageURL = driver.Url;
            ClassicAssert.AreEqual(url, pageURL);
        }
    }
}
