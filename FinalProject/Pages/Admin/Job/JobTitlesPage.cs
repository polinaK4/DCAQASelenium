using FinalProject.Pages.Modules.Grid;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin.Job
{
    public class JobTitlesPage : BasePage
    {
        public Grid grid => new Grid(driver);
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']//button"));

        public JobTitlesPage(IWebDriver driver) : base(driver)
        {

        }

        public AddJobTitlePage ClickJobTitlesOption()
        {
            _addButton.ClickWhenReady();
            return new AddJobTitlePage(driver);
        }

    }
}
