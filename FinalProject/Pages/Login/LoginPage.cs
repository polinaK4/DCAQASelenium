using FinalProject.Pages.Dashboard;
using FinalProject.Pages.Modules;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Login
{
    public class LoginPage : BasePage
    {
        private TextboxElement _usernameInputField => new TextboxElement(By.XPath("//input[@name='username']"));
        private TextboxElement _passwordInputField => new TextboxElement(By.XPath("//input[@name='password']"));
        private ButtonElement _loginButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private ButtonElement _forgotPasswordButton => new ButtonElement(By.XPath("//*[@class='orangehrm-login-forgot']/p"));

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterUsername(string username) => _usernameInputField.EnterText(username);

        public void EnterPassword(string password) => _passwordInputField.EnterText(password);

        public DashboardPage ClickLoginButton()
        {
            _loginButton.ClickWhenReady();
            return new DashboardPage(driver);
        }

        public ResetPasswordPage ClickForgotPasswordButton()
        {
            _forgotPasswordButton.ClickWhenReady();
            return new ResetPasswordPage(driver);
        }
    }
}
