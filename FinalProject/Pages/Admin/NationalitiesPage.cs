using FinalProject.Pages.Modules.Grid;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class NationalitiesPage : BasePage
    {
        public Grid grid => new Grid(driver);
        private PoliWebElement _nationalitiesFormHeader => new PoliWebElement(By.XPath("//*[@class='orangehrm-header-container']/h6"));            

        public NationalitiesPage(IWebDriver driver) : base(driver)
        {

        }

        public void VerifyVacanciesFormHeader(string expectedText) => WaitForExpectedText(_nationalitiesFormHeader, expectedText);

        public EditNationalityPage ClickEditButtonForSpecificNationality(string rowValue)
        {
            grid.ClickEditButtonForSpecificRecord(rowValue);
            return new EditNationalityPage(driver);
        }

    }
}
