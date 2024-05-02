using FinalProject.Helpers;
using FinalProject.Pages.PIM.Configuration;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.PIM
{
    public class PimEmployeeListPage : BasePage
    {
        private ButtonElement topbarConfigurationOption => new ButtonElement(By.XPath("//*[@class='oxd-topbar-body-nav']//li[1]"));
        private ButtonElement topbarConfigurationCustomFieldsOption => new ButtonElement(By.XPath("//*[@class='oxd-topbar-body-nav']//li[1]/ul/li[2]"));        
        private ButtonElement topbarAddEmployeeOption => new ButtonElement(By.XPath("//*[@class='oxd-topbar-body-nav']//li[3]"));
        private TextboxElement employeeNameInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[1]//input"));
        private TextboxElement employeeIdInputField => new TextboxElement(By.XPath("//*[@class='oxd-form']/div[1]/div/div[2]//input"));
        private ButtonElement searchButton => new ButtonElement(By.XPath("//button[@type='submit']"));
        //private PoliWebElement recordsFoundText => new PoliWebElement(By.XPath("//*[@class='orangehrm-paper-container']/div[2]/div/span"));        
        private List<PoliWebElement> searchResultsIds => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='oxd-table-body']//*[@role='cell'][2]/div"), 10, 1);
        private List<PoliWebElement> searchResultsEditButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='orangehrm-paper-container']/div[3]/div/div[2]/div//button[2]"), 10, 1);
        private List<PoliWebElement> searchResultsDeleteButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='orangehrm-paper-container']/div[3]/div/div[2]/div//button[1]"), 10, 1);

        public PimEmployeeListPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickTopbarConfigurationOption() => topbarConfigurationOption.ClickWhenReady();

        public PimAddEmployee CliclAddEmployeeTab()
        {
            topbarAddEmployeeOption.ClickWhenReady();
            return new PimAddEmployee(driver);
        }

        public CustomFieldsPage CliclTopbarCustomFieldsOption()
        {
            topbarConfigurationCustomFieldsOption.ClickWhenReady();
            return new CustomFieldsPage(driver);
        }

        public void TypeToEmployeeNameForHint(string keyword) => employeeNameInputField.EnterText(keyword);

        public void EnterEmployeeId(string id) => employeeIdInputField.EnterText(id);

        public void ClickSearchButton() => searchButton.ClickWhenReady();

        public List<String> SearchResultsIdsList() => searchResultsIds.Select(title => title.Text).ToList();

        //public void VerifyRecordsFoundText(string expectedText) => WaitForExpectedText(recordsFoundText, expectedText);

        public PimEmployeeListPersonalDetails ClickEditButtonForFirstResult()
        {
            searchResultsEditButtons[0].Click();
            return new PimEmployeeListPersonalDetails(driver);
        }

        public void ClickDeleteButtonForFirstResult() => searchResultsDeleteButtons[0].Click();
    }
}
