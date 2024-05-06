using FinalProject.Pages.Login;
using FinalProject.Pages.General;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using FinalProject.Pages.Performance;
using FinalProject.Pages.CommonElements;

namespace FinalProject.Tests
{
    public class PerformanceTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private PerformanceManageReviewsPage performanceManageReviewsPage;
        private FieldOptionsDropdown fieldOptionsDropdown;
        private ConfirmationPopup confirmationPopups;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            performanceManageReviewsPage = new PerformanceManageReviewsPage(driver);
            fieldOptionsDropdown = new FieldOptionsDropdown(driver);
            confirmationPopups = new ConfirmationPopup(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            leftSideMenuBar.ClickPerformanceOption();
        }

        [Test]
        public void ValidatePerformanceManagementFunctionality()
        {
            performanceManageReviewsPage.ClickConfigureDropdown();
            var performanceKpiPage = performanceManageReviewsPage.ClickKpiOption();
            var addKpiPage = performanceKpiPage.ClickAddButton();
            addKpiPage.EnterKpi("1 Kpi test");
            addKpiPage.ClickJobTitleDropdown();
            fieldOptionsDropdown.SelectSpecificOption("Automaton Tester");
            addKpiPage.ClickSaveButton();            
            ClassicAssert.Contains("1 Kpi test", performanceKpiPage.GetTableCurrentPageKPITitles());
            ClassicAssert.Contains("Automaton Tester", performanceKpiPage.GetTableCurrentPageJobTitles());
            performanceKpiPage.ClickDeleteButtonForSpecificKPI("1 Kpi test");
            confirmationPopups.ClickConfirmButton();
            ClassicAssert.That(performanceKpiPage.GetTableCurrentPageKPITitles(), Does.Not.Contain("1 Kpi test"));
        }
    }
}
