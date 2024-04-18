using Module8.Wrappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Module8.PoliWebElements
{
    public class DropDownElement : PoliWebElement
    {
        public DropDownElement(By locator) : base(locator)
        {

        }

        public void SelectByText(string text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public void SelectByValue(string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

    }
}
