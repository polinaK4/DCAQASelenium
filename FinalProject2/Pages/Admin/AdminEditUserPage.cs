using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class AdminEditUserPage : BasePage
    {
        private PoliWebElement _userRoleDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/descendant::div[@class='oxd-select-text-input'][1]"));
        private TextboxElement _employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/descendant::input[1]"));
        private PoliWebElement _statusDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/descendant::div[@class='oxd-select-text-input'][2]"));
        private TextboxElement _usernameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/descendant::input[2]"));

        public AdminEditUserPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetUserRoleValue() => _userRoleDropdown.Text;

        public string GetEmployeeNameValue() => _employeeNameInputField.GetAttribute("value");

        public string GetStatusValue() => _statusDropdown.Text;

        public string GetUsernameValue() => _usernameInputField.GetAttribute("value");
    }
}
