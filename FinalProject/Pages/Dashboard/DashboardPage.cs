using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Dashboard
{
    public class DashboardPage : BasePage
    {
        private ButtonElement _assignLeaveQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='Assign Leave']"));
        private ButtonElement _leaveListQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='Leave List']"));
        private ButtonElement _timesheetsQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='Timesheets']"));
        private ButtonElement _applyLeaveQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='Apply Leave']"));
        private ButtonElement _myLeaveQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='My Leave']"));
        private ButtonElement _myTimesheetQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='My Timesheet']"));

        public DashboardPage(IWebDriver driver) : base(driver)
        {

        }

        public bool AssignLeaveQuickLaunchButtonEnabled() => _assignLeaveQuickLaunchButton.Enabled;

        public bool LeaveListQuickLaunchButtonEnabled() => _leaveListQuickLaunchButton.Enabled;

        public bool TimesheetsQuickLaunchButtonEnabled() => _timesheetsQuickLaunchButton.Enabled;

        public bool ApplyLeaveQuickLaunchButtonEnabled() => _applyLeaveQuickLaunchButton.Enabled;

        public bool MyLeaveQuickLaunchButtonEnabled() => _myLeaveQuickLaunchButton.Enabled;

        public bool MyTimesheetQuickLaunchButtonEnabled() => _myTimesheetQuickLaunchButton.Enabled;
    }
}
