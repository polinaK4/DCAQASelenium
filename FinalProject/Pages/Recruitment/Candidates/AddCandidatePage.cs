using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Candidates
{
    public class AddCandidatePage : BasePage
    {
        private TextboxElement _firstNameInputField => new TextboxElement(By.XPath("//*[@class='--name-grouped-field']/div[1]//input"));
        private TextboxElement _middleNameInputField => new TextboxElement(By.XPath("//*[@class='--name-grouped-field']/div[2]//input"));
        private TextboxElement _lastNameInputField => new TextboxElement(By.XPath("//*[@class='--name-grouped-field']/div[3]//input"));
        private TextboxElement _emailInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[3]/div/div[1]//input"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private ButtonElement _topbarCandidatesButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[1]/a"));

        public AddCandidatePage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFirstName(string keyword) => _firstNameInputField.EnterText(keyword);

        public void EnterMiddleName(string keyword) => _middleNameInputField.EnterText(keyword);

        public void EnterLastName(string keyword) => _lastNameInputField.EnterText(keyword);

        public void EnterEmail(string keyword) => _emailInputField.EnterText(keyword);

        public void ClickSaveButton() => _saveButton.ClickWhenReady();

        public RecruitmentCandidatesPage ClickVacanciesPageButton()
        {
            _topbarCandidatesButton.ClickWhenReady();
            return new RecruitmentCandidatesPage(driver);
        }
    }
}
