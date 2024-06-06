using FinalProject.Pages.Login;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using FinalProject.Pages.Performance;
using FinalProject.Pages.Modules;

namespace FinalProject.Tests
{
    public class PerformanceTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private PerformanceManageReviewsPage performanceManageReviewsPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            performanceManageReviewsPage = new PerformanceManageReviewsPage(driver);
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
            addKpiPage.SelectSpecificDropdownOption("Automaton Tester");
            addKpiPage.ClickSaveButton();            
            ClassicAssert.Contains("1 Kpi test", performanceKpiPage.grid.GetValuesOfSpecificColumn("Key Performance Indicator"));
            ClassicAssert.Contains("Automaton Tester", performanceKpiPage.grid.GetValuesOfSpecificColumn("Job Title"));
            var confirmationPopup = performanceKpiPage.grid.ClickDeleteButtonForSpecificRecord("1 Kpi test");
            confirmationPopup.ClickConfirmButton();
            ClassicAssert.That(performanceKpiPage.grid.GetValuesOfSpecificColumn("Key Performance Indicator"), Does.Not.Contain("1 Kpi test"));
        }
    }
}
