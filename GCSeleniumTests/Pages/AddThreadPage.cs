using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace GCSeleniumTests.Pages
{
    public class AddTestPage : PageBase
    {
        public AddTestPage(IWebDriver driver) : base (driver) {}

        private IWebElement goToTestListPageButton => driver.FindElement(By.CssSelector("li>a[href='/']"));
        private IWebElement threadInputField => driver.FindElement(By.CssSelector("input#thread"));
        private IWebElement variationInputField => driver.FindElement(By.CssSelector("input#variation"));
        private IWebElement addTestButton => driver.FindElement(By.CssSelector("input[type = submit]"));
        private IWebElement threadAddedConfirmationMessage => driver.FindElement(By.CssSelector("h3.confirmation-message"));

        public TestListPage GoToTestListPage()
        {
            goToTestListPageButton.Click();
            return new TestListPage(this.driver);
        }

        public AddTestPage PopulateThreadInputField(string inputValue)
        {
            threadInputField.Click();
            threadInputField.SendKeys(inputValue);
            return this;
        }

        public AddTestPage PopulateVariationInputField(string inputValue)
        {
            variationInputField.Click();
            variationInputField.SendKeys(inputValue);
            return this;
        }

        public AddTestPage ClickAddTest()
        {
            addTestButton.Click();
            return this;
        }

        public AddTestPage AddThread(string threadInputValue, string variationInputValue)
        {
            PopulateThreadInputField(threadInputValue);
            PopulateVariationInputField(variationInputValue);
            ClickAddTest();
            return this;
        }

        public string GetConfirmationMessage()
        {
            return threadAddedConfirmationMessage.Text;
        }
    }
}