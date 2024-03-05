using OpenQA.Selenium;

namespace Module7.Pages.Authorization
{
    public class LoginPage : BasePage
    {
        private string usernameInputLocator = "//*[@id='username']";
        private string passwordInputLocator = "//*[@id='password']";
        private string loginButtonLocator = "//*[@id='login']/button";
        private string topMessageLocator = "//*[@id='flash']";
        private IWebElement usernameInput => GetElement(By.XPath(usernameInputLocator));
        private IWebElement passwordInput => GetElement(By.XPath(passwordInputLocator));
        private IWebElement loginButton => GetElement(By.XPath(loginButtonLocator));
        private IWebElement topMessage => GetElement(By.XPath(topMessageLocator));

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterUsername(string username) => usernameInput.SendKeys(username);

        public void EnterPassword(string password) => passwordInput.SendKeys(password);

        public void ClickLoginButton() => loginButton.Click();

        public string TopMessageText() => topMessage.Text;

    }
}
