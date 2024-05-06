using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM.EmployeeDetails
{
    public class EmployeePersonalDetails : BasePage
    {
        private PoliWebElement _employeeName => new PoliWebElement(By.XPath("//*[@class='orangehrm-edit-employee-name']/h6"));
        private TextboxElement _otherIdInputField => new TextboxElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/div[1]/form/div[2]/div[1]/div[2]//input"));
        private List<PoliWebElement> _customFieldsLabels => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='orangehrm-custom-fields']//form//label"), 10, 1);
        private string _customFieldsInputTypeLocator = "//*[@class='orangehrm-custom-fields']//form/div[1]/div/div[{0}]//input";
        private TextboxElement _customFieldInputTypeByIndex(string index) => new TextboxElement(By.XPath(string.Format(_customFieldsInputTypeLocator, index)));
        private ButtonElement _savePersonalDetailsButton => new ButtonElement(By.XPath("//*[@class='oxd-form']/div[4]/button"));
        private ButtonElement _saveCustomFieldsButton => new ButtonElement(By.XPath("//*[@class='orangehrm-custom-fields']//button"));
        private ButtonElement _qualificationsPageButton => new ButtonElement(By.XPath("//*[@class='orangehrm-edit-employee-navigation']//*[@role='tab'][9]/a"));

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
            _customFieldInputTypeByIndex($"{i + 1}").EnterText(inputText);
        }

        public void VerifyTextInCustomFieldByLabel(string fieldLabel, string expectedText)
        {
            int i = _customFieldsLabels.FindIndex(v => v.Text == fieldLabel);
            WaitForExpectedText(_customFieldInputTypeByIndex($"{i + 1}"), expectedText);
        }

        public void ClickSaveCustomFieldsButton() => _saveCustomFieldsButton.ClickWhenReady();

        public EmployeeQualificationsPage ClickQualificationsButton()
        {
            _qualificationsPageButton.ClickWhenReady();
            return new EmployeeQualificationsPage(driver);
        }
    }
}
