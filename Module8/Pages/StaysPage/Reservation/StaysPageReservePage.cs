using OpenQA.Selenium;

namespace Module8.Pages.StaysPage.Reservation
{
    public class StaysPageReservePage : BasePage
    {
        private IWebElement firstNameInput => GetElementAfterItVisible(By.XPath("//*[@id='firstname']"));
        private IWebElement lastNameInput => GetElementAfterItVisible(By.XPath("//*[@id='lastname']"));
        private IWebElement emailInput => GetElementAfterItVisible(By.XPath("//*[@id='email']"));
        private IWebElement phoneInput => GetElementAfterItVisible(By.XPath("//*[@id='phone']"));
        private IWebElement finalDetailsButton => ScrollToGetElement(By.XPath("//button[@name='book']"));
        public StaysPageReservePage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFirstName(string firstname) => firstNameInput.SendKeys(firstname);

        public void EnterLastName(string lastname) => lastNameInput.SendKeys(lastname);

        public void EnterEmail(string email) => emailInput.SendKeys(email);

        public void EnterPhone(string phone) => phoneInput.SendKeys(phone);

        public StaysPageFinalDetailsReservation ClickFinalDetailsButton()
        {
            finalDetailsButton.Click();
            return new StaysPageFinalDetailsReservation(driver);
        }
    }
}
