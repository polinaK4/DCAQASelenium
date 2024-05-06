using FinalProject.Pages.Login;
using FinalProject.Pages.CommonElements;
using FinalProject.Pages.General;
using FinalProject.Pages.Recruitment.Candidates;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FinalProject.Tests
{
    public class RecruitmentTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private FieldOptionsDropdown fieldOptionsDropdow;
        private RecruitmentCandidatesPage recruitmentCandidatesPage;
        private ConfirmationPopup confirmationPopups;
        private CommonTableElements commonTableElements;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            recruitmentCandidatesPage = new RecruitmentCandidatesPage(driver);
            confirmationPopups = new ConfirmationPopup(driver);
            commonTableElements = new CommonTableElements(driver);
            fieldOptionsDropdow = new FieldOptionsDropdown(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            leftSideMenuBar.ClickRecruitmentOption();
        }

        [Test]
        public void ValidateRecruitmentManagementFunctionality()
        {
            var recruitmentVacansiesPage = recruitmentCandidatesPage.ClickVacanciesPageButton();
            recruitmentVacansiesPage.VerifyVacanciesFormHeader("Vacancies");
            var addVacancyPage = recruitmentVacansiesPage.ClickAddButton();
            addVacancyPage.VerifyVacanciesFormHeader("Add Vacancy");
            addVacancyPage.EnterVacancyName("Auto test vacancy");
            addVacancyPage.ClickJobTitleDropdown();
            fieldOptionsDropdow.SelectSpecificOption("Chief Executive Officer");
            addVacancyPage.TypeToVacancyNameForHint("Timothy");
            fieldOptionsDropdow.SelectSpecificOption("Timothy Lewis Amiano");
            addVacancyPage.ClickSaveButton();
            addVacancyPage.VerifyVacanciesFormHeader("Edit Vacancy");
            ClassicAssert.AreEqual(true, addVacancyPage.IsAttachmentsFormDisplayed());
            recruitmentCandidatesPage.ClickVacanciesPageButton();
            ClassicAssert.Contains("Auto test vacancy", recruitmentVacansiesPage.GetVacanciesTitles());
            recruitmentVacansiesPage.ClickDeleteButtonForSpecificVacancy("Auto test vacancy");
            confirmationPopups.ClickConfirmButton();
            ClassicAssert.That(recruitmentVacansiesPage.GetVacanciesTitles(), Does.Not.Contain("Auto test vacancy"));
        }

        [Test]
        public void ValidateCandidateManagementInRecruitmentFunctionality()
        {
            var addCandidatePage = recruitmentCandidatesPage.ClickAddCandidateButton();
            addCandidatePage.EnterFirstName("Politest");
            addCandidatePage.EnterMiddleName("Middle");
            addCandidatePage.EnterLastName("Last");
            addCandidatePage.EnterEmail("test@mail.co");
            addCandidatePage.ClickSaveButton();
            addCandidatePage.ClickVacanciesPageButton();
            recruitmentCandidatesPage.EnterCandidateName("Politest");
            fieldOptionsDropdow.SelectSpecificOption("Politest Middle Last");
            recruitmentCandidatesPage.ClickSearchButton();
            ClassicAssert.Contains("Politest Middle Last", recruitmentCandidatesPage.GetCandidatesNames());
            recruitmentCandidatesPage.SelectCheckboxForSpecificCandidate("Politest Middle Last");
            commonTableElements.ClickDeleteSelectedButton();
            confirmationPopups.ClickConfirmButton();
            ClassicAssert.AreEqual("No Records Found", commonTableElements.GetTableLabel());
        }
    }
}
