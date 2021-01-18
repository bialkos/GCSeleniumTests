using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using GCSeleniumTests.Pages;

namespace GCSeleniumTests.Tests
{
    public class EditFields : TestBase
    {
        TestListPage testListPage;
        HelperMethods helper;
        string threadNumber;
        string variationNumber;
        string threadFullName;
        string testerName = "mbielecki";

        [SetUp]
        public void AddThreadSetUp()
        {
            helper = new HelperMethods();
            threadNumber = helper.GetRandomThreadNumber();
            variationNumber = helper.GetRandomVariation();
            threadFullName = $"Thread {threadNumber}, Var {variationNumber.ToUpper()}";
        }

        [Test]
        public void ValidateDataCheckTesterIsUpdated()
        {
            testListPage = new TestListPage(driver);
            var addTestPage = testListPage.GoToAddTestsPage();
            addTestPage.AddThread(threadNumber, variationNumber)
                       .GoToTestListPage();
            var threadId = testListPage.GetLastAddedThreadIDByThreadName(threadFullName);
            testListPage.SelectDataCheckTester(threadId, testerName)
                        .ClickRefreshButton();
            var dataCheckTesterSelected = testListPage.GetSelectedDataCheckTester(threadId);
            Assert.AreEqual(testerName, dataCheckTesterSelected, $"The tester name is different than '{testerName}'");
        }
    }
}