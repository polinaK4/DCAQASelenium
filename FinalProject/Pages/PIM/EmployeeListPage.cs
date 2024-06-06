using FinalProject.Pages.Modules.Grid;
using FinalProject.Pages.PIM.Configuration;
using FinalProject.Pages.PIM.EmployeeDetails;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM
{
    public class EmployeeListPage : BasePage
    {
        public Grid grid => new Grid(driver);
        private ButtonElement _topbarConfigurationButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//span[.= 'Configuration ']"));
        private ButtonElement _topbarConfigurationCustomFieldsOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//a[.= 'Custom Fields']"));        
        private ButtonElement _topbarAddEmployeeButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//a[.= 'Add Employee']"));
        private TextboxElement _employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']//div[contains(@class,'oxd-grid-item')][1]//input"));
        private TextboxElement _employeeIdInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']//div[contains(@class,'oxd-grid-item')][2]//input"));
        private ButtonElement _searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private DropdownElement dropdown => new DropdownElement(By.XPath("//*[@class='oxd-form']"));

        public EmployeeListPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickTopbarConfigurationButton() => _topbarConfigurationButton.ClickWhenReady();

        public AddEmployeePage CliclAddEmployeeTab()
        {
            _topbarAddEmployeeButton.ClickWhenReady();
            return new AddEmployeePage(driver);
        }

        public CustomFieldsPage ClickCustomFieldsOption()
        {
            _topbarConfigurationCustomFieldsOption.ClickWhenReady();
            return new CustomFieldsPage(driver);
        }

        public void TypeToEmployeeNameForHint(string keyword) => _employeeNameInputField.EnterText(keyword);

        public void EnterEmployeeId(string id) => _employeeIdInputField.EnterText(id);

        public void ClickSearchButton() => _searchButton.ClickWhenReady();

        public EmployeePersonalDetails ClickEditButtonForSpecificEmployee(string rowValue)
        {
            grid.ClickEditButtonForSpecificRecord(rowValue);
            return new EmployeePersonalDetails(driver);
        }

        public void SelectSpecificDropdownOption(string expectedText) => dropdown.ClickSpecificOption(expectedText);

    }
}
