using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace Module1
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Module3Tests : BaseTest
    {
        [Test]
        public void VerifyProductSorting()
        {
            Login("standard_user", "secret_sauce");
            VerifyUrl("https://www.saucedemo.com/inventory.html");
            IWebElement sortDropdown = driver.FindElement(By.XPath("//*[@class='product_sort_container']"));
            sortDropdown.Click();
            IWebElement sortPriceLowHigh = driver.FindElement(By.XPath("//*[@class='product_sort_container']/option[3]"));
            sortPriceLowHigh.Click();
            List<IWebElement> productsList = driver.FindElements(By.XPath("//*[@class='inventory_item_price']")).ToList();
            List<string> prices = new List<string>();
            productsList.ForEach(product => prices.Add(product.Text.Substring(1)));
            List<double> pricesInt = prices.Select(s => Double.Parse(s, CultureInfo.InvariantCulture)).ToList();
            ClassicAssert.That(pricesInt, Is.Ordered.Ascending);
        }

        [Test]
        public void AddProductToCart()
        {
            Login("standard_user", "secret_sauce");
            VerifyUrl("https://www.saucedemo.com/inventory.html");
            OpenProduct("//*[@id='item_4_title_link']/div");
            ProductDetailsAddToCart("//*[@id='add-to-cart-sauce-labs-backpack']");
            VerifyCartCounter("1");
        }

        [Test]
        public void RemoveProductFromCart()
        {
            Login("standard_user", "secret_sauce");
            VerifyUrl("https://www.saucedemo.com/inventory.html");
            OpenProduct("//*[@id='item_0_title_link']/div");
            ProductDetailsAddToCart("//*[@id='add-to-cart-sauce-labs-bike-light']");
            IWebElement shoppingCartLink = driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a"));
            shoppingCartLink.Click();
            IWebElement shoppingCartRemoveItem = driver.FindElement(By.XPath("//*[@id='remove-sauce-labs-bike-light']"));
            shoppingCartRemoveItem.Click();
            List<IWebElement> shoppingCartList = driver.FindElements(By.XPath(".//*[@id='item_0_title_link']")).ToList();
            ClassicAssert.IsEmpty(shoppingCartList);
        }


        [Test]
        public void LogoutFunctionality()
        {
            Login("standard_user", "secret_sauce");
            VerifyUrl("https://www.saucedemo.com/inventory.html");
            IWebElement sideMenuIcon = driver.FindElement(By.XPath("//*[@id='react-burger-menu-btn']"));
            sideMenuIcon.Click();
            IWebElement sideMenuLogout = driver.FindElement(By.XPath("//*[@id='logout_sidebar_link']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='logout_sidebar_link']")));
            sideMenuLogout.Click();
            VerifyUrl("https://www.saucedemo.com/");
        }

        private void ProductDetailsAddToCart(string path)
        {
            IWebElement addToCartButtonProduct = driver.FindElement(By.XPath(path));
            addToCartButtonProduct.Click();
        }

        private void VerifyCartCounter(string counter)
        {
            IWebElement shoppingCartCounter = driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a/span"));
            string shoppingCartCounterValue = shoppingCartCounter.Text;
            ClassicAssert.AreEqual(counter, shoppingCartCounterValue);
        }

    }
}
