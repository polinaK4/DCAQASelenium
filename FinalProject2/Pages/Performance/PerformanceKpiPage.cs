using FinalProject.Pages.Modules.Grid;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class PerformanceKpiPage : BasePage
    {
        public Grid grid => new Grid(driver);
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));

        public PerformanceKpiPage(IWebDriver driver) : base(driver)
        {

        }

        public AddKpiPage ClickAddButton()
        {
            _addButton.Click();
            return new AddKpiPage(driver);
        }

    }
}
