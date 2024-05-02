using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class EditNationalityPage : BasePage
    {
        private TextboxElement nameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']//input"));
        private ButtonElement saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));        

        public EditNationalityPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterTextToNameField(string keyword) => nameInputField.EnterText(keyword);

        public void ClickSaveButton() => saveButton.ClickWhenReady();
    }
}
