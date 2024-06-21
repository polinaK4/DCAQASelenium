using FinalProject.Pages.Login;
using NUnit.Framework;
using FinalProject.Pages.Modules;

namespace FinalProject.Tests
{
    public class LoginTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");            
        }

        [Test]
        public void ValidateSuccessfulLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            VerifyUrl("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
        }

        [Test]
        public void ValidateSuccessfulLogout()
        {
            var loginPage = new LoginPage(driver);
            var header = new Header(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
            VerifyUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }

        [Test]
        public void ResetPassword()
        {
            var loginPage = new LoginPage(driver);
            var forgotpasswordPage = loginPage.ClickForgotPasswordButton();
            forgotpasswordPage.EnterUsername("test");
            forgotpasswordPage.ClickResetPasswordButton();
            forgotpasswordPage.VerifyResetPasswordFormHeader("Reset Password link sent successfully");
        }
    }
}
