using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM.Configuration
{
    public class AddCustomFieldPage : BasePage
    {
        private TextboxElement _fieldNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/*[@class='oxd-form-row'][1]//input"));
        private PoliWebElement _screenDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/*[@class='oxd-form-row'][1]//*[@class='oxd-select-text-input']"));
        private DropdownElement _typeDropdown => new DropdownElement(By.XPath("//*[@class='oxd-form']/*[@class='oxd-form-row'][2]//*[@class='oxd-select-text-input']"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//*[@type='submit']"));

        public AddCustomFieldPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFieldName(string fieldName) => _fieldNameInputField.EnterText(fieldName);

        public void ClickScreenDropdown() => _screenDropdown.Click();

        public void SelectSpecificDropdownOption(string expectedText) => _typeDropdown.ClickSpecificOption(expectedText);

        public void ClickTypeDropdown() => _typeDropdown.Click();

        public CustomFieldsPage ClickSaveButton()
        {
            _saveButton.Click();
            return new CustomFieldsPage(driver);
        }
    }
}
