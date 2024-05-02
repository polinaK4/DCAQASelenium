using FinalProject.Helpers;
using FinalProject.Pages.Admin.Job;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class AdminDefault_UserManagementPage : BasePage
    {
        private ButtonElement userMngmtOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[1]/span"));
        //private ButtonElement usersOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[1]/ul/li"));
        private ButtonElement jobOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[2]/span"));
        private List<PoliWebElement> jobDropdownOptions => driver.GetPoliWebElementList(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[2]/ul/li"));
        //private ButtonElement jobTitlesOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[2]/ul/li[1]"));        
        private ButtonElement fifthTabOptionMore => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[5]/span"));
        private ButtonElement moreDropdownNationalitiesOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']/ul/li[5]/ul/div[1]"));
        private TextboxElement usernameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[1]//input"));
        private ButtonElement searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        private List<PoliWebElement> searchResultsEditButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='orangehrm-paper-container']/div[3]/div/div[2]/div//button[2]"), 10, 1);

        public AdminDefault_UserManagementPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetFirstTabOptionText() => userMngmtOption.Text;

        public void ClickJobOption() => jobOption.ClickWhenReady();

        public JobTitlesPage ClickJobTitlesOption()
        {
            jobDropdownOptions[0].Click();
            return new JobTitlesPage(driver);
        }

        public List<String> GetJobDropdownOptionsTexts() => jobDropdownOptions.Select(option => option.Text).ToList();

        public void ClickMoreOption() => fifthTabOptionMore.ClickWhenReady();

        public NationalitiesPage ClickNationalitiesOption()
        {
            moreDropdownNationalitiesOption.Click();
            return new NationalitiesPage(driver);
        }

        public void EnterUsername(string username) => usernameInputField.EnterText(username);

        public void ClickSearchButton() => searchButton.ClickWhenReady();

        public AdminEditUserPage ClickEditButtonForFirstResult()
        {
            searchResultsEditButtons[0].Click();
            return new AdminEditUserPage(driver);
        }
    }
}
