using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin.Job
{
    public class JobTitlesPage : BasePage
    {
        private ButtonElement addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']//button"));
        private List<PoliWebElement> tableCurrentPageJobTitles => driver.GetPoliWebElementList(By.XPath("//*[@class='oxd-table-body']/div/div/div[2]"));
        private List<PoliWebElement> jobTitlesDeleteButtons => driver.GetPoliWebElementList(By.XPath("//*[@class='oxd-table-cell-actions']/button[1]"));

        public JobTitlesPage(IWebDriver driver) : base(driver)
        {

        }

        public AddJobTitlePage ClickJobTitlesOption()
        {
            addButton.ClickWhenReady();
            return new AddJobTitlePage(driver);
        }

        public List<String> GetCurrentPageJobTitlesList() => tableCurrentPageJobTitles.Select(title => title.Text).ToList();

        public void ClickDeleteButtonForSpecificJobTitle(string expectedTitle)
        {
            int i = tableCurrentPageJobTitles.FindIndex(v => v.Text == expectedTitle);
            jobTitlesDeleteButtons[i].Click();
        }
    }
}
