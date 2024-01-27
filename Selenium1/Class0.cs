using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework.Legacy;

namespace Selenium1
{
    public class SeleniumTests
    {
        [Test]
        public void TestWebsiteTitle()
        {
            // Set the path of the ChromeDriver executable
            var driver = new ChromeDriver("C:/chromedriver/chromedriver.exe");

            // Open the website
            driver.Navigate().GoToUrl("https://www.example.com");

            // Get the actual page title
            string pageTitle = driver.Title;

            // Assert the page title with the expected value
            ClassicAssert.AreEqual("Example Domain", pageTitle);
            //AreEqual

            // Find an element by its ID
            IWebElement elementById = driver.FindElement(By.Id("elementId"));
            // Click on the element
            elementById.Click();

            // Find an element by its name
            IWebElement elementByName = driver.FindElement(By.Name("elementName"));
            // Send keys to the element
            elementByName.SendKeys("Hello, Selenium!");

            // Find an element by its XPath
            IWebElement elementByXPath = driver.FindElement(By.XPath("//div[@class='example']"));
            // Get the visible text of the element
            string elementText = elementByXPath.Text;
            ClassicAssert.AreEqual("This is an example element.", elementText);
            //Assert.AreEqual("This is an example element.", elementText);

            // Close the browser
            driver.Quit();
        }
    }
}