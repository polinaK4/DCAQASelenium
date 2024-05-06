using FinalProject.Helpers;
using FinalProject.Pages.Admin.Job;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class AdminUserManagementPage : BasePage
    {
        private ButtonElement _topbarUserMngmtButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[1]/span"));
        private ButtonElement _topbarJobButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[2]/span"));
        private List<PoliWebElement> _jobDropdownOptions => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[2]/ul/li"), 10, 1);      
        private ButtonElement _topbarMoreButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[5]/span"));
        private ButtonElement _moreDropdownNationalitiesOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[5]/ul/div[1]"));
        private TextboxElement _usernameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[1]//input"));
        private ButtonElement _searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private List<PoliWebElement> _tableCurrentPageEditButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div//button[2]"), 10, 1);

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

        public AdminEditUserPage ClickEditButtonForFirstResult()
        {
            _tableCurrentPageEditButtons[0].Click();
            return new AdminEditUserPage(driver);
        }
    }
}
