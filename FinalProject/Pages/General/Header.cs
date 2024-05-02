using FinalProject.Pages.Authorization;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.General
{
    public class Header : BasePage
    {
        private PoliWebElement userProfileDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-userdropdown-tab']"));
        private PoliWebElement logoutOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/auth/logout']"));        

        public Header(IWebDriver driver) : base(driver)
        {

        }

        public void ClickUserProfileDropdown() => userProfileDropdown.Click();

        public LoginPage ClickLogoutButton()
        {
            logoutOption.Click();
            return new LoginPage(driver);
        }
    }
}