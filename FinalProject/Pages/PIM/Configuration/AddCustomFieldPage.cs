using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM.Configuration
{
    public class AddCustomFieldPage : BasePage
    {
        private TextboxElement _fieldNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]//input"));
        private PoliWebElement _screenDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[1]//div[@tabindex='0']"));
        private PoliWebElement _typeDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[2]//div[@tabindex='0']"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//*[@type='submit']"));

        public AddCustomFieldPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFieldName(string fieldName) => _fieldNameInputField.EnterText(fieldName);

        public void ClickScreenDropdown() => _screenDropdown.Click();

        public void ClickTypeDropdown() => _typeDropdown.Click();

        public CustomFieldsPage ClickSaveButton()
        {
            _saveButton.Click();
            return new CustomFieldsPage(driver);
        }
    }
}
