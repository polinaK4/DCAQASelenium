using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Vacancies
{
    public class RecruimentVacanciesPage : BasePage
    {
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));
        private List<PoliWebElement> _tableCurrentPageVacanciesTitles => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='oxd-table-body']/div/div/div[2]/div"), 10, 1);
        private List<PoliWebElement> _vacanciesDeleteButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@class='oxd-table-cell-actions']/button[1]"), 10, 1);

        public RecruimentVacanciesPage(IWebDriver driver) : base(driver)
        {

        }

        public AddVacancyPage ClickAddButton()
        {
            _addButton.ClickWhenReady();
            return new AddVacancyPage(driver);
        }

        public List<string> VacanciesTitlesText() => _tableCurrentPageVacanciesTitles.Select(option => option.Text).ToList();

        public void ClickDeleteButtonForSpecificVacancy(string expectedText)
        {
            int i = _tableCurrentPageVacanciesTitles.FindIndex(v => v.Text == expectedText);
            _vacanciesDeleteButtons[i].Click();
        }
    }
}
