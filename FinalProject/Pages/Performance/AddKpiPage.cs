using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class AddKpiPage : BasePage
    {
        private TextboxElement _kpiInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]//input"));
        private PoliWebElement _jobTitleDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-select-wrapper']"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//*[@class='oxd-form-actions']/button[@type='submit']"));
        

        public AddKpiPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterKpi(string kpi) => _kpiInputField.EnterText(kpi);

        public void ClickJobTitleDropdown() => _jobTitleDropdown.Click();

        public PerformanceKpiPage ClickSaveButton()
        {
            _saveButton.Click();
            return new PerformanceKpiPage(driver);
        }
    }
}
