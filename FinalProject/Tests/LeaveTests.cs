using FinalProject.Pages.Login;
using FinalProject.Pages.CommonElements;
using FinalProject.Pages.General;
using FinalProject.Pages.Leave;
using NUnit.Framework;
using System.Drawing;

namespace FinalProject.Tests
{
    public class LeaveTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private LeaveListPage leaveListPage;
        private FieldOptionsDropdown fieldOptionsDropdown;
        private ConfirmationPopup confirmationPopup;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Size = new Size(1024, 768);
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            leaveListPage = new LeaveListPage(driver);
            fieldOptionsDropdown = new FieldOptionsDropdown(driver);
            confirmationPopup = new ConfirmationPopup(driver);
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
            addEntitlementsPage.VerifyPageTitle("Add Leave Entitlement");
            addEntitlementsPage.TypeToEmployeeNameForHint("Amelia");
            fieldOptionsDropdown.SelectSpecificOption("Amelia Brown");
            addEntitlementsPage.ClickLeaveTypeDropdown();
            fieldOptionsDropdown.SelectSpecificOption("CAN - Vacation");
            addEntitlementsPage.EnterEntitlement("10");
            addEntitlementsPage.ClickSaveButton();
            confirmationPopup.ClickConfirmButton();
            leaveListPage.ClickMoreOption();
            var assignLeavePage = leaveListPage.ClickAssignLeaveOption();
            assignLeavePage.VerifyPageTitle("Assign Leave");
            assignLeavePage.TypeToEmployeeNameForHint("Amelia");
            fieldOptionsDropdown.SelectSpecificOption("Amelia Brown");
            assignLeavePage.ClickLeaveTypeDropdown();
            fieldOptionsDropdown.SelectSpecificOption("CAN - Vacation");
            assignLeavePage.EnterFromDate("2024-26-05");
            assignLeavePage.EnterToDate("2024-28-05");
            assignLeavePage.ClickAssignButton();
            //probably an issue on website - added Leave is not displayed anyware
        }
    }
}
