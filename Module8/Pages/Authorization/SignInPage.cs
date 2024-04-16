using Module8.PoliWebElements;
using OpenQA.Selenium;

namespace Module8.Pages.Authorization
{
    public class SignInPage : BasePage
    {
        private TextboxElement emailInputField => new TextboxElement(By.XPath("//*[@id='username']"));
        private ButtonElement continueWithEmailButton => new ButtonElement(By.XPath("//button[@type='submit']"));        

        public SignInPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterEmail(string email) => emailInputField.EnterText(email);

        public CreatePasswordPage ClickContinueWithEmailButton()
        {
            continueWithEmailButton.ClickWhenReady();
            return new CreatePasswordPage(driver);
        }
    }
}