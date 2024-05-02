using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class AdminEditUserPage : BasePage
    {
        private PoliWebElement userRoleDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[1]//div[@tabindex='0']"));
        private TextboxElement employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[2]//input"));
        private PoliWebElement statusDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[3]//div[@tabindex='0']"));
        private TextboxElement usernameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[4]//input"));

        public AdminEditUserPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetUserRoleValue() => userRoleDropdown.Text;

        public string GetEmployeeNameValue() => employeeNameInputField.GetAttribute("value");

        public string GetStatusValue() => statusDropdown.Text;

        public string GetUsernameValue() => usernameInputField.GetAttribute("value");
    }
}
