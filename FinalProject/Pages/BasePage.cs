using FinalProject.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetElementAfterItVisible(By element)
        {
            return driver.WaitForElementVisible(element, 20);
        }

        public List<IWebElement> GetListOfElements(By element)
        {
            return driver.FindElements(element).ToList();
        }

        public void WaitForExpectedText(IWebElement element, string expectedText)
        {
            driver.WaitForTextToBePresentInElement(element, 10, expectedText);
        }
    }
}
