using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class PerformanceDefault_ManageReviewsPage : BasePage
    {
        private IWebElement configureDropdown => GetElementAfterItVisible(By.XPath("//*[@class='oxd-topbar-body-nav']//li[1]"));
        private IWebElement configureDropdownKpi => GetElementAfterItVisible(By.XPath("//*[@class='oxd-dropdown-menu']//li[1]"));

        public PerformanceDefault_ManageReviewsPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickConfigureDropdown() => configureDropdown.Click();

        public PerformanceKpiPage ClickKpiOption()
        {
            configureDropdownKpi.Click();
            return new PerformanceKpiPage(driver);
        }
    }
}
