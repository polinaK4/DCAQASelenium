using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalProject.Pages.PIM
{
    public class PimEmployeeListPersonalDetails : BasePage
    {
        private IWebElement employeeName => GetElementAfterItVisible(By.XPath("//*[@class='orangehrm-edit-employee-name']/h6"));
        public PimEmployeeListPersonalDetails(IWebDriver driver) : base(driver)
        {
        }

        public void VerifyEmployeeName(string expectedText) => WaitForExpectedText(employeeName, expectedText);
    }
}
