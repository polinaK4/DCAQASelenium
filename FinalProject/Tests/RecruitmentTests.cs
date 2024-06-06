using FinalProject.Pages.Login;
using FinalProject.Pages.Recruitment.Candidates;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using FinalProject.Pages.Modules;

namespace FinalProject.Tests
{
    public class RecruitmentTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private RecruitmentCandidatesPage recruitmentCandidatesPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            recruitmentCandidatesPage = new RecruitmentCandidatesPage(driver);
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
            addVacancyPage.SelectSpecificDropdownOption("Chief Executive Officer");
            addVacancyPage.TypeToVacancyNameForHint("Timothy");
            addVacancyPage.SelectSpecificDropdownOption("Timothy Lewis Amiano");
            addVacancyPage.ClickSaveButton();
            addVacancyPage.VerifyVacanciesFormHeader("Edit Vacancy");
            ClassicAssert.AreEqual(true, addVacancyPage.IsAttachmentsFormDisplayed());
            recruitmentCandidatesPage.ClickVacanciesPageButton();
            ClassicAssert.Contains("Auto test vacancy", recruitmentVacansiesPage.grid.GetValuesOfSpecificColumn("Vacancy"));
            var confirmationPopup = recruitmentVacansiesPage.grid.ClickDeleteButtonForSpecificRecord("Auto test vacancy");
            confirmationPopup.ClickConfirmButton();
            ClassicAssert.That(recruitmentVacansiesPage.grid.GetValuesOfSpecificColumn("Vacancy"), Does.Not.Contain("Auto test vacancy"));
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
            addCandidatePage.ClickCandidatesPageButton();
            recruitmentCandidatesPage.EnterCandidateName("Politest");
            recruitmentCandidatesPage.SelectSpecificDropdownOption("Politest Middle Last");
            recruitmentCandidatesPage.ClickSearchButton();
            ClassicAssert.Contains("Politest Middle Last", recruitmentCandidatesPage.grid.GetValuesOfSpecificColumn("Candidate"));
            recruitmentCandidatesPage.grid.ClickCheckboxForSpecificRow("Politest Middle Last");
            var confirmationPopup = recruitmentCandidatesPage.grid.ClickDeleteSelectedButton();
            confirmationPopup.ClickConfirmButton();
            ClassicAssert.AreEqual("No Records Found", recruitmentCandidatesPage.grid.GetGridLabel());
        }
    }
}
