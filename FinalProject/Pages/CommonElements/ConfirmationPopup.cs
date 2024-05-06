using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.CommonElements
{
    public class ConfirmationPopup : BasePage
    {
        private ButtonElement _confirmButton => new ButtonElement(By.XPath("//*[@class='orangehrm-modal-footer']/button[2]"));

        public ConfirmationPopup(IWebDriver driver) : base(driver)
        {

        }

        public void ClickConfirmButton() => _confirmButton.Click();
    }
}
