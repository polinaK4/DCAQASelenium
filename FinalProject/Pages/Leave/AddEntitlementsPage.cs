using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Leave
{
    public class AddEntitlementsPage : BasePage
    {
        private TextboxElement employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']//input[@placeholder='Type for hints...']"));
        private PoliWebElement leaveTypeDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[3]/div/div[1]//div[@class='oxd-select-text-input']"));
        private TextboxElement entitlementInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[3]/div/div[3]//input"));
        private ButtonElement saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private ButtonElement confirmSaveButton => new ButtonElement(By.XPath("//*[@class='orangehrm-modal-footer']/button[2]"));

        //*[@class='orangehrm-modal-footer']/button[2]
        public AddEntitlementsPage(IWebDriver driver) : base(driver)
        {

        }

        public void TypeToEmployeeNameForHint(string keyword) => employeeNameInputField.EnterText(keyword);

        public void ClickLeaveTypeDropdown() => leaveTypeDropdown.Click();

        public void EnterEntitlement(string days) => entitlementInputField.EnterText(days);

        public void ClickSaveButton() => saveButton.ClickWhenReady();

        public void ClickConfirmSaveButton() => confirmSaveButton.ClickWhenReady();
    }
}
