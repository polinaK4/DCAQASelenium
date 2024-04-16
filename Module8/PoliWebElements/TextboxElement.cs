using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.PoliWebElements
{
    public class TextboxElement : PoliWebElement
    {
        public TextboxElement(By By) : base(By)
        {

        }

        public void EnterText(string text)
        {
            this.element.Clear();
            this.element.SendKeys(text);
        }

    }
}
