using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin.Job
{
    public class AddJobTitlePage : BasePage
    {
        private TextboxElement _jobTitleInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/*[@class='oxd-form-row'][1]//input"));
        private ButtonElement _saveButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        
        public AddJobTitlePage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterJobTitle(string title) => _jobTitleInputField.EnterText(title);

        public JobTitlesPage ClickSaveButton()
        {
            _saveButton.ClickWhenReady();
            return new JobTitlesPage(driver);
        }
    }
}
