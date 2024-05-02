using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM
{
    public class PimAddEmployee : BasePage
    {
        private TextboxElement firstNameInputField => new TextboxElement(By.XPath("//*[@name='firstName']"));
        private TextboxElement middleNameInputField => new TextboxElement(By.XPath("//*[@name='middleName']"));
        private TextboxElement lastNameInputField => new TextboxElement(By.XPath("//*[@name='lastName']"));
        private TextboxElement employeeIdInputField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']/div[2]//input"));
        private ButtonElement saveButton => new ButtonElement(By.XPath("//*[@type='submit']"));

        public PimAddEmployee(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFirstName(string firstname) => firstNameInputField.EnterText(firstname);

        public void EnterMiddleName(string middlename) => middleNameInputField.EnterText(middlename);

        public void EnterLastName(string lastname) => lastNameInputField.EnterText(lastname);

        public void EnterEmployeeId(string id) => employeeIdInputField.EnterText(id);

        public PimEmployeeListPersonalDetails ClickSaveEmployeeButton()
        {
            saveButton.ClickWhenReady();
            return new PimEmployeeListPersonalDetails(driver);
        }
    }
}
