using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin.Job
{
    public class JobTitlesPage : BasePage
    {
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']//button"));
        private List<PoliWebElement> _tableSelectedPageJobTitles => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='oxd-table-body']/div/div/div[2]"), 10, 1);
        private List<PoliWebElement> _tableDeleteButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div//button[1]"), 10, 1);

        public JobTitlesPage(IWebDriver driver) : base(driver)
        {

        }

        public AddJobTitlePage ClickJobTitlesOption()
        {
            _addButton.ClickWhenReady();
            return new AddJobTitlePage(driver);
        }

        public List<String> GetSelectedPageJobTitles() => _tableSelectedPageJobTitles.Select(title => title.Text).ToList();

        public void ClickDeleteButtonForSpecificJobTitle(string expectedTitle)
        {
            int i = _tableSelectedPageJobTitles.FindIndex(v => v.Text == expectedTitle);
            _tableDeleteButtons[i].Click();
        }
    }
}
