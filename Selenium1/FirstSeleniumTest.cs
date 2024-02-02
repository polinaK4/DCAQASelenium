using Module1;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace Selenium1
{
    public class FirstSeleniumTest : BaseTest
    {
        [Test]
        public void UnsuccessfulLoginWithEmptyCredentials()
        {
            Login("", "");
            ClassicAssert.AreEqual("Epic sadface: Username is required", GetLoginErrorText());
        }

        [Test]
        public void UnsuccessfulLoginWithInvalidCredentials()
        {
            Login("invalid_user", "invalid_password");
            ClassicAssert.AreEqual("Epic sadface: Username and password do not match any user in this service", GetLoginErrorText());
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            Login("standard_user", "secret_sauce");
            VerifyUrl("https://www.saucedemo.com/inventory.html");
            OpenProduct("//*[@id='item_4_title_link']/div");

            IWebElement nameSauceLabsBackpackProduct = driver.FindElement(By.XPath("//*[@class='inventory_details_name large_size']"));
            string sauceLabsBackpackText = nameSauceLabsBackpackProduct.Text;
            ClassicAssert.AreEqual("Sauce Labs Backpack", sauceLabsBackpackText);

            IWebElement detailSauceLabsBackpackProduct = driver.FindElement(By.XPath("//*[@class='inventory_details_desc large_size']"));
            string sauceLabsBackpackDetails = detailSauceLabsBackpackProduct.Text;
            ClassicAssert.AreEqual("carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.", sauceLabsBackpackDetails);

            IWebElement priceSauceLabsBackpackProduct = driver.FindElement(By.XPath("//*[@class='inventory_details_price']"));
            string sauceLabsBackpackPriceText = priceSauceLabsBackpackProduct.Text;
            StringAssert.Contains("$", sauceLabsBackpackPriceText);
            StringAssert.Contains("29.99", sauceLabsBackpackPriceText);

            IWebElement imageSauceLabsBackpackProduct = driver.FindElement(By.XPath("//*[@class='inventory_details_img_container']/img"));
            string scrImageSauceLabsBackpack = imageSauceLabsBackpackProduct.GetAttribute("src");
            ClassicAssert.AreEqual("https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.0a0b85a3.jpg", scrImageSauceLabsBackpack);
        }

        private string GetLoginErrorText()
        {
            IWebElement errorEmptyLogin = driver.FindElement(By.XPath("//*[@class='error-message-container error']/h3"));
            return errorEmptyLogin.Text;
        }
    }
}
