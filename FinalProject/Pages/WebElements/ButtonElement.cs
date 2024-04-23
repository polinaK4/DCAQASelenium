using FinalProject.Helpers;
using FinalProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject.Pages.WebElements
{
    public class ButtonElement
    {
        protected IWebDriver driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        protected IWebElement element;
        protected By By;

        public ButtonElement(By By)
        {
            element = driver.WaitForElementVisible(By, 10);
        }

        public void ClickWhenReady()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(this.element));
            this.element.Click();//
            //Click();
        }

    }
}
