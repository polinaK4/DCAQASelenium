using OpenQA.Selenium;

namespace Module8.Pages.Authorization
{
    public class CreatePasswordPage : BasePage
    {
        private IWebElement passwordInputField => GetElementAfterItVisible(By.XPath("//*[@id='new_password']"));
        private IWebElement confirmPasswordInputField => GetElementAfterItVisible(By.XPath("//*[@id='confirmed_password']"));

        public CreatePasswordPage(IWebDriver driver) : base(driver)
        {

        }

        public bool CheckPasswordFieldDisplayed() => passwordInputField.Displayed;

        public bool CheckConfirmPasswordFieldDisplayed() => confirmPasswordInputField.Displayed;
    }
}