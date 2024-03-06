using Module7.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Module7.Pages.DropdownPage
{
    public class DropdownPage : BasePage
    {
        private string dropdownLocator = "//*[@id='dropdown']";
        private string dropdownOptionsLocator = "//*[@id='dropdown']/option";
        private SelectElement dropdown => new SelectElement(GetElement(By.XPath(dropdownLocator)));
        public List<IWebElement> dropdownOptions => GetListOfElements(By.XPath(dropdownOptionsLocator));
        public DropdownPage(IWebDriver driver) : base(driver)
        {
           
        }     

        public void SelectDropdownOptionByText(string option) => dropdown.SelectByText(option);

        public void SelectDropdownOptionByIndex(int index) => dropdown.SelectByIndex(index);

        public string SelectedOptionText() => dropdown.SelectedOption.Text;

        public string OptionTextByIndex(int index) => dropdownOptions[index].Text;

        public int DropdownOptionsCount() => dropdownOptions.Count();
    }
}
