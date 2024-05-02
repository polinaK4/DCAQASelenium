using FinalProject.Pages.LoginPage;
using FinalProject.Pages.General;
using NUnit.Framework;

namespace FinalProject.Tests
{
    public class AuthorizationTests : BaseTest
    {
        private LoginPage loginPage;
        private Header header;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void ValidateSuccessfulLogin()
        {
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            VerifyUrl("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
        }

        [Test]
        public void ValidateSuccessfulLogout()
        {
            header = new Header(driver);
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
            var forgotpasswordPage = loginPage.ClickForgotPasswordButton();
            forgotpasswordPage.EnterUsername("test");
            forgotpasswordPage.ClickResetPasswordButton();
            forgotpasswordPage.VerifyResetPasswordFormHeader("Reset Password link sent successfully");
        }
    }
}
