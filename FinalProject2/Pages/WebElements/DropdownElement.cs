using FinalProject.Helpers;
using OpenQA.Selenium;

namespace FinalProject.Pages.WebElements
{
    public class DropdownElement : PoliWebElement
    {
        private List<DropdownElement> _dropdownOptionsList => driver.GetDropdownElementList(By.XPath("//*[@role='listbox']//span"), 1);
        public DropdownElement(By By) : base(By)
        {
            
        }

        public DropdownElement(IWebElement element) : base(element) 
        {

        }

        public void ClickSpecificOption(string expectedText)
        {
            var option = _dropdownOptionsList.Where(hint => hint.Text.Contains(expectedText)).FirstOrDefault();
            option.Click();
        }
    }
}
