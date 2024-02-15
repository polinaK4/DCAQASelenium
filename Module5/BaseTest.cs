using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Module5
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
