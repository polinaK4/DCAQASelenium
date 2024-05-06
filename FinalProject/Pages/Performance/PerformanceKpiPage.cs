using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class PerformanceKpiPage : BasePage
    {
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));
        private List<PoliWebElement> _tableSelectedPageKpis => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div/div[2]"),10,1);
        private List<PoliWebElement> _tableSelectedPageJobTitles => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div/div[3]"),10,1);     
        private List<PoliWebElement> _tableDeleteButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div//button[2]"), 10, 1);

        public PerformanceKpiPage(IWebDriver driver) : base(driver)
        {

        }

        public AddKpiPage ClickAddButton()
        {
            _addButton.Click();
            return new AddKpiPage(driver);
        }

        public List<String> GetTableCurrentPageKPITitles() => _tableSelectedPageKpis.Select(title => title.Text).ToList();

        public List<String> GetTableCurrentPageJobTitles() => _tableSelectedPageJobTitles.Select(title => title.Text).ToList();

        public void ClickDeleteButtonForSpecificKPI(string expectedText)
        {
            int i = _tableSelectedPageKpis.FindIndex(v => v.Text == expectedText);
            _tableDeleteButtons[i].Click();
        }
    }
}
