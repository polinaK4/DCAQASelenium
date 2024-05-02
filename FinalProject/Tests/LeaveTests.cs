using FinalProject.Pages.Authorization;
using FinalProject.Pages.CommonElements;
using FinalProject.Pages.General;
using FinalProject.Pages.Leave;
using NUnit.Framework;

namespace FinalProject.Tests
{
    public class LeaveTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private LeaveListPage leaveListPage;
        private FieldOptionsDropdown commonElements;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            leaveListPage = new LeaveListPage(driver);
            commonElements = new FieldOptionsDropdown(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            leftSideMenuBar.ClickLeaveOption();
        }

        [Test]
        public void AssignLeave()
        {
            leaveListPage.ClickEntitlementsOption();
            var addEntitlementsPage = leaveListPage.ClickAddEntitlementsOption();
            addEntitlementsPage.TypeToEmployeeNameForHint("Peter");
            commonElements.SelectSpecificOption("Peter Mac Anderson");
            addEntitlementsPage.ClickLeaveTypeDropdown();
            commonElements.SelectSpecificOption("CAN - Vacation");
            addEntitlementsPage.EnterEntitlement("20");
            addEntitlementsPage.ClickSaveButton();
            addEntitlementsPage.ClickConfirmSaveButton();
            leaveListPage.ClickMoreOption();
            var assignLeavePage = leaveListPage.ClickAssignLeaveOption();
            assignLeavePage.TypeToEmployeeNameForHint("Peter");
            commonElements.SelectSpecificOption("Peter Mac Anderson");
            assignLeavePage.ClickLeaveTypeDropdown();
            commonElements.SelectSpecificOption("CAN - Vacation");
            assignLeavePage.EnterFromDate("2024-26-04");
            assignLeavePage.EnterToDate("2024-10-05");
            assignLeavePage.ClickAssignButton();
        }
    }
}
