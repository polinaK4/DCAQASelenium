using FinalProject.Helpers;
using FinalProject.Pages.Admin;
using FinalProject.Pages.Leave;
using FinalProject.Pages.Performance;
using FinalProject.Pages.PIM;
using FinalProject.Pages.Recruitment.Candidates;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.General
{
    public class LeftSideMenuBar : BasePage
    {
        private TextboxElement searchInputField => new TextboxElement(By.XPath("//*[@class='oxd-main-menu-search']/input"));
        private List<PoliWebElement> menuOptions => driver.GetPoliWebElementList(By.XPath("//*[@class='oxd-main-menu']//span"));
        private PoliWebElement adminOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/admin/viewAdminModule']"));
        private PoliWebElement leaveOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/leave/viewLeaveModule']"));
        private PoliWebElement recruitmentOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/recruitment/viewRecruitmentModule']"));
        private PoliWebElement performanceOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/performance/viewPerformanceModule']"));
        private PoliWebElement pimOption => new PoliWebElement(By.XPath("//*[@href='/web/index.php/pim/viewPimModule']"));        

        public LeftSideMenuBar(IWebDriver driver) : base(driver)
        {

        }

        public AdminDefault_UserManagementPage ClickAdminOption()
        {
            adminOption.Click();
            return new AdminDefault_UserManagementPage(driver);
        }

        public LeaveListPage ClickLeaveOption()
        {
            leaveOption.Click();
            return new LeaveListPage(driver);
        }

        public RecruitmentCandidatesPage ClickRecruitmentOption()
        {
            recruitmentOption.Click();
            return new RecruitmentCandidatesPage(driver);
        }

        public PerformanceDefault_ManageReviewsPage ClickPerformanceOption()
        {
            performanceOption.Click();
            return new PerformanceDefault_ManageReviewsPage(driver);
        }

        public PimEmployeeListPage ClickPimOption()
        {
            pimOption.Click();
            return new PimEmployeeListPage(driver);
        }
        public void EnterKeyWordToSearch(string keyword) => searchInputField.EnterText(keyword);

        public List<String> MenuOptionsTextToLower() => menuOptions.Select(option => option.Text.ToLower()).ToList();
    }
}
