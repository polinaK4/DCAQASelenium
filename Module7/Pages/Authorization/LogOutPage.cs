using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class LogOutPage
    {
        private IWebDriver driver;

        private readonly By logoutButton = By.XPath("//a[contains(@href,'/logout')]");

        public LogOutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickLogoutButton() => driver.FindElement(logoutButton).Click();
    }
}
