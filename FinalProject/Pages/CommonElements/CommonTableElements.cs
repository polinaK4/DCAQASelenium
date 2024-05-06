using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.CommonElements
{
    public class CommonTableElements : BasePage
    {
        private PoliWebElement _tableRecordsFoundLabel => new PoliWebElement(By.XPath("//*[@class='orangehrm-paper-container']/div[2]//span"));
        private ButtonElement _deleteSelectedButton => new ButtonElement(By.XPath("//*[@class='orangehrm-paper-container']/div[2]//button"));
        
        public CommonTableElements(IWebDriver driver) : base(driver)
        {

        }

        public string GetTableLabel() => _tableRecordsFoundLabel.Text;

        public void VerifyTableRecordsFoundLabel(string expectedText) => WaitForExpectedText(_tableRecordsFoundLabel, expectedText);

        public void ClickDeleteSelectedButton() => _deleteSelectedButton.ClickWhenReady();
    }
}
