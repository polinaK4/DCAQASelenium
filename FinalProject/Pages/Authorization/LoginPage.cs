using FinalProject.Pages.Dashboard;
using OpenQA.Selenium;

namespace FinalProject.Pages.Authorization
{
    public class LoginPage : BasePage
    {
        private IWebElement usernameInputField => GetElementAfterItVisible(By.XPath("//input[@name='username']"));
        private IWebElement passwordInputField => GetElementAfterItVisible(By.XPath("//input[@name='password']"));
        private IWebElement loginButton => GetElementAfterItVisible(By.XPath("//button[@type='submit']"));


        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterUsername(string username) => usernameInputField.SendKeys(username);

        public void EnterPassword(string password) => passwordInputField.SendKeys(password);

        public DashboardPage ClickLoginButton()
        {
            loginButton.Click();
            return new DashboardPage(driver);
        }
    }
}
