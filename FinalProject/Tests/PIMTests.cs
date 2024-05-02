using FinalProject.Pages.LoginPage;
using FinalProject.Pages.CommonElements;
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
        private PimEmployeeListPage pimEmployeeList;
        private FieldOptionsDropdown fieldOptionsDropdown;
        private Header header;
        private ConfirmationPopups confirmationPopups;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            loginPage = new LoginPage(driver);
            leftSideMenuBar = new LeftSideMenuBar(driver);
            pimEmployeeList = new PimEmployeeListPage(driver);
            fieldOptionsDropdown = new FieldOptionsDropdown(driver);
            header = new Header(driver);
            confirmationPopups = new ConfirmationPopups(driver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
            leftSideMenuBar.ClickPimOption();
        }

        [Test]
        public void ValidateAddNewEmployee()
        {
            var pimAddEmployee = pimEmployeeList.CliclAddEmployeeTab();
            pimAddEmployee.EnterFirstName("Harry");
            pimAddEmployee.EnterMiddleName("James");
            pimAddEmployee.EnterLastName("Potter");
            pimAddEmployee.EnterEmployeeId("5555");
            var pimEmployeePersonalDetails = pimAddEmployee.ClickSaveEmployeeButton();
            pimEmployeePersonalDetails.VerifyEmployeeName("Harry Potter");
        }

        [Test]
        public void SearchEmployee()
        {
            pimEmployeeList.TypeToEmployeeNameForHint("Harry");
            fieldOptionsDropdown.SelectSpecificOption("Harry James Potter");
            pimEmployeeList.ClickSearchButton();
            ClassicAssert.Contains("5555", pimEmployeeList.SearchResultsIdsList());
            pimEmployeeList.EnterEmployeeId("55555");
            pimEmployeeList.ClickSearchButton(); //
            pimEmployeeList.VerifyRecordsFoundText("No Records Found");

            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
        }

        [Test]
        public void EditEmployeeDetails()
        {
            pimEmployeeList.TypeToEmployeeNameForHint("timo");
            fieldOptionsDropdown.SelectSpecificOption("Timothy Lewis Amiano");
            pimEmployeeList.ClickSearchButton();
            var pimEmployeePersonalDetails = pimEmployeeList.ClickEditButtonForFirstResult();
            pimEmployeePersonalDetails.EnterLastName("Amiano edit");
            pimEmployeePersonalDetails.ClickSaveButton();
            pimEmployeePersonalDetails.VerifyEmployeeLastName("Amiano edit");
            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
        }

        [Test]
        public void DeleteEmployee()
        {
            pimEmployeeList.EnterEmployeeId("5555");
            pimEmployeeList.ClickSearchButton();
            pimEmployeeList.ClickDeleteButtonForFirstResult();
            confirmationPopups.ClickConfirmDeleteButton();
            pimEmployeeList.EnterEmployeeId("5555");
            pimEmployeeList.ClickSearchButton();
            pimEmployeeList.VerifyRecordsFoundText("No Records Found");

            header.ClickUserProfileDropdown();
            header.ClickLogoutButton();
        }

        [Test]
        public void ValidateAddCustomFieldsToEmployeeProfile()
        {
            pimEmployeeList.ClickTopbarConfigurationOption();
            var customFieldsPage = pimEmployeeList.CliclTopbarCustomFieldsOption();
            var addCustomFieldsPage = customFieldsPage.ClickAddButton();
            addCustomFieldsPage.EnterFieldName("May test1");
            addCustomFieldsPage.ClickScreenDropdown();
            fieldOptionsDropdown.SelectSpecificOption("Personal Details");
            addCustomFieldsPage.ClickTypeDropdown();
            fieldOptionsDropdown.SelectSpecificOption("Text or Number");
            addCustomFieldsPage.ClickSaveButton();
            leftSideMenuBar.ClickPimOption();
            var pimEmployeePersonalDetails = pimEmployeeList.ClickEditButtonForFirstResult();
            ClassicAssert.Contains("May test1", pimEmployeePersonalDetails.GetCustomFieldsLabels());
        }
    }
}
