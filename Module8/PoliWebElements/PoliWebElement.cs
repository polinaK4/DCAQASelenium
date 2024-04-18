using Module8.Helpers;
using Module8.Utilities;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Module8.Wrappers
{
    public class PoliWebElement : IWebElement
    {
        protected By By;
        protected IWebDriver driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        //driver = BrowserFactory.GetDriver(BrowserType.Firefox);
        protected IWebElement element;

        public PoliWebElement()
        {
            //element = driver.WaitForElementVisible(By, 10);
        }

        public IWebElement FindElement(By by)
        {
           return driver.WaitForElementVisible(By, 10);
        }

        public List<IWebElement> FindElementsToList(By by)
        {
            return driver.FindElements(by).ToList();
        }

        public string Text => element.Text;

        public bool Displayed => element.Displayed;

        public string TagName => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public void Clear() => element.Clear();

        public void Click() => element.Click();



        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }


        public string GetAttribute(string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        // other functions

        private bool otherFunctionEnabled()
        {
            // some other function to check whether element is enabled or not
            return true;
        }

    }
}
