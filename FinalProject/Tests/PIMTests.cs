using FinalProject.Pages.Authorization;
using FinalProject.Pages.General;
using FinalProject.Pages.PIM;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FinalProject.Tests
{
    public class PIMTests : BaseTest
    {
        private LoginPage loginPage;
        private LeftSideMenuBar leftSideMenuBar;
        private PimDefault_EmployeeList pimEmployeeList;
        private PimAddEmployee pimAddEmployee;
        private PimEmployeeListPersonalDetails pimEmployeePersonalDetails;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
        }

        [Test]
        public void ValidateAddNewEmployee()
        {
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            var pimEmployeeList = leftSideMenuBar.ClickPimOption();
            var pimAddEmployee = pimEmployeeList.CliclAddEmployeeTab();
            pimAddEmployee.EnterFirstName("Harry");
            pimAddEmployee.EnterMiddleName("James");
            pimAddEmployee.EnterLastName("Potter");
            pimAddEmployee.EnterEmployeeId("5555");
            var pimEmployeePersonalDetails = pimAddEmployee.ClickSaveEmployee();
            pimEmployeePersonalDetails.VerifyEmployeeName("Harry Potter");
        }
    }
}
