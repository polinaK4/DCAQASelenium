using FinalProject.Helpers;
using FinalProject.Pages.Recruitment.Vacancies;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Candidates
{
    public class RecruitmentCandidatesPage : BasePage
    {
        private ButtonElement vacanciesPageButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[2]/a"));
        private ButtonElement addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));
        private TextboxElement candidateNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[2]//input[@placeholder='Type for hints...']"));
        private ButtonElement searchButton => new ButtonElement(By.XPath("//button[@type='submit']")); //отдельно?
        private List<PoliWebElement> tableCurrentPageCandidatesNames => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='oxd-table-body']/div/div/div[3]/div"), 10, 1);
        private List<PoliWebElement> candidatesDeleteButtons => driver.GetPoliWebElementList(By.XPath("//*[@class='oxd-table-cell-actions']/button[2]"));
       
        public RecruitmentCandidatesPage(IWebDriver driver) : base(driver)
        {

        }

        public RecruimentVacanciesPage ClickVacanciesPageButton()
        {
            vacanciesPageButton.ClickWhenReady();
            return new RecruimentVacanciesPage(driver);
        }

        public AddCandidatePage ClickAddCandidateButton()
        {
            addButton.ClickWhenReady();
            return new AddCandidatePage(driver);
        }

        public void EnterCandidateName(string keyword) => candidateNameInputField.EnterText(keyword);

        public void ClickSearchButton() => searchButton.ClickWhenReady();

        public string GetFirstResultcandidateName() => tableCurrentPageCandidatesNames[1].Text;

        public void ClickDeleteFirstCandidateButton() => candidatesDeleteButtons[1].Click();

    }
}
