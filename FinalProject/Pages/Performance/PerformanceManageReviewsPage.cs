using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class PerformanceManageReviewsPage : BasePage
    {
        private PoliWebElement _topBarConfigureDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-topbar-body-nav']//li[1]"));
        private PoliWebElement _configureDropdownKpiOption => new PoliWebElement(By.XPath("//*[@class='oxd-dropdown-menu']//li[1]"));

        public PerformanceManageReviewsPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickConfigureDropdown() => _topBarConfigureDropdown.Click();

        public PerformanceKpiPage ClickKpiOption()
        {
            _configureDropdownKpiOption.Click();
            return new PerformanceKpiPage(driver);
        }
    }
}
