using Module8.Pages.Authorization;
using Module8.PoliWebElements;
using Module8.Wrappers;
using OpenQA.Selenium;

namespace Module8.Pages.CommonElements.Header
{
    public class Header : BasePage
    {
        private ButtonElement skipToMainContentButton => new ButtonElement(By.XPath("//*[@class='bui-list-item']"));        
        private PoliWebElement staysLinkTitle => new PoliWebElement(By.XPath("//*[@id='accommodations']//span[@class='a53cbfa6de']"));
        private PoliWebElement attractionsLink => new PoliWebElement(By.XPath("//*[@id='attractions']"));
        private PoliWebElement carRentalsLink => new PoliWebElement(By.XPath("//*[@id='cars']"));
        private PoliWebElement flightsLink => new PoliWebElement(By.XPath("//*[@id='flights']"));
        private PoliWebElement airportTaxisLink => new PoliWebElement(By.XPath("//*[@id='airport_taxis']"));
        private ButtonElement currentCurrency => new ButtonElement(By.XPath("//*[@data-testid='header-currency-picker-trigger']/span"));
        private ButtonElement languageButton => new ButtonElement(By.XPath("//*[@data-testid='header-language-picker-trigger']"));
        private ButtonElement russianLanguageButton => new ButtonElement(By.XPath("//*[@data-testid='All languages']//ul[7]/li[1]/button[@data-testid='selection-item']"));
        private ButtonElement signInButton => new ButtonElement(By.XPath("//*[@data-testid='header-sign-in-button']"));

        public Header(IWebDriver driver) : base(driver)
        {

        }

        public void ClickAttractionsLink() => attractionsLink.Click();

        public void ClickCarRentalsLink() => carRentalsLink.Click();

        public void ClickFlightsLink() => flightsLink.Click();

        public void ClickAirportTaxisLink() => airportTaxisLink.Click();

        public void ClickLanguageButton() => languageButton.ClickWhenReady();

        public void ClickRussianLanguageButton() => russianLanguageButton.ClickWhenReady();

        public void CheckStaysLinkTitle(string expectedText) => WaitForElementName(staysLinkTitle, expectedText);

        public SignInPage ClickSignInButton()
        {
            signInButton.ClickWhenReady();
            return new SignInPage(driver);
        }

        public string GetCurrentCurrencyValue() => currentCurrency.Text;

        public void ClickSkipToMainContentUsingJS() => ClickElementUsingJavaScript(skipToMainContentButton);
    }
}