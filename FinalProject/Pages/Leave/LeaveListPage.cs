using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Leave
{
    public class LeaveListPage : BasePage
    {
        private ButtonElement _topbarEntitlementsButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//span[.= 'Entitlements ']"));
        private ButtonElement _addEntitlementsOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//a[.= 'Add Entitlements']"));
        private ButtonElement _topbarMoreButton => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//span[.= 'More ']"));        
        private ButtonElement _assignLeaveMenuOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//a[.= 'Assign Leave ']"));        

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
