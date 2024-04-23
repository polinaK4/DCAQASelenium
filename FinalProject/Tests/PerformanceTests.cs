using FinalProject.Pages.Authorization;
using FinalProject.Pages.General;
using FinalProject.Pages.Performance;
using NUnit.Framework;

namespace FinalProject.Tests
{
    public class PerformanceTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        //private PerformanceDefault_ManageReviewsPage performanceManageReviewsPage;
        //private PerformanceKpiPage performanceKpiPage;

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


        }
    }
}
