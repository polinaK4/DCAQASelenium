using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Vacancies
{
    public class AddVacancyPage : BasePage
    {
        private TextboxElement vacancyNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]//input"));
        private PoliWebElement jobTitleDropdown => new PoliWebElement(By.XPath("//*[@class='oxd-select-wrapper']"));
        private ButtonElement autoTesterJobOption => new ButtonElement(By.XPath("//*[@role='listbox']/div[3]/span"));
        private TextboxElement hiringManagerInputField => new TextboxElement(By.XPath("//*[@class='oxd-autocomplete-wrapper']/div/input"));
        private ButtonElement saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private PoliWebElement vacanciesFormHeader => new PoliWebElement(By.XPath("//*[@class='orangehrm-card-container']/h6"));
        private PoliWebElement attachmentsForm => new PoliWebElement(By.XPath("//*[@class='orangehrm-paper-container']"));

        public AddVacancyPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterVacancyName(string keyword) => vacancyNameInputField.EnterText(keyword);

        public void ClickJobTitleDropdown() => jobTitleDropdown.Click();

        public void SelectJobAutoTester() => autoTesterJobOption.Click();

        public void TypeToVacancyNameForHint(string keyword) => hiringManagerInputField.EnterText(keyword);

        public void ClickSaveButton() => saveButton.ClickWhenReady();

        public void VerifyVacanciesFormHeader(string expectedText) => WaitForExpectedText(vacanciesFormHeader, expectedText);

        public bool IsAttachmentsFormDisplayed() => attachmentsForm.Displayed;
    }
}

