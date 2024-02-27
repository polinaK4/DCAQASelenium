using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class LoginPage
    {
        private IWebDriver driver;

        private readonly By usernameInput = By.XPath("//*[@id='username']");
        private readonly By passwordInput = By.XPath("//*[@id='password']");
        private readonly By loginButton = By.XPath("//*[@id='login']/button");
        private readonly By topMessage = By.XPath("//*[@id='flash']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUsername(string username) => driver.FindElement(usernameInput).SendKeys(username);

        public void EnterPassword(string password) => driver.FindElement(passwordInput).SendKeys(password);

        public void ClickLoginButton() => driver.FindElement(loginButton).Click();

        public string TopMessageText() => driver.FindElement(topMessage).Text;

    }
}
