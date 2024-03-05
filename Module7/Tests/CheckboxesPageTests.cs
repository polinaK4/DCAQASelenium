using Module7.Pages.CheckboxesPage;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module7.Tests
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
            checkboxesPage.ClickCheckbox("1");
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox("1"));
            checkboxesPage.ClickCheckbox("1");
            ClassicAssert.AreEqual(false, checkboxesPage.IfSelectedCheckbox("1"));
        }

        [Test]
        public void CheckBothCheckboxes()
        {
            checkboxesPage.ClickCheckbox("1");            
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox("1"));
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox("2"));
        }

        [Test]
        public void UncheckBothCheckboxes()
        {
            checkboxesPage.ClickCheckbox("1");
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox("1"));
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox("2"));
            checkboxesPage.ClickCheckbox("1");
            checkboxesPage.ClickCheckbox("2");
            ClassicAssert.AreEqual(false, checkboxesPage.IfSelectedCheckbox("1"));
            ClassicAssert.AreEqual(false, checkboxesPage.IfSelectedCheckbox("2"));
        }

        [Test]
        public void ToggleCheckboxesRepeatedly()
        {
            checkboxesPage.ClickCheckbox("1");
            checkboxesPage.ClickCheckbox("1");
            checkboxesPage.ClickCheckbox("1");
            ClassicAssert.AreEqual(true, checkboxesPage.IfSelectedCheckbox("1"));
            checkboxesPage.ClickCheckbox("1");
            ClassicAssert.AreEqual(false, checkboxesPage.IfSelectedCheckbox("1"));
        }
    }
}
