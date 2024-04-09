using Module8.Pages.Authorization;
using OpenQA.Selenium;

namespace Module8.Pages.CommonElements.Header
{
    public class Header : BasePage
    {
        private IWebElement skipToMainContentButton => GetElement(By.XPath("//*[@class='bui-list-item']"));        
        private IWebElement staysLinkTitle => GetElement(By.XPath("//*[@id='accommodations']//span[@class='a53cbfa6de']"));
        private IWebElement attractionsLink => GetElement(By.XPath("//*[@id='attractions']"));
        private IWebElement carRentalsLink => GetElement(By.XPath("//*[@id='cars']"));
        private IWebElement flightsLink => GetElement(By.XPath("//*[@id='flights']"));
        private IWebElement airportTaxisLink => GetElement(By.XPath("//*[@id='airport_taxis']"));
        private IWebElement currencyButton => GetElementAfterItVisible(By.XPath("//*[@data-testid='header-currency-picker-trigger']"));
        private IWebElement currentCurrency => GetElementAfterItVisible(By.XPath("//*[@data-testid='header-currency-picker-trigger']/span"));
        private IWebElement languageButton => GetElement(By.XPath("//*[@data-testid='header-language-picker-trigger']"));
        private IWebElement russianLanguageButton => GetElementAfterItVisible(By.XPath("//*[@data-testid='All languages']//ul[7]/li[1]/button[@data-testid='selection-item']"));
        private IWebElement signInButton => GetElementAfterItVisible(By.XPath("//*[@data-testid='header-sign-in-button']"));
        private IWebElement registerButton => GetElementAfterItVisible(By.XPath("//*[@data-testid='header-sign-up-button']"));

        public Header(IWebDriver driver) : base(driver)
        {

        }

        public void ClickAttractionsLink() => attractionsLink.Click();

        public void ClickCarRentalsLink() => carRentalsLink.Click();

        public void ClickFlightsLink() => flightsLink.Click();

        public void ClickAirportTaxisLink() => airportTaxisLink.Click();

        public void ClickLanguageButton() => languageButton.Click();

        public void ClickRussianLanguageButton() => russianLanguageButton.Click();

        public void CheckStaysLinkTitle(string expectedText) => WaitForElementName(staysLinkTitle, expectedText);

        public SignInPage ClickSignInButton()
        {
            signInButton.Click();
            return new SignInPage(driver);
        }

        public void FindAndFocusFocusRegisterButtonUsingTab() => FindAndFocusElementUsingTabKey(registerButton, "data-testid");

        public void FindAndFocusCurrencyButtonUsingTab() => FindAndFocusElementUsingTabKey(currencyButton, "data-testid");

        public string GetCurrentCurrencyValue() => currentCurrency.Text;

        public void ClickSkipToMainContentUsingJS() => ClickElementUsingJavaScript(skipToMainContentButton);
    }
}