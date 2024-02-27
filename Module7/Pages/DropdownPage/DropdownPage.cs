using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Module7
{
    public class DropdownPage
    {
        private IWebDriver driver;

        private readonly By dropdown = By.XPath("//*[@id='dropdown']");
        private readonly By dropdownOptions = By.XPath("//*[@id='dropdown']/option");

        public DropdownPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SelectElement FindSelectElement() => new SelectElement(driver.FindElement(dropdown));

        public List<IWebElement> DropdownOptionsList() => driver.FindElements(dropdownOptions).ToList();      

        public void SelectDropdownOptionByText(string option) => FindSelectElement().SelectByText(option);

        public void SelectDropdownOptionByIndex(int index) => FindSelectElement().SelectByIndex(index);

    }
}
