using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Vacancies
{
    public class AddVacancyPage : BasePage
    {
        private TextboxElement _vacancyNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']//div[contains(@class,'oxd-grid-3')][1]//input"));
        private DropdownElement _jobTitleDropdown => new DropdownElement(By.XPath("//*[@class='oxd-form']//div[contains(@class,'oxd-grid-3')][1]//*[@class='oxd-select-text-input']"));
        private TextboxElement _hiringManagerInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']//div[contains(@class,'oxd-grid-3')][3]/div[contains(@class,'oxd-grid-item')][1]//input"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private PoliWebElement _vacanciesFormHeader => new PoliWebElement(By.XPath("//*[@class='orangehrm-card-container']/h6"));
        private PoliWebElement _attachmentsForm => new PoliWebElement(By.XPath("//*[@class='orangehrm-paper-container']"));

        public AddVacancyPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterVacancyName(string keyword) => _vacancyNameInputField.EnterText(keyword);

        public void ClickJobTitleDropdown() => _jobTitleDropdown.Click();

        public void SelectSpecificDropdownOption(string expectedText) => _jobTitleDropdown.ClickSpecificOption(expectedText);

        public void TypeToVacancyNameForHint(string keyword) => _hiringManagerInputField.EnterText(keyword);

        public void ClickSaveButton() => _saveButton.ClickWhenReady();

        public void VerifyVacanciesFormHeader(string expectedText) => WaitForExpectedText(_vacanciesFormHeader, expectedText);

        public bool IsAttachmentsFormDisplayed() => _attachmentsForm.Displayed;
    }
}

