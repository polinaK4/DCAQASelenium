using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Leave
{
    public class AssignLeavePage : BasePage
    {
        private PoliWebElement _pageTitle => new PoliWebElement(By.XPath("//*[@class='oxd-layout-context']//h6"));        
        private TextboxElement _employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']//input[@placeholder='Type for hints...']"));
        private DropdownElement _leaveTypeDropdown => new DropdownElement(By.XPath("//div[@class='oxd-select-text-input' and .= '-- Select --']"));
        private TextboxElement _fromDateField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']/descendant::div[@class='oxd-date-input'][1]/input"));
        private TextboxElement _toDateField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']/descendant::div[@class='oxd-date-input'][2]/input"));
        private ButtonElement _assignButton => new ButtonElement(By.XPath("//button[@type='submit']"));

        public AssignLeavePage(IWebDriver driver) : base(driver)
        {

        }

        public void TypeToEmployeeNameForHint(string keyword) => _employeeNameInputField.EnterText(keyword);

        public void ClickLeaveTypeDropdown() => _leaveTypeDropdown.Click();

        public void SelectSpecificDropdownOption(string expectedText) => _leaveTypeDropdown.ClickSpecificOption(expectedText);

        public void EnterFromDate(string date) => _fromDateField.EnterText(date);

        public void EnterToDate(string date) => _toDateField.EnterText(date);

        public void ClickAssignButton() => _assignButton.Click();

        public void VerifyPageTitle(string expectedTitle) => WaitForExpectedText(_pageTitle, expectedTitle);
    }
}
