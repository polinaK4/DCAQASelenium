using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class PerformanceManageReviewsPage : BasePage
    {
        private PoliWebElement _topBarConfigureDropdown => new PoliWebElement(By.XPath("//*[@aria-label='Topbar Menu']//span[.= 'Configure ']"));
        private PoliWebElement _configureDropdownKpiOption => new PoliWebElement(By.XPath("//*[@aria-label='Topbar Menu']//a[.= 'KPIs']"));

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
