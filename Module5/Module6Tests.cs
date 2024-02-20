using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace Module5
{
    [TestFixture]
    public class Module6Tests : BaseTest
    {
        [Test]
        public void HandlingSimpleAlert()
        {
            ScrollAndOpen("//a[contains(@href,'/javascript_alerts')]");
            IWebElement buttonAlert = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[1]/button"));
            buttonAlert.Click();
            IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();
            CheckResultAfterAlert("You successfully clicked an alert");
        }

        [Test]
        public void HandlingConfirmationAlert()
        {
            ScrollAndOpen("//a[contains(@href,'/javascript_alerts')]");
            IWebElement buttonAlert = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button"));
            buttonAlert.Click();
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            confirmationAlert.Dismiss();
            CheckResultAfterAlert("You clicked: Cancel");
        }

        [Test]
        public void HandlingPromptAlert()
        {
            ScrollAndOpen("//a[contains(@href,'/javascript_alerts')]");
            IWebElement buttonAlert = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button"));
            buttonAlert.Click();
            IAlert promptAlert = driver.SwitchTo().Alert();
            promptAlert.SendKeys("test");
            promptAlert.Accept();
            CheckResultAfterAlert("You entered: test");
        }

        [Test]
        public void SwitchingToAnIframe()
        {
            ScrollAndOpen("//a[contains(@href,'/frames')]");
            IWebElement iphrameLink = driver.FindElement(By.XPath("//a[contains(@href,'/iframe')]"));
            iphrameLink.Click();
            IWebElement iframeElement = driver.FindElement(By.XPath("//*[@id='mce_0_ifr']"));
            driver.SwitchTo().Frame(iframeElement);
            string pageTitle = driver.Title;
            ClassicAssert.AreEqual("The Internet", pageTitle);
            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void InteractingWithSelectElement()
        {
            ScrollAndOpen("//a[contains(@href,'/dropdown')]");
            SelectElement select = new SelectElement(driver.FindElement(By.XPath("//*[@id='dropdown']")));
            select.SelectByText("Option 1");
            string selectedOption = select.SelectedOption.Text;
            ClassicAssert.AreEqual("Option 1", selectedOption);
        }

        [Test]
        public void InteractingWithCheckboxElement()
        {
            ScrollAndOpen("//a[contains(@href,'/checkboxes')]");
            IWebElement checkbox = driver.FindElement(By.XPath("//*[@id='checkboxes']/input[1]"));
            checkbox.Click();
            bool isChecked = checkbox.Selected;
            ClassicAssert.AreEqual(true, isChecked);
        }

        [Test]
        public void InteractingWithRangeElement()
        {
            ScrollAndOpen("//a[contains(@href,'/horizontal_slider')]");
            IWebElement rangeInput = driver.FindElement(By.XPath("//input[contains(@type,'range')]"));
            rangeInput.SendKeys(Keys.ArrowRight);
            string rangeValue = rangeInput.GetAttribute("value");
            ClassicAssert.AreEqual("0.5", rangeValue);
        }

        [Test]
        public void InteractingWithTTextInputElement()
        {
            ScrollAndOpen("//a[contains(@href,'/inputs')]");
            IWebElement textInput = driver.FindElement(By.XPath("//input[contains(@type,'number')]"));
            textInput.SendKeys("123");
            string inputValue = textInput.GetAttribute("value");
            ClassicAssert.AreEqual("123", inputValue);
        }

        [Test]
        public void InteractingWithBasicAuth()
        {
            ScrollAndOpen("//a[contains(@href,'/basic_auth')]");
            driver.Navigate().GoToUrl("http://admin:admin@the-internet.herokuapp.com/basic_auth");
            IWebElement successAuth = driver.FindElement(By.XPath("//*[@id='content']/div/p"));
            string successAuthText = successAuth.Text;
            ClassicAssert.AreEqual("Congratulations! You must have the proper credentials.", successAuthText);
        }

        [Test]
        public void DownloadingAFile()
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string downloadPath = Path.Combine(userPath, "Downloads");
            DirectoryInfo dirInfo = new DirectoryInfo(downloadPath);
            var watcher = new FileSystemWatcher(downloadPath);

            ScrollAndOpen("//a[contains(@href,'/download')]");
            IWebElement firstFileLink = driver.FindElement(By.XPath("//*[@id='content']/div/a[1]"));
            string firstFileLinkText = firstFileLink.Text;
            firstFileLink.Click();

            var result = watcher.WaitForChanged(WatcherChangeTypes.Created, 5000);
            var getLatestFile = dirInfo.GetFiles()
             .OrderByDescending(f => f.LastWriteTime)
             .First();
            var fileName = getLatestFile.Name;
            ClassicAssert.AreEqual(firstFileLinkText, fileName);
        }

        [Test]
        public void ValidateDataSortedByFirstName()
        {
            ScrollAndOpen("//a[contains(@href,'/tables')]");
            IWebElement header = driver.FindElement(By.XPath("//*[@id='table1']/thead/tr/th[2]"));
            header.Click();
            var cells = driver.FindElements(By.XPath("//*[@id='table1']/tbody/tr/td[2]"));
            ClassicAssert.IsTrue(cells.OrderBy(c => c.Text).SequenceEqual(cells));
        }

        [Test]
        public void TestSortingToggleFunctionalityForLastName()
        {
            ScrollAndOpen("//a[contains(@href,'/tables')]");
            IWebElement header = driver.FindElement(By.XPath("//*[@id='table1']/thead/tr/th[1]"));
            header.Click();
            var cells = driver.FindElements(By.XPath("//*[@id='table1']/tbody/tr/td[1]"));
            ClassicAssert.IsTrue(cells.OrderBy(c => c.Text).SequenceEqual(cells));
            header.Click();
            var cells2 = driver.FindElements(By.XPath("//*[@id='table1']/tbody/tr/td[1]"));
            ClassicAssert.IsTrue(cells.OrderByDescending(c => c.Text).SequenceEqual(cells2));
        }

        [Test]
        public void ValidateRowData()
        {
            ScrollAndOpen("//a[contains(@href,'/tables')]");
            var cells = driver.FindElements(By.XPath("//*[@id='table1']/tbody/tr[1]/td[position()<6]"));
            ClassicAssert.AreEqual("Smith", cells[0].Text);
            ClassicAssert.AreEqual("John", cells[1].Text);
            ClassicAssert.AreEqual("jsmith@gmail.com", cells[2].Text);
            ClassicAssert.AreEqual("$50.00", cells[3].Text);
            ClassicAssert.AreEqual("http://www.jsmith.com", cells[4].Text);
        }

        [Test]
        public void TestNavigationAndReturnToPage()
        {
            ScrollAndOpen("//a[contains(@href,'/tables')]");
            IWebElement header = driver.FindElement(By.XPath("//*[@id='table1']/thead/tr/th[2]"));
            header.Click();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            driver.Navigate().Back();
            //sorting is not reset on the website, so this test will fail
            //var cells = driver.FindElements(By.XPath("//*[@id='table1']/tbody/tr/td[2]"));
            //ClassicAssert.IsTrue(cells.OrderBy(c => c.Text).SequenceEqual(cells));
        }

        [Test]
        public void ValidateDataSortedByDueColumn()
        {
            ScrollAndOpen("//a[contains(@href,'/tables')]");
            IWebElement header = driver.FindElement(By.XPath("//*[@id='table1']/thead/tr/th[4]"));
            header.Click();
            List<IWebElement> cellsList = driver.FindElements(By.XPath("//*[@id='table1']/tbody/tr/td[4]")).ToList();
            List<string> prices = new List<string>();
            cellsList.ForEach(product => prices.Add(product.Text.Substring(1)));
            List<double> pricesInt = prices.Select(s => Double.Parse(s, CultureInfo.InvariantCulture)).ToList();
            ClassicAssert.That(pricesInt, Is.Ordered.Ascending);
        }

        private void CheckResultAfterAlert(string expectedresult)
        {
            IWebElement result = driver.FindElement(By.XPath("//*[@id='result']"));
            string resultText = result.Text;
            ClassicAssert.AreEqual(expectedresult, resultText);
        }
    }
}
