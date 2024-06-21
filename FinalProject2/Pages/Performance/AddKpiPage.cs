using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class AddKpiPage : BasePage
    {
        private TextboxElement _kpiInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/*[@class='oxd-form-row'][1]//input"));
        private DropdownElement _jobTitleDropdown => new DropdownElement(By.XPath("//*[@class='oxd-select-wrapper']"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//*[@class='oxd-form-actions']/button[@type='submit']"));

        public AddKpiPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterKpi(string kpi) => _kpiInputField.EnterText(kpi);

        public void ClickJobTitleDropdown() => _jobTitleDropdown.Click();

        public void SelectSpecificDropdownOption(string expectedText) => _jobTitleDropdown.ClickSpecificOption(expectedText);

        public PerformanceKpiPage ClickSaveButton()
        {
            _saveButton.Click();
            return new PerformanceKpiPage(driver);
        }
    }
}
