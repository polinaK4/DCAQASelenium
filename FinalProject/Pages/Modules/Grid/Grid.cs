using FinalProject.Helpers;
using FinalProject.Pages.WebElements;
using OpenQA.Selenium;

namespace FinalProject.Pages.Modules.Grid
{
    public class Grid : BasePage
    {
        private const string _gridLocatorTemplate = "//div[@class='orangehrm-container'][./ preceding-sibling::div[.// h6[.= '{0}']]]";
        private string _moduleXpath => $"{GridLocator}//div[@role='table']";
        private string _rowXpath => $"{GridLocator}//div[@role='row'][./div[@role='cell' and .='{{0}}']]";
        private string _headerXpath => $"{GridLocator}//*[@class='oxd-table-header']//div[@role='row']//div[@role='columnheader']";
        private string _cellXpath => $"{GridLocator}//*[@class='oxd-table-body']//div[@role='row']//div[@role='cell'][{{0}}]";
        private string _deleteButtonXpath => $"{GridLocator}//i[@class = 'oxd-icon bi-trash'][./ ancestor::div[@role = 'row'][./ div[@role = 'cell' and .= '{{0}}']]]";
        private string _editButtonXpath => $"{GridLocator}//i[@class = 'oxd-icon bi-pencil-fill'][./ ancestor::div[@role = 'row'][./ div[@role = 'cell' and .= '{{0}}']]]";
        private string _checkboxXpath => $"{GridLocator}//i[@class = 'oxd-icon bi-check oxd-checkbox-input-icon'][./ ancestor::div[@role = 'row'][./ div[@role = 'cell' and .= '{{0}}']]]";
        private string _recordsFoundLabelXPath => $"{GridLocator}//preceding::span[contains(.,'Found')][1]";
        private string _deleteSelectedButtonXPath => $"{GridLocator}//preceding::button[.= ' Delete Selected ']";
        private string _cellXpathByOtherCellValue => $"{GridLocator}//div[@role='row']//div[@role='cell'][{{0}}][./ preceding-sibling::div[@role = 'cell' and .= '{{1}}'] or ./ following-sibling::div[@role = 'cell' and .= '{{1}}']]";

        private string GridLocator { get; set; } = string.Empty;

        public Grid(IWebDriver driver) : base(driver)
        {

        }

        public Grid(IWebDriver driver, string gridLocatorName) : base(driver)
        {
            GridLocator = string.Format(_gridLocatorTemplate, gridLocatorName);
        }

        public List<string> GetValuesOfSpecificColumn(string headerName)
        {
            string columnXpathNumber = (GetColumnIndex(headerName) + 1).ToString();
            List<PoliWebElement> values = driver.GetPoliWebElementList(By.XPath(string.Format(_cellXpath, columnXpathNumber)), 1);
            List<string> valuesText = values.Select(option => option.Text).ToList();
            return valuesText;
        }

        public ConfirmationPopup ClickDeleteButtonForSpecificRecord(string rowValue)
        {
            ButtonElement deleteButton = new ButtonElement(By.XPath(string.Format(_deleteButtonXpath, rowValue)));
            deleteButton.ClickWhenReady();
            return new ConfirmationPopup(driver);
        }

        public void ClickEditButtonForSpecificRecord(string rowValue)
        {
            ButtonElement editButton = new ButtonElement(By.XPath(string.Format(_editButtonXpath, rowValue)));
            editButton.ClickWhenReady();
        }

        public void ClickCheckboxForSpecificRow(string rowValue)
        {
            PoliWebElement checkbox = new PoliWebElement(By.XPath(string.Format(_checkboxXpath, rowValue)));
            checkbox.Click();
        }

        public string GetGridLabel()
        {
            PoliWebElement recordsFoundLabel = new PoliWebElement(By.XPath(_recordsFoundLabelXPath));
            return recordsFoundLabel.Text;
        }

        public ConfirmationPopup ClickDeleteSelectedButton()
        {
            ButtonElement deleteSelectedButton = new ButtonElement(By.XPath(_deleteSelectedButtonXPath));
            deleteSelectedButton.ClickWhenReady();
            return new ConfirmationPopup(driver);
        }

        public string GetCellValueByOtherRowValue(string headerName, string knownRowValue)
        {
            string columnXpathNumber = (GetColumnIndex(headerName) + 1).ToString();
            PoliWebElement value = new PoliWebElement(By.XPath(string.Format(_cellXpathByOtherCellValue, columnXpathNumber, knownRowValue)));
            return value.Text;
        }

        private int GetColumnIndex(string headerName)
        {
            List<PoliWebElement> headerElements = driver.GetPoliWebElementList(By.XPath(_headerXpath), 1);
            List<string> headerElementsText = headerElements.Select(h => h.Text).ToList();
            return headerElementsText.IndexOf(headerName);
        }
    }
}
