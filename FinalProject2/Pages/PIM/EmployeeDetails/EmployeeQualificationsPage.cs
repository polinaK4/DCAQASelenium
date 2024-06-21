using FinalProject.Helpers;
using FinalProject.Pages.Modules.Grid;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM.EmployeeDetails
{
    public class EmployeeQualificationsPage : BasePage
    {
        private ButtonElement _skillsAddButton => new ButtonElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/descendant::div[@class='orangehrm-action-header'][3]//button"));
        private DropdownElement _skillsDropdown => new DropdownElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/descendant::div[contains(@class, 'orangehrm-horizontal')][6]//div[@class='oxd-select-text-input']"));
        private TextboxElement _skillsYearsOfExperienceInputField => new TextboxElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/descendant::div[contains(@class, 'orangehrm-horizontal')][6]//input"));
        private ButtonElement _skillsSaveButton => new ButtonElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/descendant::div[contains(@class, 'orangehrm-horizontal')][6]//button[@type='submit']"));
        
        public EmployeeQualificationsPage(IWebDriver driver) : base(driver)
        {

        }

        public Grid GetGrid(string gridLocatorname) => new Grid(driver, gridLocatorname);

        public void ClickSkillsAddButton() => _skillsAddButton.ClickWhenReady();

        public void ClickSkillsDropdown() => _skillsDropdown.Click();

        public void SelectSpecificDropdownOption(string expectedText) => _skillsDropdown.ClickSpecificOption(expectedText);

        public void EnterSkillsYearsOfExperience(string text) => _skillsYearsOfExperienceInputField.EnterText(text);

        public void ClickSkillsSaveButton() => _skillsSaveButton.ClickWhenReady();

    }
}
