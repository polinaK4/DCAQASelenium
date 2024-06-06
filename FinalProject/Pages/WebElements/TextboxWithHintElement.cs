using FinalProject.Helpers;
using OpenQA.Selenium;

namespace FinalProject.Pages.WebElements
{
    public class TextboxWithHintElement : PoliWebElement
    {
        private List<TextboxWithHintElement> _hintDropdownOptionsList => driver.GetTextboxWithHintElementList(By.XPath("//*[@role='listbox']//span"), 1);

        public TextboxWithHintElement(By By) : base(By)
        {

        }

        public TextboxWithHintElement(IWebElement element) : base(element)
        {

        }

        public void ClearWebField()
        {
            while (!element.GetAttribute("value").Equals(""))
            {
                element.SendKeys(Keys.Backspace);
            }
        }

        public void EnterText(string text)
        {
            ClearWebField();
            element.SendKeys(text);
        }

        public void ClickSpecificOption(string expectedText)
        {
            var option = _hintDropdownOptionsList.Where(hint => hint.Text.Contains(expectedText)).FirstOrDefault();
            option.Click();
        }
    }
}
