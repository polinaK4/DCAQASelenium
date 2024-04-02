using OpenQA.Selenium;

namespace Module8.Pages.Authorization
{
    public class SignInPage : BasePage
    {
        private IWebElement emailInputField => GetElementAfterItVisible(By.XPath("//*[@id='username']"));
        private IWebElement continueWithEmailButton => GetElementAfterItVisible(By.XPath("//button[@type='submit']"));        

        public SignInPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterEmail(string email) => emailInputField.SendKeys(email);

        public CreatePasswordPage ClickContinueWithEmailButton()
        {
            continueWithEmailButton.Click();
            return new CreatePasswordPage(driver);
        }
    }
}