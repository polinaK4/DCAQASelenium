using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Dashboard
{
    public class DashboardPage : BasePage
    {
        private ButtonElement assignLeaveQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='Assign Leave']"));
        private ButtonElement leaveListQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='Leave List']"));
        private ButtonElement timesheetsQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='Timesheets']"));
        private ButtonElement applyLeaveQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='Apply Leave']"));
        private ButtonElement myLeaveQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='My Leave']"));
        private ButtonElement myTimesheetQuickLaunchButton => new ButtonElement(By.XPath("//button[@title='My Timesheet']"));

        public DashboardPage(IWebDriver driver) : base(driver)
        {

        }

        public bool AssignLeaveQuickLaunchButtonEnabled() => assignLeaveQuickLaunchButton.Enabled;

        public bool LeaveListQuickLaunchButtonEnabled() => leaveListQuickLaunchButton.Enabled;

        public bool TimesheetsQuickLaunchButtonEnabled() => timesheetsQuickLaunchButton.Enabled;

        public bool ApplyLeaveQuickLaunchButtonEnabled() => applyLeaveQuickLaunchButton.Enabled;

        public bool MyLeaveQuickLaunchButtonEnabled() => myLeaveQuickLaunchButton.Enabled;

        public bool MyTimesheetQuickLaunchButtonEnabled() => myTimesheetQuickLaunchButton.Enabled;
    }
}
