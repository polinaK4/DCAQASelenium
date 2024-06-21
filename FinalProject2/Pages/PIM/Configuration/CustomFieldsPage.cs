using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM.Configuration
{
    public class CustomFieldsPage : BasePage
    {
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));

        public CustomFieldsPage(IWebDriver driver) : base(driver)
        {

        }

        public AddCustomFieldPage ClickAddButton()
        {
            _addButton.Click();
            return new AddCustomFieldPage(driver);
        }
    }
}
