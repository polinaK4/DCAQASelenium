using FinalProject.Pages.Login;
using FinalProject.Pages.Dashboard;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FinalProject.Tests
{
    public class DashboardTests : BaseTest
    {
        private DashboardPage _dashboardPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            var loginPage = new LoginPage(driver);
            _dashboardPage = loginPage.ClickLoginButton();
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
        }

        [Test]
        public void ValidateDashboardAccess()
        {
            ClassicAssert.AreEqual(true, _dashboardPage.AssignLeaveQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, _dashboardPage.LeaveListQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, _dashboardPage.TimesheetsQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, _dashboardPage.ApplyLeaveQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, _dashboardPage.MyLeaveQuickLaunchButtonEnabled());
            ClassicAssert.AreEqual(true, _dashboardPage.MyTimesheetQuickLaunchButtonEnabled());
        }
    }
}
