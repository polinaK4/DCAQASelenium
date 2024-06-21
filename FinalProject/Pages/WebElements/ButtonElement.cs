using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject.Pages.WebElements
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
            this.element.Click();
        }
    }
}