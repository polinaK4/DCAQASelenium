using Module7.Pages;
using OpenQA.Selenium;

namespace Module7.Pages.CheckboxesPage
{
    public class CheckboxesPage : BasePage
    {
        private string checkboxLocator = "//*[@id='checkboxes']/input[{0}]";
        private IWebElement checkboxes(String index) => GetElement(By.XPath(String.Format(checkboxLocator, index)));

        public CheckboxesPage(IWebDriver driver) : base(driver) 
        { 

        }

        public void ClickCheckbox(string id) => checkboxes(id).Click();

        public bool IfSelectedCheckbox(string id) => checkboxes(id).Selected;
    }
}
