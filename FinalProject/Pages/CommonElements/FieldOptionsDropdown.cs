using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.CommonElements
{
    public class FieldOptionsDropdown : BasePage
    {
        private List<PoliWebElement> _fieldOptionsList => driver.WaitTillElementsCountAndGetList(By.XPath("//*[@role='listbox']/div/span"), 10, 1);

        public FieldOptionsDropdown(IWebDriver driver) : base(driver)
        {

        }

        public PoliWebElement FindSpecificOption(string expectedText) => _fieldOptionsList.Where(hint => hint.Text.Contains(expectedText)).FirstOrDefault();
        public void SelectSpecificOption(string expectedText) => FindSpecificOption(expectedText).Click();

    }
}
