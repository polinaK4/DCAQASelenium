using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Admin
{
    public class NationalitiesPage : BasePage
    {
        private ButtonElement firstNationalityEditButton => new ButtonElement(By.XPath("//*[@class='oxd-table-body']/div[1]//button[2]"));
        private PoliWebElement firstNationalityName => new PoliWebElement(By.XPath("//*[@class='oxd-table-body']/div[1]/div/div[2]/div"));        

        public NationalitiesPage(IWebDriver driver) : base(driver)
        {

        }

        public EditNationalityPage ClickEditFirstNationalityButton()
        {
            firstNationalityEditButton.Click();
            return new EditNationalityPage(driver);
        }

        public string GetFirstNationalityName() => firstNationalityName.Text;
    }
}
