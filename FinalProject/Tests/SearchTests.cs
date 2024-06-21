using FinalProject.Pages.Login;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using FinalProject.Pages.Modules;

namespace FinalProject.Tests
{
    public class SearchTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            var loginPage = new LoginPage(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();            
        }

        [Test]
        public void ValidateSearchFunctionality()
        {
            var leftSideMenuBar = new LeftSideMenuBar(driver);
            var header = new Header(driver);
            leftSideMenuBar.EnterKeyWordToSearch("my");
            leftSideMenuBar.MenuOptionsTextToLower().ForEach(result => { StringAssert.Contains("my", result); });
            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
            VerifyUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }
    }
}
