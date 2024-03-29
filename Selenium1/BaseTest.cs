﻿using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace Module1
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            //driver = BrowserFactory.GetDriver(BrowserType.Chrome);
            driver = BrowserFactory.GetDriver(BrowserType.Firefox);
        }

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            BrowserFactory.CloseDriver();
        }

        public void Login(string username, string password)
        {
            IWebElement fieldUsername = driver.FindElement(By.XPath("//*[@id='user-name']"));
            fieldUsername.SendKeys(username);
            IWebElement fieldPassword = driver.FindElement(By.XPath("//*[@id='password']"));
            fieldPassword.SendKeys(password);
            IWebElement buttonLogin = driver.FindElement(By.XPath("//*[@id='login-button']"));
            buttonLogin.Click();
        }

        public void VerifyUrl(string url)
        {
            string pageURL = driver.Url;
            ClassicAssert.AreEqual(url, pageURL);
        }

        public void OpenProduct(string productXpath)
        {
            IWebElement linkProduct = driver.FindElement(By.XPath(productXpath));
            linkProduct.Click();
        }
    }
}
