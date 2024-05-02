using FinalProject.Pages.Recruitment.Vacancies;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Candidates
{
    public class AddCandidatePage : BasePage
    {
        private TextboxElement firstNameInputField => new TextboxElement(By.XPath("//*[@class='--name-grouped-field']/div[1]//input")); //вероятно эти три похожие еще где-то
        private TextboxElement middleNameInputField => new TextboxElement(By.XPath("//*[@class='--name-grouped-field']/div[2]//input"));
        private TextboxElement lastNameInputField => new TextboxElement(By.XPath("//*[@class='--name-grouped-field']/div[3]//input"));
        private TextboxElement emailInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[3]/div/div[1]//input"));
        private ButtonElement saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private ButtonElement candidatesPageButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[1]/a"));

        public AddCandidatePage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFirstName(string keyword) => firstNameInputField.EnterText(keyword);

        public void EnterMiddleName(string keyword) => middleNameInputField.EnterText(keyword);

        public void EnterLastName(string keyword) => lastNameInputField.EnterText(keyword);

        public void EnterEmail(string keyword) => emailInputField.EnterText(keyword);

        public void ClickSaveButton() => saveButton.ClickWhenReady();

        public RecruitmentCandidatesPage ClickVacanciesPageButton()
        {
            candidatesPageButton.ClickWhenReady();
            return new RecruitmentCandidatesPage(driver);
        }
    }
}
