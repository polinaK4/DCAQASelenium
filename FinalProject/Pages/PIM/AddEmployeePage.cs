using FinalProject.Pages.PIM.EmployeeDetails;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM
{
    public class AddEmployeePage : BasePage
    {
        private TextboxElement _firstNameInputField => new TextboxElement(By.XPath("//*[@name='firstName']"));
        private TextboxElement _middleNameInputField => new TextboxElement(By.XPath("//*[@name='middleName']"));
        private TextboxElement _lastNameInputField => new TextboxElement(By.XPath("//*[@name='lastName']"));
        private TextboxElement _employeeIdInputField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']/div[contains(@class, 'oxd-grid-2')]//input"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//*[@type='submit']"));

        public AddEmployeePage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFirstName(string firstname) => _firstNameInputField.EnterText(firstname);

        public void EnterMiddleName(string middlename) => _middleNameInputField.EnterText(middlename);

        public void EnterLastName(string lastname) => _lastNameInputField.EnterText(lastname);

        public void EnterEmployeeId(string id) => _employeeIdInputField.EnterText(id);

        public EmployeePersonalDetails ClickSaveEmployeeButton()
        {
            _saveButton.ClickWhenReady();
            return new EmployeePersonalDetails(driver);
        }
    }
}
