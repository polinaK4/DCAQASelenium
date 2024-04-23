using FinalProject.Pages.Authorization;
using OpenQA.Selenium;

namespace FinalProject.Pages.General
{
    public class Header : BasePage
    {
        private IWebElement userProfileDropdown => GetElementAfterItVisible(By.XPath("//*[@class='oxd-userdropdown-tab']"));
        private IWebElement logoutOption => GetElementAfterItVisible(By.XPath("//*[@href='/web/index.php/auth/logout']"));
        

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