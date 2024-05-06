using FinalProject.Helpers;
using FinalProject.Pages.Recruitment.Vacancies;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Candidates
{
    public class RecruitmentCandidatesPage : BasePage
    {
        private ButtonElement _topbarVacanciesPageButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[2]/a"));
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));
        private TextboxElement _candidateNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[2]//input[@placeholder='Type for hints...']"));
        private ButtonElement _searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private List<PoliWebElement> _tableCurrentPageCheckboxes => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div/div[1]/div//i"), 10, 1);
        private List<PoliWebElement> _tableSelectedPageCandidatesNames => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div/div[3]/div"), 10, 1);       

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

        public List<string> GetCandidatesNames() => _tableSelectedPageCandidatesNames.Select(option => option.Text).ToList();

        public void SelectCheckboxForSpecificCandidate(string expectedText)
        {
            int i = _tableSelectedPageCandidatesNames.FindIndex(v => v.Text == expectedText);
            _tableCurrentPageCheckboxes[i].Click();
        }

    }
}
