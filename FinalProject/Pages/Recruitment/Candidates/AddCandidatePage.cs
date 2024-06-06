using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Candidates
{
    public class AddCandidatePage : BasePage
    {
        private TextboxElement _firstNameInputField => new TextboxElement(By.XPath("//*[@name='firstName']"));
        private TextboxElement _middleNameInputField => new TextboxElement(By.XPath("//*[@name='middleName']"));
        private TextboxElement _lastNameInputField => new TextboxElement(By.XPath("//*[@name='lastName']"));
        private TextboxElement _emailInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/*[@class='oxd-form-row'][3]//div[contains(@class, 'oxd-grid-item')][1]//input"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private ButtonElement _topbarCandidatesButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//a[.= 'Candidates']"));

        public AddCandidatePage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFirstName(string keyword) => _firstNameInputField.EnterText(keyword);

        public void EnterMiddleName(string keyword) => _middleNameInputField.EnterText(keyword);

        public void EnterLastName(string keyword) => _lastNameInputField.EnterText(keyword);

        public void EnterEmail(string keyword) => _emailInputField.EnterText(keyword);

        public void ClickSaveButton() => _saveButton.ClickWhenReady();

        public RecruitmentCandidatesPage ClickCandidatesPageButton()
        {
            _topbarCandidatesButton.ClickWhenReady();
            return new RecruitmentCandidatesPage(driver);
        }
    }
}
