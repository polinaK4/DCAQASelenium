using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.CommonElements
{
    public class CommonTableElements : BasePage
    {
        private ButtonElement _tableRecordsFoundLabel => new ButtonElement(By.XPath("//*[@class='orangehrm-paper-container']/div[2]//span"));
        public CommonTableElements(IWebDriver driver) : base(driver)
        {

        }

        public string GetTableLabel() => _tableRecordsFoundLabel.Text;

        public void VerifyTableRecordsFoundLabel(string expectedText) => WaitForExpectedText(_tableRecordsFoundLabel, expectedText);
    }
}
