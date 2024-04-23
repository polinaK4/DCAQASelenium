using FinalProject.Pages.Authorization;
using FinalProject.Pages.General;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FinalProject.Tests
{
    public class SearchTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private Header header;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
        }

        [Test]
        public void ValidateSearchFunctionality()
        {
            header = new Header(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            leftSideMenuBar.EnterKeyWordToSearch("my");
            leftSideMenuBar.MenuOptionsText().ForEach(result => { StringAssert.Contains("my", result); });
            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
            VerifyUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }
    }
}
