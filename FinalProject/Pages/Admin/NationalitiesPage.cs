using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class NationalitiesPage : BasePage
    {
        private PoliWebElement _nationalitiesFormHeader => new PoliWebElement(By.XPath("//*[@class='orangehrm-header-container']/h6"));        
        private List<PoliWebElement> _tableSelectedPageNationalityTitles => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div/div[2]/div"), 10, 1);
        private List<PoliWebElement> _tableSelectedPageEditButtons => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='table']/div[2]/div/div//button[2]"), 10, 1);     

        public NationalitiesPage(IWebDriver driver) : base(driver)
        {

        }

        public void VerifyVacanciesFormHeader(string expectedText) => WaitForExpectedText(_nationalitiesFormHeader, expectedText);

        public EditNationalityPage ClickEditButtonForSpecificNationality(string expectedText)
        {
            int i = _tableSelectedPageNationalityTitles.FindIndex(v => v.Text == expectedText);
            _tableSelectedPageEditButtons[i].Click();
            return new EditNationalityPage(driver);
        }

        public List<String> GetTableCurrentPageNationalityTitles() => _tableSelectedPageNationalityTitles.Select(title => title.Text).ToList();
    }
}
