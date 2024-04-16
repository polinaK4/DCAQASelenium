using Module8.PoliWebElements;
using OpenQA.Selenium;

namespace Module8.Pages.Authorization
{
    public class CreatePasswordPage : BasePage
    {
        private TextboxElement passwordInputField => new TextboxElement(By.XPath("//*[@id='new_password']"));
        private TextboxElement confirmPasswordInputField => new TextboxElement(By.XPath("//*[@id='confirmed_password']"));

        public CreatePasswordPage(IWebDriver driver) : base(driver)
        {

        }

        public bool CheckPasswordFieldDisplayed() => passwordInputField.Displayed;

        public bool CheckConfirmPasswordFieldDisplayed() => confirmPasswordInputField.Displayed;
    }
}