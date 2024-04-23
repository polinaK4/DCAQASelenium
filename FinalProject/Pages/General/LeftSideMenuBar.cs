using FinalProject.Pages.Performance;
using FinalProject.Pages.PIM;
using OpenQA.Selenium;

namespace FinalProject.Pages.General
{
    public class LeftSideMenuBar : BasePage
    {
        private IWebElement searchInputField => GetElementAfterItVisible(By.XPath("//*[@class='oxd-main-menu-search']/input"));
        private List<IWebElement> menuOptions => GetListOfElements(By.XPath("//*[@class='oxd-main-menu']//span"));
        private IWebElement performanceOption => GetElementAfterItVisible(By.XPath("/web/index.php/performance/viewPerformanceModule"));
        private IWebElement pimOption => GetElementAfterItVisible(By.XPath("//*[@href='/web/index.php/pim/viewPimModule']"));        

        public LeftSideMenuBar(IWebDriver driver) : base(driver)
        {

        }

        public PerformanceDefault_ManageReviewsPage ClickPerformanceOption()
        {
            performanceOption.Click();
            return new PerformanceDefault_ManageReviewsPage(driver);
        }

        public PimDefault_EmployeeList ClickPimOption()
        {
            pimOption.Click();
            return new PimDefault_EmployeeList(driver);
        }
        public void EnterKeyWordToSearch(string keyword) => searchInputField.SendKeys(keyword);

        public List<string> MenuOptionsText()
        {
            var optionsText = new List<string>();
            foreach (var option in this.menuOptions)
            {
                string optionText = option.Text.ToLower();
                optionsText.Add(optionText);
            }
            return optionsText;
        } 
    }
}
