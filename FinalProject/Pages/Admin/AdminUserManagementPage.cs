using FinalProject.Helpers;
using FinalProject.Pages.Admin.Job;
using FinalProject.Pages.Modules.Grid;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class AdminUserManagementPage : BasePage
    {
        public Grid grid => new Grid(driver);
        private ButtonElement _topbarUserMngmtButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//span[.= 'User Management ']"));
        private ButtonElement _topbarJobButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//span[.= 'Job ']"));
        private List<PoliWebElement> _jobDropdownOptions => driver.GetPoliWebElementList(By.XPath("//*[@aria-label='Topbar Menu']//span[.= 'Job ']/following-sibling::ul/li"), 1);      
        private ButtonElement _topbarMoreButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//span[.= 'More ']"));
        private ButtonElement _moreDropdownNationalitiesOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//a[.= 'Nationalities ']"));
        private TextboxElement _usernameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/descendant::input[1]"));
        private ButtonElement _searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));

        public AdminUserManagementPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetFirstTabOptionText() => _topbarUserMngmtButton.Text;

        public void ClickJobOption() => _topbarJobButton.ClickWhenReady();

        public JobTitlesPage ClickJobTitlesOption()
        {
            _jobDropdownOptions[0].Click();
            return new JobTitlesPage(driver);
        }

        public List<String> GetJobDropdownOptionsTexts() => _jobDropdownOptions.Select(option => option.Text).ToList();

        public void ClickMoreOption() => _topbarMoreButton.ClickWhenReady();

        public NationalitiesPage ClickNationalitiesOption()
        {
            _moreDropdownNationalitiesOption.Click();
            return new NationalitiesPage(driver);
        }

        public void EnterUsername(string username) => _usernameInputField.EnterText(username);

        public void ClickSearchButton() => _searchButton.ClickWhenReady();

        public AdminEditUserPage ClickEditButtonForSpecificUser(string rowValue)
        {
            grid.ClickEditButtonForSpecificRecord(rowValue);
            return new AdminEditUserPage(driver);
        }
    }
}
