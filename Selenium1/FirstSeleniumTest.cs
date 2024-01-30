using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Selenium1
{
    public class FirstSeleniumTest
    {
        private IWebDriver driver;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void UnsuccessfulLoginWithEmptyCredentials()
        {
            IWebElement buttonLogin = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
            buttonLogin.Click();
            IWebElement errorEmptyLogin = driver.FindElement(By.XPath("//*[@class=\"error-message-container error\"]/h3"));
            string errorEmptyLoginText = errorEmptyLogin.Text;
            ClassicAssert.AreEqual("Epic sadface: Username is required", errorEmptyLoginText);
        }

        [Test]
        public void UnsuccessfulLoginWithInvalidCredentials()
        {
            IWebElement fieldUsername = driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
            fieldUsername.SendKeys("invalid_user");
            IWebElement fieldPassword = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            fieldPassword.SendKeys("invalid_password");
            IWebElement buttonLogin = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
            buttonLogin.Click();
            IWebElement errorEmptyLogin = driver.FindElement(By.XPath("//*[@class=\"error-message-container error\"]/h3"));
            string errorEmptyLoginText = errorEmptyLogin.Text;
            ClassicAssert.AreEqual("Epic sadface: Username and password do not match any user in this service", errorEmptyLoginText);
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            IWebElement fieldUsername = driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
            fieldUsername.SendKeys("standard_user");
            IWebElement fieldPassword = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            fieldPassword.SendKeys("secret_sauce");
            IWebElement buttonLogin = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
            buttonLogin.Click();

            string pageURL = driver.Url;
            ClassicAssert.AreEqual("https://www.saucedemo.com/inventory.html", pageURL);

            IWebElement linkProduct = driver.FindElement(By.XPath("//*[@id=\"item_4_title_link\"]/div"));
            linkProduct.Click();

            IWebElement nameSauceLabsBackpackProduct = driver.FindElement(By.XPath("//*[@class=\"inventory_details_name large_size\"]"));
            string sauceLabsBackpackText = nameSauceLabsBackpackProduct.Text;
            ClassicAssert.AreEqual("Sauce Labs Backpack", sauceLabsBackpackText);

            IWebElement detailSauceLabsBackpackProduct = driver.FindElement(By.XPath("//*[@class=\"inventory_details_desc large_size\"]"));
            string sauceLabsBackpackDetails = detailSauceLabsBackpackProduct.Text;
            ClassicAssert.AreEqual("carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.", sauceLabsBackpackDetails);

            IWebElement priceSauceLabsBackpackProduct = driver.FindElement(By.XPath("//*[@class=\"inventory_details_price\"]"));
            string sauceLabsBackpackPriceText = priceSauceLabsBackpackProduct.Text;
            StringAssert.Contains("$", sauceLabsBackpackPriceText);
            StringAssert.Contains("29.99", sauceLabsBackpackPriceText);

            IWebElement imageSauceLabsBackpackProduct = driver.FindElement(By.XPath("//*[@class=\"inventory_details_img_container\"]/img"));
            string scrImageSauceLabsBackpack = imageSauceLabsBackpackProduct.GetAttribute("src");
            ClassicAssert.AreEqual("https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.0a0b85a3.jpg", scrImageSauceLabsBackpack);
        }
    }
}
