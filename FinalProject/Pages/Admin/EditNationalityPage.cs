using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class EditNationalityPage : BasePage
    {
        private TextboxElement _nameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form-row']//input"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));        

        public EditNationalityPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterTextToNameField(string keyword) => _nameInputField.EnterText(keyword);

        public void ClickSaveButton() => _saveButton.ClickWhenReady();
    }
}
