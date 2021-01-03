using NUnit.Framework;
using OpenQA.Selenium;

namespace GCSeleniumTests.Pages
{
    public class AddTestPage
    {
        private IWebDriver driver;
        public AddTestPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement threadInput => driver.FindElement(By.CssSelector("input#thread"));

        public void PopulateThreadInput(string inputValue)
        {
            threadInput.SendKeys(inputValue);
        }
    }
}