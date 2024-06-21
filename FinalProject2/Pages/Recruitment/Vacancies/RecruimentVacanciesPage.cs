using FinalProject.Pages.Modules.Grid;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Vacancies
{
    public class RecruimentVacanciesPage : BasePage
    {
        public Grid grid => new Grid(driver);
        private PoliWebElement _vacanciesFormHeader => new PoliWebElement(By.XPath("//*[@class='oxd-layout-context']//h5"));
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));

        public RecruimentVacanciesPage(IWebDriver driver) : base(driver)
        {

        }

        public void VerifyVacanciesFormHeader(string expectedText) => WaitForExpectedText(_vacanciesFormHeader, expectedText);

        public AddVacancyPage ClickAddButton()
        {
            _addButton.ClickWhenReady();
            return new AddVacancyPage(driver);
        }
    }
}
