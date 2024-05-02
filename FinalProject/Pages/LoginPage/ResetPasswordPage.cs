using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.LoginPage
{
    public class ResetPasswordPage : BasePage
    {
        private TextboxElement _usernameInputField => new TextboxElement(By.XPath("//input[@name='username']"));
        private ButtonElement _resetPasswordButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private PoliWebElement _resetPasswordFormHeader => new PoliWebElement(By.XPath("//*[@class='orangehrm-card-container']/h6"));        

        public ResetPasswordPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterUsername(string username) => _usernameInputField.EnterText(username);

        public void ClickResetPasswordButton() => _resetPasswordButton.ClickWhenReady();

        public void VerifyResetPasswordFormHeader(string expectedText) => WaitForExpectedText(_resetPasswordFormHeader, expectedText);
    }
}
