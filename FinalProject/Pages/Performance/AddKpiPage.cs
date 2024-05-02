using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class AddKpiPage : BasePage
    {
        private TextboxElement kpiInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]//input"));
        private PoliWebElement jobTitleDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-select-wrapper']"));
        private PoliWebElement jobAutomationTester => new PoliWebElement(By.XPath("//*[@role='listbox']/div[3]"));
        private ButtonElement saveButton => new ButtonElement(By.XPath("//*[@class='oxd-form-actions']/button[@type='submit']"));
        

        public AddKpiPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterKpi(string kpi) => kpiInputField.EnterText(kpi);

        public void ClickJobTitleDropdown() => jobTitleDropdown.Click();

        public void SelectJobAutomationTester() => jobAutomationTester.Click();

        public PerformanceKpiPage ClickSaveButton()
        {
            saveButton.Click();
            return new PerformanceKpiPage(driver);
        }
    }
}
