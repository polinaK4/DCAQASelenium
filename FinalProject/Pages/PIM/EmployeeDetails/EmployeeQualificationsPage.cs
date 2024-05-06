using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM.EmployeeDetails
{
    public class EmployeeQualificationsPage : BasePage
    {
        private ButtonElement _skillsAddButton => new ButtonElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/div[4]//button"));
        private PoliWebElement _skillsDropdown => new PoliWebElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/div[4]//div[@class='oxd-select-wrapper']/div"));
        private TextboxElement _skillsYearsOfExperienceInputField => new TextboxElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/div[4]//form/div[1]//input"));
        private ButtonElement _skillsSaveButton => new ButtonElement(By.XPath("//*[@class='orangehrm-edit-employee-content']/div[4]//button[@type='submit']"));
        private List<PoliWebElement> _skillsTableSkillNames => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='orangehrm-edit-employee-content']/div[4]//div[@role='table']/div[2]//div[@role='row']/div[2]/div"), 10, 1);
        private List<PoliWebElement> _skillsTableYearsExperience => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='orangehrm-edit-employee-content']/div[4]//div[@role='table']/div[2]//div[@role='row']/div[3]/div"), 10, 1);

        public EmployeeQualificationsPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickSkillsAddButton() => _skillsAddButton.ClickWhenReady();

        public void ClickSkillsDropdown() => _skillsDropdown.Click();

        public void EnterSkillsYearsOfExperience(string text) => _skillsYearsOfExperienceInputField.EnterText(text);

        public void ClickSkillsSaveButton() => _skillsSaveButton.ClickWhenReady();

        public List<string> GetTableSkillsNames() => _skillsTableSkillNames.Select(title => title.Text).ToList();

        public string FindYearsOfExperienceForSpecificSkill(string skillName)
        {
            int i = _skillsTableSkillNames.FindIndex(v => v.Text == skillName);
            return _skillsTableYearsExperience[i].Text;
        }
    }
}
