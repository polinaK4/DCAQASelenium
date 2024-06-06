using FinalProject.Helpers;
using FinalProject.Pages.Modules.Grid;
using FinalProject.Pages.Recruitment.Vacancies;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Candidates
{
    public class RecruitmentCandidatesPage : BasePage
    {
        public Grid grid => new Grid(driver);
        private ButtonElement _topbarVacanciesPageButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//a[.= 'Vacancies']"));
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));
        private TextboxWithHintElement _candidateNameInputField => new TextboxWithHintElement(By.XPath("//*[@class='oxd-form']/*[@class='oxd-form-row'][2]//div[contains(@class, 'oxd-grid-item')][1]//input"));
        private ButtonElement _searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));

        public RecruitmentCandidatesPage(IWebDriver driver) : base(driver)
        {

        }

        public RecruimentVacanciesPage ClickVacanciesPageButton()
        {
            _topbarVacanciesPageButton.ClickWhenReady();
            return new RecruimentVacanciesPage(driver);
        }

        public AddCandidatePage ClickAddCandidateButton()
        {
            _addButton.ClickWhenReady();
            return new AddCandidatePage(driver);
        }

        public void EnterCandidateName(string keyword) => _candidateNameInputField.EnterText(keyword);

        public void ClickSearchButton() => _searchButton.ClickWhenReady();

        public void SelectSpecificDropdownOption(string expectedText) => _candidateNameInputField.ClickSpecificOption(expectedText);

    }
}
