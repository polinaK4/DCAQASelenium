using Module7.Pages.Authorization;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module7.Tests
{
    [TestFixture]
    public class AuthorizationTests : BaseTest
    {
        private LoginPage loginPage;
        private LogOutPage logOutPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            loginPage = new LoginPage(driver);
            logOutPage = new LogOutPage(driver);
            ScrollAndOpenLink("/login");
        }

        [Test]
        public void ValidLogin()
        {
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLoginButton();
            VerifyUrl("http://the-internet.herokuapp.com/secure");
        }

        [Test]
        public void InvalidLogin()
        {
            loginPage.EnterUsername("invalid");
            loginPage.EnterPassword("invalid!");
            loginPage.ClickLoginButton();
            ClassicAssert.AreEqual("Your username is invalid!\r\n×", loginPage.TopMessageText());
        }

        [Test]
        public void LogoutAfterLogin()
        {
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLoginButton();
            logOutPage.ClickLogoutButton();
            ClassicAssert.AreEqual("You logged out of the secure area!\r\n×", loginPage.TopMessageText());
        }

        [Test]
        public void LoginWithEmptyCredentials()
        {
            loginPage.ClickLoginButton();
            ClassicAssert.AreEqual("Your username is invalid!\r\n×", loginPage.TopMessageText());
        }
    }
}
