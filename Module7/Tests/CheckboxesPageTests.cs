using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class CheckboxesPageTests : BaseTest
    {
        private CheckboxesPage checkboxesPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            checkboxesPage = new CheckboxesPage(driver);
            ScrollAndOpenLink("/checkboxes");
        }

        [Test]
        public void ToggleCheckbox()
        {
            checkboxesPage.ClickCheckbox1();
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox1());
            checkboxesPage.ClickCheckbox1();
            ClassicAssert.AreEqual(false, checkboxesPage.IfSelectedCheckbox1());
        }

        [Test]
        public void CheckBothCheckboxes()
        {
            checkboxesPage.ClickCheckbox1();            
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox1());
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox2());
        }

        [Test]
        public void UncheckBothCheckboxes()
        {
            checkboxesPage.ClickCheckbox1();
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox1());
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox2());
            checkboxesPage.ClickCheckbox1();
            checkboxesPage.ClickCheckbox2();
            ClassicAssert.AreEqual(false, checkboxesPage.IfSelectedCheckbox1());
            ClassicAssert.AreEqual(false, checkboxesPage.IfSelectedCheckbox2());
        }

        [Test]
        public void ToggleCheckboxesRepeatedly()
        {
            checkboxesPage.ClickCheckbox1();
            checkboxesPage.ClickCheckbox1();
            checkboxesPage.ClickCheckbox1();
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox1());
            checkboxesPage.ClickCheckbox1();
            ClassicAssert.AreEqual(false, checkboxesPage.IfSelectedCheckbox1());
        }
    }
}
