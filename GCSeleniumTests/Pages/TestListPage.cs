using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GCSeleniumTests.Pages
{
    public class TestListPage : PageBase
    {

        public TestListPage(IWebDriver driver) : base (driver) {}

        private IWebElement goToAddTestsPageButton => driver.FindElement(By.CssSelector("li>a[href='/AddNewTests']"));
        private ReadOnlyCollection<IWebElement> threadElements => driver.FindElements(By.CssSelector("tbody>tr"));
        //private IWebElement threadId => driver.FindElement(By.CssSelector("td.thread-id > input"));
        //private IWebElement threadName => driver.FindElement(By.CssSelector("td.thread-name > input"));
        private string dataCheckTesterSelect => "td.dc-tester > select";
        private string dataCheckStatusSelect => "td.dc-status > select";
        private string executionTesterSelect => "td.ex-status > select";
        private string executionStatusSelect => "td.ex-status > select";
        private string commentTexrArea => "td.comment > textarea";
        private IWebElement refreshButton => driver.FindElement(By.CssSelector("input[value='Refresh']"));
        

        public AddTestPage GoToAddTestsPage()
        {
            goToAddTestsPageButton.Click();
            return new AddTestPage(this.driver);
        }

        public TestListPage ClickRefreshButton()
        {
            refreshButton.Click();
            return this;
        }

        public int GetAllThreadsCount()
        {
            return threadElements.Count;
        }

        public ReadOnlyCollection<IWebElement> GetAllThreads()
        {
            return threadElements;
        }

        public List<string> GetAllThreadIDsByThreadName(string number)
        {
            var allThreads = GetAllThreads();
            List<string> matchingThreads = new List<string>();
            foreach (IWebElement thread in allThreads)
            {
                var threadNumberAttribute = thread.GetAttribute("number").TrimEnd();
                if (threadNumberAttribute == number)
                {
                    matchingThreads.Add(thread.GetAttribute("thread-id"));
                }
            }
            return matchingThreads;
        }

        public string GetLastAddedThreadIDByThreadName(string name)
        {
            var matchingThreads = GetAllThreadIDsByThreadName(name);
            var counter = matchingThreads.Count();
            string lastAddedThreadId = matchingThreads[counter - 1];
            return lastAddedThreadId;
        }

        public IWebElement GetThreadByThreadId(string threadId)
        {
            var allThreads = GetAllThreads();
            IWebElement threadById = null;
            foreach (var thread in allThreads)
            {
                    if (thread.GetAttribute("thread-id") == threadId)
                    {
                        threadById = thread;
                    }
            }
            return threadById;
        }

        public TestListPage SelectValue(string threadId, string selector, string valueToSelect)
        {
            var thread = GetThreadByThreadId(threadId);
            SelectElement se = new SelectElement(thread.FindElement(By.CssSelector(selector)));
            se.SelectByText(valueToSelect);
            return this;
        }

        public string GetSelectedValue(string threadId, string selector)
        {
            var thread = GetThreadByThreadId(threadId);
            return thread.FindElement(By.CssSelector(selector))
                         .FindElement(By.CssSelector("option[selected='selected']"))
                         .Text.TrimEnd();
        }

        public TestListPage SelectDataCheckTester(string threadId, string testerName)
        {
            SelectValue(threadId, dataCheckTesterSelect, testerName);
            return this;
        }

        public string GetSelectedDataCheckTester(string threadId)
        {
            return GetSelectedValue(threadId, dataCheckTesterSelect);
        }

        public TestListPage SelectDataCheckStatus(string threadId, string statusName)
        {
            SelectValue(threadId, dataCheckStatusSelect, statusName);
            return this;
        }

        public string GetSelectedDataCheckStatus(string threadId)
        {
            return GetSelectedValue(threadId, dataCheckStatusSelect);
        }

        public TestListPage SelectExecutionTester(string threadId, string testerName)
        {
            SelectValue(threadId, executionTesterSelect, testerName);
            return this;
        }

        public string GetExecutionTester(string threadId)
        {
            return GetSelectedValue(threadId, executionTesterSelect);
        }

        public TestListPage SelectExecutionStatus(string threadId, string statusName)
        {
            SelectValue(threadId, executionStatusSelect, statusName);
            return this;
        }

        public string GetSelectedExecutionStatus(string threadId)
        {
            return GetSelectedValue(threadId, executionStatusSelect);
        }

        //public TestListPage AddComment()
        //{
        //    return this;
        //}

        //public string GetComment(string threadId)
        //{

        //}
    }
}