using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM.EmployeeDetails
{
    public class EmployeePersonalDetails : BasePage
    {
        private PoliWebElement _employeeName => new PoliWebElement(By.XPath("//*[@class='orangehrm-edit-employee-name']/h6"));
        private TextboxElement _otherIdInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/*[@class='oxd-form-row'][2]/descendant::input[2]"));
        private List<PoliWebElement> _customFieldsLabels => driver.GetPoliWebElementList(By.XPath("//*[@class='orangehrm-custom-fields']//form//label"), 1);
        private string _customFieldsInputTypeLocator = "//*[@class='orangehrm-custom-fields']//*[@class='oxd-form-row']/descendant::input[{0}]";
        private TextboxElement _CustomFieldInputTypeByIndex(string index) => new TextboxElement(By.XPath(string.Format(_customFieldsInputTypeLocator, index)));
        private ButtonElement _savePersonalDetailsButton => new ButtonElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/descendant::div[@class='oxd-form-actions'][1]//button[@type='submit']"));
        private ButtonElement _saveCustomFieldsButton => new ButtonElement(By.XPath("//*[@class='orangehrm-custom-fields']//button[@type='submit']"));
        private ButtonElement _qualificationsPageButton => new ButtonElement(By.XPath("//*[@role='tablist']//*[@role='tab']/a[.= 'Qualifications']"));

        public EmployeePersonalDetails(IWebDriver driver) : base(driver)
        {

        }

        public void VerifyEmployeeName(string expectedText) => WaitForExpectedText(_employeeName, expectedText);

        public void EnterOtherId(string id)
        {
            WaitElementBeSelected(_otherIdInputField);
            _otherIdInputField.EnterText(id);
        }

        public void VerifyEmployeeOtherId(string expectedText) => WaitForExpectedText(_otherIdInputField, expectedText);

        public void ClickSavePersonalDetailsButton() => _savePersonalDetailsButton.ClickWhenReady();

        public List<string> GetCustomFieldsLabels() => _customFieldsLabels.Select(title => title.Text).ToList();

        public void FindAndFillCustomFieldByLabel(string fieldLabel, string inputText)
        {
            int i = _customFieldsLabels.FindIndex(v => v.Text == fieldLabel);
            _CustomFieldInputTypeByIndex($"{i + 1}").EnterText(inputText);
        }

        public void VerifyTextInCustomFieldByLabel(string fieldLabel, string expectedText)
        {
            int i = _customFieldsLabels.FindIndex(v => v.Text == fieldLabel);
            WaitForExpectedText(_CustomFieldInputTypeByIndex($"{i + 1}"), expectedText);
        }

        public void ClickSaveCustomFieldsButton() => _saveCustomFieldsButton.ClickWhenReady();

        public EmployeeQualificationsPage ClickQualificationsButton()
        {
            _qualificationsPageButton.ClickWhenReady();
            return new EmployeeQualificationsPage(driver);
        }
    }
}
