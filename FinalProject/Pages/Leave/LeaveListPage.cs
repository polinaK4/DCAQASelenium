using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Leave
{
    public class LeaveListPage : BasePage
    {
        private ButtonElement entitlementsOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//li[3]/span"));
        private ButtonElement addEntitlementsOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//li[3]//li[1]/a"));
        private ButtonElement moreOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//li[6]/span"));        
        private ButtonElement assignLeaveMenuOption => new ButtonElement(By.XPath("//*[@aria-label='Topbar Menu']//li[6]//div[2]//a"));        

        public LeaveListPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickEntitlementsOption() => entitlementsOption.ClickWhenReady();

        public AddEntitlementsPage ClickAddEntitlementsOption()
        {
            addEntitlementsOption.ClickWhenReady();
            return new AddEntitlementsPage(driver);
        }

        public void ClickMoreOption() => moreOption.ClickWhenReady();

        public AssignLeavePage ClickAssignLeaveOption()
        {
            assignLeaveMenuOption.Click();
            return new AssignLeavePage(driver);
        }
    }
}
