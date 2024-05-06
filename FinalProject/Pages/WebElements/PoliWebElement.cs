using FinalProject.Helpers;
using FinalProject.Utilities;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;

namespace FinalProject.Pages.WebElements
{
    public class PoliWebElement : IWebElement
    {
        protected By By;
        protected IWebElement element;
        protected IWebDriver driver => BrowserFactory.GetDriver();        

        public PoliWebElement(By By)
        {
            element = driver.GetElement(By);
        }

        public PoliWebElement(IWebElement element)
        {
            this.element = element;
        }

        public string Text => element.Text;

        public bool Enabled => element.Enabled;

        public bool Selected => throw new NotImplementedException();

        public string TagName => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => element.Displayed;

        public void Clear() => element.Clear();

        public void SendKeys(string text) => element.SendKeys(text);

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click() => element.Click();

        public string GetAttribute(string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
    }
}
