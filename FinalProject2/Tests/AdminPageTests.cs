﻿using FinalProject.Pages.Admin;
using FinalProject.Pages.Login;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Drawing;
using FinalProject.Pages.Modules;

namespace FinalProject.Tests
{
    public class AdminPageTests : BaseTest
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
        public void ValidateAdminFunction()
        {
            var leftSideMenuBar = new LeftSideMenuBar(driver);
            var adminUserManagementPage = leftSideMenuBar.ClickAdminOption();
            ClassicAssert.AreEqual("User Management", adminUserManagementPage.GetFirstTabOptionText());
            adminUserManagementPage.ClickJobOption();
            ClassicAssert.Contains("Job Titles", adminUserManagementPage.GetJobDropdownOptionsTexts());
        }

        [Test]
        public void EditNationality()
        {
            var leftSideMenuBar = new LeftSideMenuBar(driver);
            var adminUserManagementPage = leftSideMenuBar.ClickAdminOption();
            adminUserManagementPage.ClickMoreOption();
            var nationalitiesPage = adminUserManagementPage.ClickNationalitiesOption();
            nationalitiesPage.VerifyVacanciesFormHeader("Nationalities");
            var editNationalityPage = nationalitiesPage.ClickEditButtonForSpecificNationality("Albanian");
            editNationalityPage.EnterTextToNameField("Albanian 1");
            editNationalityPage.ClickSaveButton();
            ClassicAssert.Contains("Albanian 1", nationalitiesPage.grid.GetValuesOfSpecificColumn("Nationality"));
        }

        [Test]
        public void AddJobTitle()
        {
            var leftSideMenuBar = new LeftSideMenuBar(driver);
            var adminUserManagementPage = leftSideMenuBar.ClickAdminOption();
            adminUserManagementPage.ClickJobOption();
            var jobTitlesPage = adminUserManagementPage.ClickJobTitlesOption();
            var addJobTitlePage = jobTitlesPage.ClickJobTitlesOption();
            addJobTitlePage.EnterJobTitle("Aut Title");
            addJobTitlePage.ClickSaveButton();
            ClassicAssert.Contains("Aut Title", jobTitlesPage.grid.GetValuesOfSpecificColumn("Job Titles"));
        }

        [Test]
        public void SearchAdmin()
        {
            var leftSideMenuBar = new LeftSideMenuBar(driver);
            var adminUserManagementPage = leftSideMenuBar.ClickAdminOption();
            adminUserManagementPage.EnterUsername("FMLName1");
            adminUserManagementPage.ClickSearchButton();
            var editUserPage = adminUserManagementPage.ClickEditButtonForSpecificUser("FMLName1");
            ClassicAssert.AreEqual("ESS", editUserPage.GetUserRoleValue());
            ClassicAssert.AreEqual("FName Mname LName", editUserPage.GetEmployeeNameValue());
            ClassicAssert.AreEqual("Enabled", editUserPage.GetStatusValue());
            ClassicAssert.AreEqual("FMLName1", editUserPage.GetUsernameValue());
        }

        [Test]
        public void ValidateJobTitlesManagementFunctionality()
        {
            var leftSideMenuBar = new LeftSideMenuBar(driver);
            var adminUserManagementPage = leftSideMenuBar.ClickAdminOption();
            adminUserManagementPage.ClickJobOption();
            var jobTitlesPage = adminUserManagementPage.ClickJobTitlesOption();
            var addJobTitlePage = jobTitlesPage.ClickJobTitlesOption();
            addJobTitlePage.EnterJobTitle("Aut2 Title");
            addJobTitlePage.ClickSaveButton();
            ClassicAssert.Contains("Aut2 Title", jobTitlesPage.grid.GetValuesOfSpecificColumn("Job Titles"));
            var confirmationPopup = jobTitlesPage.grid.ClickDeleteButtonForSpecificRecord("Aut2 Title");
            confirmationPopup.ClickConfirmButton();
            ClassicAssert.That(jobTitlesPage.grid.GetValuesOfSpecificColumn("Job Titles"), Does.Not.Contain("Aut2 Title"));
        }
    }
}
