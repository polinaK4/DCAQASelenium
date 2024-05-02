using FinalProject.Pages.Authorization;
using FinalProject.Pages.General;
using FinalProject.Pages.Performance;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FinalProject.Tests
{
    public class PerformanceTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
        }

        [Test]
        public void ValidatePerformanceManagementFunctionality()
        {
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            var performanceManageReviewsPage = leftSideMenuBar.ClickPerformanceOption();
            performanceManageReviewsPage.ClickConfigureDropdown();
            var performanceKpiPage = performanceManageReviewsPage.ClickKpiOption();
            var addKpiPage = performanceKpiPage.ClickAddButton();
            addKpiPage.EnterKpi("1 Kpi test");
            addKpiPage.ClickJobTitleDropdown();
            addKpiPage.SelectJobAutomationTester();
            addKpiPage.ClickSaveButton();           
            ClassicAssert.Contains("1 Kpi test", performanceKpiPage.First50KpiTitles()); // нужно стабилизировать (wait)
            ClassicAssert.Contains("Automaton Tester", performanceKpiPage.FirstPageJobTitlesText());
            performanceKpiPage.ClickDeleteButton();
            performanceKpiPage.ClickConfirmDeleteButton();
            ClassicAssert.That(performanceKpiPage.First50KpiTitles(), Does.Not.Contain("1 Kpi test"));
        }
    }
}
