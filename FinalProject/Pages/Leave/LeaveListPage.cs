using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Leave
{
    public class LeaveListPage : BasePage
    {
        private ButtonElement _topbarEntitlementsButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//li[3]/span"));
        private ButtonElement _addEntitlementsOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//li[3]//li[1]/a"));
        private ButtonElement _topbarMoreButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//li[6]/span"));        
        private ButtonElement _assignLeaveMenuOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//li[6]//div[2]//a"));        

        public LeaveListPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickEntitlementsOption() => _topbarEntitlementsButton.ClickWhenReady();

        public AddEntitlementsPage ClickAddEntitlementsOption()
        {
            _addEntitlementsOption.ClickWhenReady();
            return new AddEntitlementsPage(driver);
        }

        public void ClickMoreOption() => _topbarMoreButton.ClickWhenReady();

        public AssignLeavePage ClickAssignLeaveOption()
        {
            _assignLeaveMenuOption.Click();
            return new AssignLeavePage(driver);
        }
    }
}
