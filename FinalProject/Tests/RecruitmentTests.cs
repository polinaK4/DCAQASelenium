using FinalProject.Pages.LoginPage;
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
        private FieldOptionsDropdown commonElements;
        private RecruitmentCandidatesPage recruitmentCandidatesPage;
        private ConfirmationPopups confirmationPopups;
        private CommonTableElements commonTableElements;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            recruitmentCandidatesPage = new RecruitmentCandidatesPage(driver);
            confirmationPopups = new ConfirmationPopups(driver);
            commonTableElements = new CommonTableElements(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            leftSideMenuBar.ClickRecruitmentOption();
        }

        [Test]
        public void ValidateRecruitmentManagementFunctionality()
        {
            var recruitmentVacansiesPage = recruitmentCandidatesPage.ClickVacanciesPageButton();
            var addVacancyPage = recruitmentVacansiesPage.ClickAddButton();
            addVacancyPage.EnterVacancyName("Auto test vacancy");
            addVacancyPage.ClickJobTitleDropdown();
            addVacancyPage.SelectJobAutoTester();
            addVacancyPage.TypeToVacancyNameForHint("Peter");
            commonElements.SelectSpecificOption("Peter Mac Anderson");
            addVacancyPage.ClickSaveButton();
            addVacancyPage.VerifyVacanciesFormHeader("Edit Vacancy");
            ClassicAssert.AreEqual(true, addVacancyPage.IsAttachmentsFormDisplayed());
            recruitmentCandidatesPage.ClickVacanciesPageButton();
            ClassicAssert.Contains("Auto test vacancy", recruitmentVacansiesPage.VacanciesTitlesText());
            recruitmentVacansiesPage.ClickDeleteButtonForSpecificVacancy("Auto test vacancy");
            confirmationPopups.ClickConfirmDeleteButton();
            ClassicAssert.That(recruitmentVacansiesPage.VacanciesTitlesText(), Does.Not.Contain("Auto test vacancy"));
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
            commonElements.SelectSpecificOption("Politest Middle Last");
            recruitmentCandidatesPage.ClickSearchButton();
            ClassicAssert.AreEqual("Politest Middle Last", recruitmentCandidatesPage.GetFirstResultcandidateName());
            recruitmentCandidatesPage.ClickDeleteFirstCandidateButton();
            confirmationPopups.ClickConfirmDeleteButton();
            ClassicAssert.AreEqual("No Records Found", commonTableElements.GetTableLabel());
        }
    }
}
