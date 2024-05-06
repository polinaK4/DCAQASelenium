using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Recruitment.Vacancies
{
    public class RecruimentVacanciesPage : BasePage
    {
        private PoliWebElement _vacanciesFormHeader => new PoliWebElement(By.XPath("//*[@class='oxd-layout-context']//h5"));
        private ButtonElement _addButton => new ButtonElement(By.XPath("//*[@class='orangehrm-header-container']/button"));
        private List<PoliWebElement> _tableCurrentPageVacanciesTitles => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div/div[2]/div"), 10, 1);
        private List<PoliWebElement> _vacanciesDeleteButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div//button[1]"), 10, 1);

        public RecruimentVacanciesPage(IWebDriver driver) : base(driver)
        {

        }

        public void VerifyVacanciesFormHeader(string expectedText) => WaitForExpectedText(_vacanciesFormHeader, expectedText);

        public AddVacancyPage ClickAddButton()
        {
            _addButton.ClickWhenReady();
            return new AddVacancyPage(driver);
        }

        public List<string> GetVacanciesTitles() => _tableCurrentPageVacanciesTitles.Select(option => option.Text).ToList();

        public void ClickDeleteButtonForSpecificVacancy(string expectedText)
        {
            int i = _tableCurrentPageVacanciesTitles.FindIndex(v => v.Text == expectedText);
            _vacanciesDeleteButtons[i].Click();
        }
    }
}
