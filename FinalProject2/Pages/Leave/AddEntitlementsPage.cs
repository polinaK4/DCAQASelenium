using FinalProject.Pages.Modules;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Leave
{
    public class AddEntitlementsPage : BasePage
    {
        private PoliWebElement _pageTitle => new PoliWebElement(By.XPath("//*[@class='orangehrm-card-container']/p"));
        private TextboxElement _employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-autocomplete-wrapper']//input"));
        private DropdownElement _leaveTypeDropdown => new DropdownElement(By.XPath("//div[@class='oxd-select-text-input' and .= '-- Select --']"));
        private TextboxElement _entitlementInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']//*[@class='oxd-form-row'][3]//input"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));

        public AddEntitlementsPage(IWebDriver driver) : base(driver)
        {

        }

        public void TypeToEmployeeNameForHint(string keyword) => _employeeNameInputField.EnterText(keyword);

        public void ClickLeaveTypeDropdown() => _leaveTypeDropdown.Click();

        public void SelectSpecificDropdownOption(string expectedText) => _leaveTypeDropdown.ClickSpecificOption(expectedText);

        public void EnterEntitlement(string days) => _entitlementInputField.EnterText(days);

        public ConfirmationPopup ClickSaveButton() 
        { 
            _saveButton.ClickWhenReady();
            return new ConfirmationPopup(driver);
        }

        public void VerifyPageTitle(string expectedTitle) => WaitForExpectedText(_pageTitle, expectedTitle);

    }
}
