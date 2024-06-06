using FinalProject.Pages.Login;
using FinalProject.Pages.PIM;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Drawing;
using FinalProject.Pages.Modules;

namespace FinalProject.Tests
{
    public class PIMTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private EmployeeListPage employeeListPage;
        private Header header;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Size = new Size(1024, 768);
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            employeeListPage = new EmployeeListPage(driver);
            header = new Header(driver);
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
            ClassicAssert.Contains("00392", employeeListPage.grid.GetValuesOfSpecificColumn("Id"));
            employeeListPage.EnterEmployeeId("55555");
            employeeListPage.ClickSearchButton();
            ClassicAssert.AreEqual("No Records Found", employeeListPage.grid.GetGridLabel());
            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
        }

        [Test]
        public void EditEmployeeDetails()
        {
            employeeListPage.TypeToEmployeeNameForHint("timo");
            employeeListPage.SelectSpecificDropdownOption("Timothy Lewis Amiano");
            employeeListPage.ClickSearchButton();
            var employeePersonalDetailsPage = employeeListPage.ClickEditButtonForSpecificEmployee("Timothy Lewis");
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
            var confirmationPopup = employeeListPage.grid.ClickDeleteButtonForSpecificRecord("5555");
            confirmationPopup.ClickConfirmButton();
            employeeListPage.EnterEmployeeId("5555");
            employeeListPage.ClickSearchButton();
            ClassicAssert.AreEqual("No Records Found", employeeListPage.grid.GetGridLabel());
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
            addCustomFieldsPage.SelectSpecificDropdownOption("Personal Details");
            addCustomFieldsPage.ClickTypeDropdown();
            addCustomFieldsPage.SelectSpecificDropdownOption("Text or Number");
            addCustomFieldsPage.ClickSaveButton();
            leftSideMenuBar.ClickPimOption();
            var employeePersonalDetailsPage = employeeListPage.ClickEditButtonForSpecificEmployee("Amelia");
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
            var employeePersonalDetailsPage = employeeListPage.ClickEditButtonForSpecificEmployee("01715");
            var employeeQualificationsPage = employeePersonalDetailsPage.ClickQualificationsButton();
            employeeQualificationsPage.ClickSkillsAddButton();
            employeeQualificationsPage.ClickSkillsDropdown();
            employeeQualificationsPage.SelectSpecificDropdownOption("Copywriting");
            employeeQualificationsPage.EnterSkillsYearsOfExperience("5");
            employeeQualificationsPage.ClickSkillsSaveButton();
            var grid = employeeQualificationsPage.GetGrid("Skills");
            ClassicAssert.Contains("Copywriting", grid.GetValuesOfSpecificColumn("Skill"));
            ClassicAssert.AreEqual("5", grid.GetCellValueByOtherRowValue("Years of Experience", "Copywriting"));
        }
    }
}
