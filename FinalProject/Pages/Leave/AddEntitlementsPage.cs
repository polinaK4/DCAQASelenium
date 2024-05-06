using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Leave
{
    public class AddEntitlementsPage : BasePage
    {
        private PoliWebElement _pageTitle => new PoliWebElement(By.XPath("//*[@class='oxd-layout-context']/div/div/p"));
        private TextboxElement _employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[2]//input"));
        private PoliWebElement _leaveTypeDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-form']/div[3]/div/div[1]//div[@class='oxd-select-text-input']"));
        private TextboxElement _entitlementInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[3]/div/div[3]//input"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));

        public AddEntitlementsPage(IWebDriver driver) : base(driver)
        {

        }

        public void TypeToEmployeeNameForHint(string keyword) => _employeeNameInputField.EnterText(keyword);

        public void ClickLeaveTypeDropdown() => _leaveTypeDropdown.Click();

        public void EnterEntitlement(string days) => _entitlementInputField.EnterText(days);

        public void ClickSaveButton() => _saveButton.ClickWhenReady();

        public void VerifyPageTitle(string expectedTitle) => WaitForExpectedText(_pageTitle, expectedTitle);

    }
}
