using Module7.Pages.DropdownPage;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Module7.Tests
{
    public class DropdownPageTests : BaseTest
    {
        private DropdownPage dropdownPage;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            dropdownPage = new DropdownPage(driver);
            ScrollAndOpenLink("/dropdown");
        }

        [Test]
        public void SelectOptionFromDropdown()
        {
            dropdownPage.SelectDropdownOptionByText("Option 1");
            string selectedOption1 = dropdownPage.SelectedOptionText();
            ClassicAssert.AreEqual("Option 1", selectedOption1);
        }

        [Test]
        public void SelectDifferentOptionsFromDropdown()
        {
            dropdownPage.SelectDropdownOptionByText("Option 1");
            string selectedOption1 = dropdownPage.SelectedOptionText();
            ClassicAssert.AreEqual("Option 1", selectedOption1);
            dropdownPage.SelectDropdownOptionByText("Option 2");
            string selectedOption2 = dropdownPage.SelectedOptionText();
            ClassicAssert.AreEqual("Option 2", selectedOption2);
        }

        [Test]
        public void ValidateDropdownOptions()
        {            
            ClassicAssert.AreEqual("Please select an option", dropdownPage.OptionTextByIndex(0));
            ClassicAssert.AreEqual("Option 1", dropdownPage.OptionTextByIndex(1));
            ClassicAssert.AreEqual("Option 2", dropdownPage.OptionTextByIndex(2));
        }

        [Test]
        public void SelectRandomOptionFromDropdown()
        {
            Random rand = new Random();
            int randomIndex = rand.Next(1, dropdownPage.DropdownOptionsCount());
            dropdownPage.SelectDropdownOptionByIndex(randomIndex);
            string selectedOption = dropdownPage.SelectedOptionText();
            ClassicAssert.AreEqual(dropdownPage.OptionTextByIndex(randomIndex), selectedOption);
        }
    }
}
