using FinalProject.Helpers;
using FinalProject.Utilities;
using OpenQA.Selenium;

namespace FinalProject.Pages.WebElements
{
    public class TextBoxElement
    {
        protected IWebDriver driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        protected IWebElement element;
        protected By By;

        public TextBoxElement(By By)
        {
            element = driver.WaitForElementVisible(By, 10);
        }

        public void EnterText(string text)
        {
            this.element.Clear();
            this.element.SendKeys(text);
        }
    }
}
