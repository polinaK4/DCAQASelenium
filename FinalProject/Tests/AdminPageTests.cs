using FinalProject.Pages.Admin;
using FinalProject.Pages.LoginPage;
using FinalProject.Pages.General;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using FinalProject.Pages.CommonElements;

namespace FinalProject.Tests
{
    public class AdminPageTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private AdminDefault_UserManagementPage adminUserManagementPage;
        private ConfirmationPopups confirmationPopups;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            adminUserManagementPage = new AdminDefault_UserManagementPage(driver);
            confirmationPopups = new ConfirmationPopups(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            leftSideMenuBar.ClickAdminOption();
        }

        [Test]
        public void ValidateAdminFunction()
        {
            ClassicAssert.AreEqual("User Management", adminUserManagementPage.GetFirstTabOptionText());
            adminUserManagementPage.ClickJobOption();
            ClassicAssert.Contains("Job Titles", adminUserManagementPage.GetJobDropdownOptionsTexts()); // нужно стабилизировать (wait)
        }

        [Test]
        public void EditNationality()
        {
            adminUserManagementPage.ClickMoreOption();
            var nationalitiesPage = adminUserManagementPage.ClickNationalitiesOption();
            var editNationalityPage = nationalitiesPage.ClickEditFirstNationalityButton();
            editNationalityPage.EnterTextToNameField("Afghan 1");
            editNationalityPage.ClickSaveButton();
            ClassicAssert.AreEqual("Afghan 1", nationalitiesPage.GetFirstNationalityName());
        }

        [Test]
        public void AddJobTitle()
        {
            adminUserManagementPage.ClickJobOption();
            var jobTitlesPage = adminUserManagementPage.ClickJobTitlesOption();
            var addJobTitlePage = jobTitlesPage.ClickJobTitlesOption();
            addJobTitlePage.EnterJobTitle("Aut Title");
            addJobTitlePage.ClickSaveButton();
            ClassicAssert.Contains("Aut Title", jobTitlesPage.GetCurrentPageJobTitlesList());//стабилизировать
        }

        [Test]
        public void SearchAdmin()
        {
            adminUserManagementPage.EnterUsername("test123 poli");
            adminUserManagementPage.ClickSearchButton();
            var editUserPage = adminUserManagementPage.ClickEditButtonForFirstResult();
            ClassicAssert.AreEqual("Admin", editUserPage.GetUserRoleValue());
            ClassicAssert.AreEqual("Charles  Carter", editUserPage.GetEmployeeNameValue());
            ClassicAssert.AreEqual("Enabled", editUserPage.GetStatusValue());
            ClassicAssert.AreEqual("test123 poli", editUserPage.GetUsernameValue());
        }

        [Test]
        public void ValidateJobTitlesManagementFunctionality()
        {
            adminUserManagementPage.ClickJobOption(); //вынксти Job Titles отдельно?
            var jobTitlesPage = adminUserManagementPage.ClickJobTitlesOption();
            var addJobTitlePage = jobTitlesPage.ClickJobTitlesOption();
            addJobTitlePage.EnterJobTitle("Aut2 Title");
            addJobTitlePage.ClickSaveButton();
            ClassicAssert.Contains("Aut Title", jobTitlesPage.GetCurrentPageJobTitlesList());//стабилизировать
            jobTitlesPage.ClickDeleteButtonForSpecificJobTitle("Aut2 Title");
            confirmationPopups.ClickConfirmDeleteButton();
            ClassicAssert.That(jobTitlesPage.GetCurrentPageJobTitlesList(), Does.Not.Contain("Aut2 Title"));
        }
    }
}
