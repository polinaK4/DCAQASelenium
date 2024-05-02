using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Performance
{
    public class PerformanceKpiPage : BasePage
    {
        private ButtonElement addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));
        private List<PoliWebElement> first50CardsKpiTitles => driver.GetPoliWebElementList(By.XPath("//*[@class='oxd-table-body']//*[@role='cell'][2]/div"));
        private List<PoliWebElement> first50CardsJobTitles => driver.GetPoliWebElementList(By.XPath("//*[@class='oxd-table-body']//*[@role='cell'][3]/div"));
        private ButtonElement deleteButton => new ButtonElement(By.XPath("//*[@role='rowgroup']//*[@class='oxd-table-card'][1]//button[2]"));
        private ButtonElement confirmDeleteButton => new ButtonElement(By.XPath("//*[@class='orangehrm-modal-footer']/button[2]"));        

        public PerformanceKpiPage(IWebDriver driver) : base(driver)
        {

        }

        public AddKpiPage ClickAddButton()
        {
            addButton.Click();
            return new AddKpiPage(driver);
        }

        public List<String> First50KpiTitles() => first50CardsKpiTitles.Select(title => title.Text).ToList();

        public List<String> FirstPageJobTitlesText() => first50CardsJobTitles.Select(title => title.Text).ToList();

        public void ClickDeleteButton() => deleteButton.ClickWhenReady();

        public void ClickConfirmDeleteButton() => confirmDeleteButton.ClickWhenReady();
    }
}
