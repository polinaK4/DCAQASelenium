using OpenQA.Selenium;

namespace FinalProject.Pages.PIM
{
    public class PimDefault_EmployeeList : BasePage
    {
        private IWebElement addEmployeeTab => GetElementAfterItVisible(By.XPath("//*[@class='oxd-topbar-body-nav']//li[3]"));
        
        public PimDefault_EmployeeList(IWebDriver driver) : base(driver)
        {

        }

        public PimAddEmployee CliclAddEmployeeTab()
        {
            addEmployeeTab.Click();
            return new PimAddEmployee(driver);
        }
    }
}
