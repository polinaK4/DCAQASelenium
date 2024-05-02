using OpenQA.Selenium;

namespace FinalProject.Pages.WebElements
{
    public class TextboxElement : PoliWebElement
    {
        public TextboxElement(By By) : base(By)
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

        //public void EnterText(string text)
        //{
        //    element.SendKeys(text);
        //}
    }
}
