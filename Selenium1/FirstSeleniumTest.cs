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
        [Test]
        public void LoginWithValidCredentials()
        {
            var driver = new ChromeDriver("C:/chromedriver/chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            IWebElement fieldUsername = driver.FindElement(By.Id("user-name"));
            fieldUsername.SendKeys("standard_user");
            IWebElement fieldPassword = driver.FindElement(By.Id("password"));
            fieldPassword.SendKeys("secret_sauce");
            IWebElement buttonLogin = driver.FindElement(By.Id("login-button"));
            buttonLogin.Click();

            string pageURL = driver.Url;
            ClassicAssert.AreEqual("https://www.saucedemo.com/inventory.html", pageURL);

            IWebElement linkProduct = driver.FindElement(By.Id("item_4_title_link"));
            linkProduct.Click();

            IWebElement nameSauceLabsBackpackProduct = driver.FindElement(By.CssSelector("div.inventory_details_name.large_size"));
            string sauceLabsBackpackText = nameSauceLabsBackpackProduct.Text;
            ClassicAssert.AreEqual("Sauce Labs Backpack", sauceLabsBackpackText);

            IWebElement detailSauceLabsBackpackProduct = driver.FindElement(By.CssSelector("div.inventory_details_desc.large_size"));
            string sauceLabsBackpackDetails = detailSauceLabsBackpackProduct.Text;
            ClassicAssert.AreEqual("carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.", sauceLabsBackpackDetails);

            IWebElement priceSauceLabsBackpackProduct = driver.FindElement(By.ClassName("inventory_details_price"));
            string sauceLabsBackpackPriceText = priceSauceLabsBackpackProduct.Text;
            StringAssert.Contains("$", sauceLabsBackpackPriceText);
            StringAssert.Contains("29.99", sauceLabsBackpackPriceText);

            IWebElement imageSauceLabsBackpackProduct = driver.FindElement(By.CssSelector("div.inventory_details_img_container>img"));
            string scrImageSauceLabsBackpack = imageSauceLabsBackpackProduct.GetAttribute("src");
            ClassicAssert.AreEqual("https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.0a0b85a3.jpg", scrImageSauceLabsBackpack);
              
            driver.Quit();
        }
    }
}
