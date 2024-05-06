using FinalProject.Pages.Admin;
using FinalProject.Pages.Login;
using FinalProject.Pages.General;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using FinalProject.Pages.CommonElements;
using System.Drawing;

namespace FinalProject.Tests
{
    public class AdminPageTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private AdminUserManagementPage adminUserManagementPage;
        private ConfirmationPopup confirmationPopups;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Size = new Size(1024, 768);
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            adminUserManagementPage = new AdminUserManagementPage(driver);
            confirmationPopups = new ConfirmationPopup(driver);
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
            ClassicAssert.Contains("Job Titles", adminUserManagementPage.GetJobDropdownOptionsTexts());
        }

        [Test]
        public void EditNationality()
        {
            adminUserManagementPage.ClickMoreOption();
            var nationalitiesPage = adminUserManagementPage.ClickNationalitiesOption();
            nationalitiesPage.VerifyVacanciesFormHeader("Nationalities");
            var editNationalityPage = nationalitiesPage.ClickEditButtonForSpecificNationality("Dominican");
            editNationalityPage.EnterTextToNameField("Dominican 1");
            editNationalityPage.ClickSaveButton();
            ClassicAssert.Contains("Dominican 1", nationalitiesPage.GetTableCurrentPageNationalityTitles());
        }

        [Test]
        public void AddJobTitle()
        {
            adminUserManagementPage.ClickJobOption();
            var jobTitlesPage = adminUserManagementPage.ClickJobTitlesOption();
            var addJobTitlePage = jobTitlesPage.ClickJobTitlesOption();
            addJobTitlePage.EnterJobTitle("Aut Title");
            addJobTitlePage.ClickSaveButton();
            ClassicAssert.Contains("Aut Title", jobTitlesPage.GetSelectedPageJobTitles());//стабилизировать
        }

        [Test]
        public void SearchAdmin()
        {
            adminUserManagementPage.EnterUsername("FMLName");
            adminUserManagementPage.ClickSearchButton();
            var editUserPage = adminUserManagementPage.ClickEditButtonForFirstResult();
            ClassicAssert.AreEqual("ESS", editUserPage.GetUserRoleValue());
            ClassicAssert.AreEqual("Qwerty Qwerty LName", editUserPage.GetEmployeeNameValue());
            ClassicAssert.AreEqual("Enabled", editUserPage.GetStatusValue());
            ClassicAssert.AreEqual("FMLName", editUserPage.GetUsernameValue());
        }

        [Test]
        public void ValidateJobTitlesManagementFunctionality()
        {
            adminUserManagementPage.ClickJobOption();
            var jobTitlesPage = adminUserManagementPage.ClickJobTitlesOption();
            var addJobTitlePage = jobTitlesPage.ClickJobTitlesOption();
            addJobTitlePage.EnterJobTitle("Aut2 Title");
            addJobTitlePage.ClickSaveButton();
            ClassicAssert.Contains("Aut2 Title", jobTitlesPage.GetSelectedPageJobTitles());
            jobTitlesPage.ClickDeleteButtonForSpecificJobTitle("Aut2 Title");
            confirmationPopups.ClickConfirmButton();
            ClassicAssert.That(jobTitlesPage.GetSelectedPageJobTitles(), Does.Not.Contain("Aut2 Title"));
        }
    }
}
