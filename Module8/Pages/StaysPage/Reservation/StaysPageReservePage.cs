using Module8.PoliWebElements;
using OpenQA.Selenium;

namespace Module8.Pages.StaysPage.Reservation
{
    public class StaysPageReservePage : BasePage
    {
        private TextboxElement firstNameInput => new TextboxElement(By.XPath("//*[@id='firstname']"));
        private TextboxElement lastNameInput => new TextboxElement(By.XPath("//*[@id='lastname']"));
        private TextboxElement emailInput => new TextboxElement(By.XPath("//*[@id='email']"));
        private TextboxElement phoneInput => new TextboxElement(By.XPath("//*[@id='phone']"));
        private IWebElement finalDetailsButton => ScrollToGetElement(By.XPath("//button[@name='book']"));
        public StaysPageReservePage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFirstName(string firstname) => firstNameInput.EnterText(firstname);

        public void EnterLastName(string lastname) => lastNameInput.EnterText(lastname);

        public void EnterEmail(string email) => emailInput.EnterText(email);

        public void EnterPhone(string phone) => phoneInput.EnterText(phone);

        public StaysPageFinalDetailsReservation ClickFinalDetailsButton()
        {
            finalDetailsButton.Click();
            return new StaysPageFinalDetailsReservation(driver);
        }
    }
}
