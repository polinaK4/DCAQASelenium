using FinalProject.Helpers;
using FinalProject.Pages.PIM.Configuration;
using FinalProject.Pages.PIM.EmployeeDetails;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM
{
    public class EmployeeListPage : BasePage
    {
        private ButtonElement _topbarConfigurationButton => new ButtonElement(By.XPath("//*[@class='oxd-topbar-body-nav']//li[1]"));
        private ButtonElement _topbarConfigurationCustomFieldsOption => new ButtonElement(By.XPath("//*[@class='oxd-topbar-body-nav']//li[1]/ul/li[2]"));        
        private ButtonElement _topbarAddEmployeeButton => new ButtonElement(By.XPath("//*[@class='oxd-topbar-body-nav']//li[3]"));
        private TextboxElement _employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[1]//input"));
        private TextboxElement _employeeIdInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[2]//input"));
        private ButtonElement _searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));     
        private List<PoliWebElement> _tableEmployeeIds => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div/div[2]"), 10, 1);
        private List<PoliWebElement> _tableEditButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div//button[2]"), 10, 1);
        private List<PoliWebElement> _tableDeleteButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div//button[1]"), 10, 1);

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

        public List<String> GetCurrentPageTableIds() => _tableEmployeeIds.Select(title => title.Text).ToList();

        public EmployeePersonalDetails ClickEditButtonForFirstTableRecord()
        {
            _tableEditButtons[0].Click();
            return new EmployeePersonalDetails(driver);
        }

        public void ClickDeleteButtonForFirstTableRecord() => _tableDeleteButtons[0].Click();
    }
}
