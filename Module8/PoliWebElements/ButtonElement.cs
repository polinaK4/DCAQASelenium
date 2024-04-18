using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Module8.Wrappers;
using Module8.Helpers;
using OpenQA.Selenium.Support.Extensions;

namespace Module8.PoliWebElements
{
    public class ButtonElement : PoliWebElement
    {
        public ButtonElement(By By) : base(By)
        {

        }
        public void ClickWhenReady()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(this.element));
            Click();
        }

        public void ScrollAndClickWhenReady()
        {
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", this.element);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(this.element));
            Click();
        }
    }

}
