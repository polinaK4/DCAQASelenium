using FinalProject.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace FinalProject.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = BrowserFactory.GetDriver();
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

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }
    }
}