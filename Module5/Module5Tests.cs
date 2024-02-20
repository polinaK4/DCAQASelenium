using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing;

namespace Module5
{
    [TestFixture]
    public class Module5Tests : BaseTest
    {
        [Test]
        public void OpenNewWindowandHandleTabs()
        {
            string originalWindow = driver.CurrentWindowHandle;
            ClassicAssert.AreEqual(driver.WindowHandles.Count, 1);
            ScrollAndOpen("//a[contains(@href,'/windows')]");
            IWebElement clickHereLink = driver.FindElement(By.XPath("//*[@id='content']/div/a"));
            clickHereLink.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(wd => wd.WindowHandles.Count == 2);
            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(wd => wd.Title == "New Window");
            IWebElement newWindowContent = driver.FindElement(By.XPath("//*[@class='example']"));
            string newWindowContentText = newWindowContent.Text;
            ClassicAssert.AreEqual("New Window", newWindowContentText);
            driver.Close();
            driver.SwitchTo().Window(originalWindow);
        }

        [Test]
        public void NavigateBackandForward()
        {
            ScrollAndOpen("//a[contains(@href,'/login')]");
            Login("tomsmith", "SuperSecretPassword!");
            VerifyUrl("https://the-internet.herokuapp.com/secure");
            driver.Navigate().Back();
            IWebElement fieldUsername = driver.FindElement(By.XPath("//*[@id='username']"));
            IWebElement fieldPassword = driver.FindElement(By.XPath("//*[@id='password']"));
            driver.Navigate().Forward();
            VerifyUrl("https://the-internet.herokuapp.com/secure");
        }

        [Test]
        public void NavigateToURLAndRefresh()
        {
            ScrollAndOpen("//a[contains(@href,'/dynamic_loading')]");
            IWebElement example1 = driver.FindElement(By.XPath("//*[@id='content']/div/a[1]"));
            example1.Click();
            IWebElement example1Start = driver.FindElement(By.XPath("//*[@id='start']/button"));
            example1Start.Click();
            IWebElement finishedResult = driver.FindElement(By.XPath("//*[@id='finish']"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(wdw => finishedResult.Displayed);
            string pageURL = driver.Url;
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            VerifyUrl("https://the-internet.herokuapp.com/");
            driver.Navigate().Refresh();
        }

        [Test]
        public void MaximizeWindowAndChangeWindowSize()
        {
            ScrollAndOpen("//a[contains(@href,'/large')]");
            IWebElement poweredByElementalSelenium = driver.FindElement(By.XPath("//*[@id='page-footer']/div/div/a"));
            new Actions(driver).ScrollToElement(poweredByElementalSelenium).Perform();
            driver.Manage().Window.Maximize();
            IWebElement lastValueTable = driver.FindElement(By.XPath("//*[@id='large-table']/tbody/tr[50]/td[50]"));
            new Actions(driver).ScrollToElement(lastValueTable).Perform();
            string lastValue = lastValueTable.Text;
            ClassicAssert.AreEqual("50.50", lastValue);
            driver.Manage().Window.Size = new Size(1024, 768);
            int width = driver.Manage().Window.Size.Width;
            int height = driver.Manage().Window.Size.Height;
            ClassicAssert.AreEqual(1026, width);
            ClassicAssert.AreEqual(770, height);
        }

        [Test]
        public void WorkingWithChromeOptionsHeadlessMode()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            ScrollAndOpen("//a[contains(@href,'/checkboxes')]");
            IWebElement checkbox1 = driver.FindElement(By.XPath("//*[@id='checkboxes']/input[1]"));
            checkbox1.Click();
        }

        private void Login(string username, string password)
        {
            IWebElement fieldUsername = driver.FindElement(By.XPath("//*[@id='username']"));
            fieldUsername.SendKeys(username);
            IWebElement fieldPassword = driver.FindElement(By.XPath("//*[@id='password']"));
            fieldPassword.SendKeys(password);
            IWebElement buttonLogin = driver.FindElement(By.XPath("//*[@id='login']/button"));
            buttonLogin.Click();
        }
    }
}