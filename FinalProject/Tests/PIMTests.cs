using FinalProject.Pages.Login;
using FinalProject.Pages.CommonElements;
using FinalProject.Pages.General;
using FinalProject.Pages.PIM;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Drawing;

namespace FinalProject.Tests
{
    public class PIMTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private EmployeeListPage employeeListPage;
        private FieldOptionsDropdown fieldOptionsDropdown;
        private Header header;
        private ConfirmationPopup confirmationPopups;
        private CommonTableElements commonTableElements;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Size = new Size(1024, 768);
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            employeeListPage = new EmployeeListPage(driver);
            fieldOptionsDropdown = new FieldOptionsDropdown(driver);
            header = new Header(driver);
            confirmationPopups = new ConfirmationPopup(driver);
            commonTableElements = new CommonTableElements(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            leftSideMenuBar.ClickPimOption();
        }

        [Test]
        public void AddNewEmployee()
        {
            var addEmployeePage = employeeListPage.CliclAddEmployeeTab();
            addEmployeePage.EnterFirstName("Harry");
            addEmployeePage.EnterMiddleName("James");
            addEmployeePage.EnterLastName("Potter");
            addEmployeePage.EnterEmployeeId("5555");
            var employeePersonalDetailsPage = addEmployeePage.ClickSaveEmployeeButton();
            employeePersonalDetailsPage.VerifyEmployeeName("Harry Potter");
        }

        [Test]
        public void SearchEmployee()
        {
            employeeListPage.EnterEmployeeId("00392");
            employeeListPage.ClickSearchButton();
            ClassicAssert.Contains("00392", employeeListPage.GetCurrentPageTableIds());
            employeeListPage.EnterEmployeeId("55555");
            employeeListPage.ClickSearchButton();
            commonTableElements.VerifyTableRecordsFoundLabel("No Records Found");
            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
        }

        [Test]
        public void EditEmployeeDetails()
        {
            employeeListPage.TypeToEmployeeNameForHint("timo");
            fieldOptionsDropdown.SelectSpecificOption("Timothy Lewis Amiano");
            employeeListPage.ClickSearchButton();
            var employeePersonalDetailsPage = employeeListPage.ClickEditButtonForFirstTableRecord();
            employeePersonalDetailsPage.EnterOtherId("1111"); 
            employeePersonalDetailsPage.ClickSavePersonalDetailsButton();
            RefreshPage();
            employeePersonalDetailsPage.VerifyEmployeeOtherId("1111");
            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
        }

        [Test]
        public void DeleteEmployee()
        {
            employeeListPage.EnterEmployeeId("5555");
            employeeListPage.ClickSearchButton();
            employeeListPage.ClickDeleteButtonForFirstTableRecord();
            confirmationPopups.ClickConfirmButton();
            employeeListPage.EnterEmployeeId("5555");
            employeeListPage.ClickSearchButton();
            commonTableElements.VerifyTableRecordsFoundLabel("No Records Found");
            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
        }

        [Test]
        public void ValidateAddCustomFieldsToEmployeeProfile()
        {
            employeeListPage.ClickTopbarConfigurationButton();
            var customFieldsPage = employeeListPage.ClickCustomFieldsOption();
            var addCustomFieldsPage = customFieldsPage.ClickAddButton();
            addCustomFieldsPage.EnterFieldName("May test1");
            addCustomFieldsPage.ClickScreenDropdown();
            fieldOptionsDropdown.SelectSpecificOption("Personal Details");
            addCustomFieldsPage.ClickTypeDropdown();
            fieldOptionsDropdown.SelectSpecificOption("Text or Number");
            addCustomFieldsPage.ClickSaveButton();
            leftSideMenuBar.ClickPimOption();
            var employeePersonalDetailsPage = employeeListPage.ClickEditButtonForFirstTableRecord();
            ClassicAssert.Contains("May test1", employeePersonalDetailsPage.GetCustomFieldsLabels());
            employeePersonalDetailsPage.FindAndFillCustomFieldByLabel("May test1", "Test");
            employeePersonalDetailsPage.ClickSaveCustomFieldsButton();
            RefreshPage();
            employeePersonalDetailsPage.VerifyTextInCustomFieldByLabel("May test1", "Test");
        }

        [Test]
        public void ValidateAssignSkillToEmployeeProfile()
        {
            employeeListPage.EnterEmployeeId("01715");
            employeeListPage.ClickSearchButton();
            var employeePersonalDetailsPage = employeeListPage.ClickEditButtonForFirstTableRecord();
            var employeeQualificationsPage = employeePersonalDetailsPage.ClickQualificationsButton();
            employeeQualificationsPage.ClickSkillsAddButton();
            employeeQualificationsPage.ClickSkillsDropdown();
            fieldOptionsDropdown.SelectSpecificOption("Copywriting");
            employeeQualificationsPage.EnterSkillsYearsOfExperience("5");
            employeeQualificationsPage.ClickSkillsSaveButton();
            ClassicAssert.Contains("Copywriting", employeeQualificationsPage.GetTableSkillsNames());
            ClassicAssert.AreEqual("5", employeeQualificationsPage.FindYearsOfExperienceForSpecificSkill("Copywriting"));           
        }
    }
}
