using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace Module7
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
            string selectedOption1 = dropdownPage.FindSelectElement().SelectedOption.Text;
            ClassicAssert.AreEqual("Option 1", selectedOption1);
        }

        [Test]
        public void SelectDifferentOptionsFromDropdown()
        {
            dropdownPage.SelectDropdownOptionByText("Option 1");
            string selectedOption1 = dropdownPage.FindSelectElement().SelectedOption.Text;
            ClassicAssert.AreEqual("Option 1", selectedOption1);
            dropdownPage.SelectDropdownOptionByText("Option 2");
            string selectedOption2 = dropdownPage.FindSelectElement().SelectedOption.Text;
            ClassicAssert.AreEqual("Option 2", selectedOption2);
        }

        [Test]
        public void ValidateDropdownOptions()
        {
            List<IWebElement> dropdownList = dropdownPage.DropdownOptionsList();
            ClassicAssert.AreEqual("Please select an option", dropdownList[0].Text);
            ClassicAssert.AreEqual("Option 1", dropdownList[1].Text);
            ClassicAssert.AreEqual("Option 2", dropdownList[2].Text);
        }

        [Test]
        public void SelectRandomOptionFromDropdown()
        {
            List<IWebElement> dropdownList = dropdownPage.DropdownOptionsList();
            Random rand = new Random();
            int randomIndex = rand.Next(1, dropdownList.Count);
            dropdownPage.SelectDropdownOptionByIndex(randomIndex);
            string selectedOption = dropdownPage.FindSelectElement().SelectedOption.Text;
            ClassicAssert.AreEqual(dropdownList[randomIndex].Text, selectedOption);
        }
    }
}
