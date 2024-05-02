using FinalProject.Pages.Authorization;
using FinalProject.Pages.Dashboard;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FinalProject.Tests
{
    public class DashboardTests : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;
        //private LeftSideMenuBar leftSideMenuBar;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
            //leftSideMenuBar = new LeftSideMenuBar(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
        }

        [Test]
        public void ValidateDashboardAccess()
        {
            ClassicAssert.AreEqual(true, dashboardPage.AssignLeaveQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, dashboardPage.LeaveListQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, dashboardPage.TimesheetsQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, dashboardPage.ApplyLeaveQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, dashboardPage.MyLeaveQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, dashboardPage.MyTimesheetQuickLaunchButtonEnabled());
        }
    }
}
