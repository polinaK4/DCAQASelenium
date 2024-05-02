using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM
{
    public class PimEmployeeListPersonalDetails : BasePage
    {
        private PoliWebElement _employeeName => new PoliWebElement(By.XPath("//*[@class='orangehrm-edit-employee-name']/h6"));
        private TextboxElement _lastNameInputField => new TextboxElement(By.XPath("//input[@name='lastName']"));
        private PoliWebElement _customFieldsLabels => new PoliWebElement(By.XPath("//*[@class='orangehrm-custom-fields']//form//label"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));

        public PimEmployeeListPersonalDetails(IWebDriver driver) : base(driver)
        {

        }

        public void VerifyEmployeeName(string expectedText) => WaitForExpectedText(_employeeName, expectedText);

        public void EnterLastName(string lastname)
        {
            WaitElementBeSelected(_lastNameInputField);
            _lastNameInputField.EnterText(lastname);
        }

        public void VerifyEmployeeLastName(string expectedText) => WaitForExpectedText(_lastNameInputField, expectedText);

        public void ClickSaveButton() => _saveButton.ClickWhenReady();
    }
}
