using OpenQA.Selenium;

namespace Module7
{
    public class CheckboxesPage
    {
        private IWebDriver driver;

        private readonly By checkbox1 = By.XPath("//*[@id='checkboxes']/input[1]");
        private readonly By checkbox2 = By.XPath("//*[@id='checkboxes']/input[2]");

        public CheckboxesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickCheckbox1() => driver.FindElement(checkbox1).Click();

        public void ClickCheckbox2() => driver.FindElement(checkbox2).Click();

        public bool IfSelectedCheckbox1() => driver.FindElement(checkbox1).Selected;

        public bool IfSelectedCheckbox2() => driver.FindElement(checkbox2).Selected;
    }
}
