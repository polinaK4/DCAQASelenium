using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.CommonElements
{
    public class ConfirmationPopups : BasePage
    {
        private ButtonElement _confirmDeleteButton => new ButtonElement(By.XPath("//*[@class='orangehrm-modal-footer']/button[2]"));

        public ConfirmationPopups(IWebDriver driver) : base(driver)
        {

        }

        public void ClickConfirmDeleteButton() => _confirmDeleteButton.Click();
    }
}
