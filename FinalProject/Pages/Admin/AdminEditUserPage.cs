using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class AdminEditUserPage : BasePage
    {
        private PoliWebElement _userRoleDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[1]//div[@tabindex='0']"));
        private TextboxElement _employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[2]//input"));
        private PoliWebElement _statusDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[3]//div[@tabindex='0']"));
        private TextboxElement _usernameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[4]//input"));

        public AdminEditUserPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetUserRoleValue() => _userRoleDropdown.Text;

        public string GetEmployeeNameValue() => _employeeNameInputField.GetAttribute("value");

        public string GetStatusValue() => _statusDropdown.Text;

        public string GetUsernameValue() => _usernameInputField.GetAttribute("value");
    }
}
