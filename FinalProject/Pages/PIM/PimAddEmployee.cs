using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages.PIM
{
    public class PimAddEmployee : BasePage
    {
        private IWebElement firstNameInputField => GetElementAfterItVisible(By.XPath("//*[@name='firstName']"));
        private IWebElement middleNameInputField => GetElementAfterItVisible(By.XPath("//*[@name='middleName']"));
        private IWebElement lastNameInputField => GetElementAfterItVisible(By.XPath("//*[@name='lastName']"));
        private IWebElement employeeIdInputField => GetElementAfterItVisible(By.XPath("//*[@class='oxd-form-row']/div[2]//input"));
        private IWebElement saveButton => GetElementAfterItVisible(By.XPath("//*[@type='submit']"));

        public PimAddEmployee(IWebDriver driver) : base(driver)
        {

        }

        public void EnterFirstName(string firstname) => firstNameInputField.SendKeys(firstname);

        public void EnterMiddleName(string middlename) => middleNameInputField.SendKeys(middlename);

        public void EnterLastName(string lastname) => lastNameInputField.SendKeys(lastname);

        public void EnterEmployeeId(string id)
        {
            employeeIdInputField.Clear();
            employeeIdInputField.SendKeys(id);
        }

        public PimEmployeeListPersonalDetails ClickSaveEmployee()
        {
            saveButton.Click();
            return new PimEmployeeListPersonalDetails(driver);
        }
    }
}
