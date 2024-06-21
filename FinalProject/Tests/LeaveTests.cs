using FinalProject.Pages.Login;
using NUnit.Framework;
using System.Drawing;
using FinalProject.Pages.Modules;

namespace FinalProject.Tests
{
    public class LeaveTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Size = new Size(1024, 768);
            var loginPage = new LoginPage(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
        }

        [Test]
        public void AssignLeave()
        {
            var leftSideMenuBar = new LeftSideMenuBar(driver);
            var leaveListPage = leftSideMenuBar.ClickLeaveOption();
            leaveListPage.ClickEntitlementsOption();
            var addEntitlementsPage = leaveListPage.ClickAddEntitlementsOption();
            addEntitlementsPage.VerifyPageTitle("Add Leave Entitlement");
            addEntitlementsPage.TypeToEmployeeNameForHint("Amelia");
            addEntitlementsPage.SelectSpecificDropdownOption("Amelia Brown");
            addEntitlementsPage.ClickLeaveTypeDropdown();
            addEntitlementsPage.SelectSpecificDropdownOption("CAN - Vacation");
            addEntitlementsPage.EnterEntitlement("10");
            var confirmationPopup = addEntitlementsPage.ClickSaveButton();
            confirmationPopup.ClickConfirmButton();
            leaveListPage.ClickMoreOption();
            var assignLeavePage = leaveListPage.ClickAssignLeaveOption();
            assignLeavePage.VerifyPageTitle("Assign Leave");
            assignLeavePage.TypeToEmployeeNameForHint("Amelia");
            assignLeavePage.SelectSpecificDropdownOption("Amelia Brown");
            assignLeavePage.ClickLeaveTypeDropdown();
            assignLeavePage.SelectSpecificDropdownOption("CAN - Vacation");
            assignLeavePage.EnterFromDate("2024-26-05");
            assignLeavePage.EnterToDate("2024-28-05");
            assignLeavePage.ClickAssignButton();
            //probably an issue on website - added Leave is not displayed anyware
        }
    }
}
