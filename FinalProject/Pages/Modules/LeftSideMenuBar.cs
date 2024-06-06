using FinalProject.Helpers;
using FinalProject.Pages.Admin;
using FinalProject.Pages.Leave;
using FinalProject.Pages.Performance;
using FinalProject.Pages.PIM;
using FinalProject.Pages.Recruitment.Candidates;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Modules
{
    public class LeftSideMenuBar : BasePage
    {
        private TextboxElement _searchInputField => new TextboxElement(By.XPath("//*[@class='oxd-main-menu-search']/input"));
        private List<PoliWebElement> _menuOptions => driver.GetPoliWebElementList(By.XPath("//*[@class='oxd-main-menu']//span"));
        private PoliWebElement _adminOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/admin/viewAdminModule']"));
        private PoliWebElement _leaveOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/leave/viewLeaveModule']"));
        private PoliWebElement _recruitmentOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/recruitment/viewRecruitmentModule']"));
        private PoliWebElement _performanceOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/performance/viewPerformanceModule']"));
        private PoliWebElement _pimOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/pim/viewPimModule']"));

        public LeftSideMenuBar(IWebDriver driver) : base(driver)
        {

        }

        public AdminUserManagementPage ClickAdminOption()
        {
            _adminOption.Click();
            return new AdminUserManagementPage(driver);
        }

        public LeaveListPage ClickLeaveOption()
        {
            _leaveOption.Click();
            return new LeaveListPage(driver);
        }

        public RecruitmentCandidatesPage ClickRecruitmentOption()
        {
            _recruitmentOption.Click();
            return new RecruitmentCandidatesPage(driver);
        }

        public PerformanceManageReviewsPage ClickPerformanceOption()
        {
            _performanceOption.Click();
            return new PerformanceManageReviewsPage(driver);
        }

        public EmployeeListPage ClickPimOption()
        {
            _pimOption.Click();
            return new EmployeeListPage(driver);
        }
        public void EnterKeyWordToSearch(string keyword) => _searchInputField.EnterText(keyword);

        public List<string> MenuOptionsTextToLower() => _menuOptions.Select(option => option.Text.ToLower()).ToList();
    }
}
