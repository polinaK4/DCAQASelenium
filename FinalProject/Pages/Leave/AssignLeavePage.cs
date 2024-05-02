using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Leave
{
    public class AssignLeavePage : BasePage
    {
        private TextboxElement employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']//input[@placeholder='Type for hints...']"));
        private PoliWebElement leaveTypeDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[2]//div[@class='oxd-select-text-input']"));
        private TextboxElement fromDateField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[3]/div/div[1]//input"));
        private TextboxElement toDateField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[3]/div/div[2]//input"));
        private ButtonElement assignButton => new ButtonElement(By.XPath("//button[@type='submit']"));

        public AssignLeavePage(IWebDriver driver) : base(driver)
        {

        }

        public void TypeToEmployeeNameForHint(string keyword) => employeeNameInputField.EnterText(keyword);

        public void ClickLeaveTypeDropdown() => leaveTypeDropdown.Click();

        public void EnterFromDate(string date) => fromDateField.EnterText(date);

        public void EnterToDate(string date) => toDateField.EnterText(date);

        public void ClickAssignButton() => assignButton.Click();
    }
}
