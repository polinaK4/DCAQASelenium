using FinalProject.Pages.Login;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Modules
{
    public class Header : BasePage
    {
        private PoliWebElement _userProfileDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-userdropdown-tab']"));
        private PoliWebElement _logoutOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/auth/logout']"));

        public Header(IWebDriver driver) : base(driver)
        {

        }

        public void ClickUserProfileDropdown() => _userProfileDropdown.Click();

        public LoginPage ClickLogoutButton()
        {
            _logoutOption.Click();
            return new LoginPage(driver);
        }
    }
}