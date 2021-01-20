using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using GCSeleniumTests.Pages;

namespace GCSeleniumTests.Tests
{
    public class AddThread : TestBase
    {
        TestListPage testListPage;
        HelperMethods helper;
        string threadNumber;
        string variationNumber;
        string threadFullName;

        [SetUp]
        public void AddThreadSetUp()
        {
            helper = new HelperMethods();
            threadNumber = helper.GetRandomThreadNumber();
            variationNumber = helper.GetRandomVariation();
            threadFullName = $"Thread {threadNumber}, Var {variationNumber.ToUpper()}";
        }

        [Test]
        public void ValidateConfirmationMessage()
        {
            testListPage = new TestListPage(driver);
            string expectedConfirmationMessage = $"Test added: Thread: {threadNumber}, Var {variationNumber.ToUpper()}";
            var addTestPage = testListPage.GoToAddTestsPage();
            addTestPage.AddThread(threadNumber, variationNumber);
            string confirmationMessage = addTestPage.GetConfirmationMessage();
            Assert.AreEqual(expectedConfirmationMessage, confirmationMessage, "The confirmation message is not correct");
        }

        [Test]
        public void ValidateNewTestIsAdded()
        {
            testListPage = new TestListPage(driver);
            int numberOfThreadsBefore = testListPage.GetAllThreadsCount();
            var addTestPage = testListPage.GoToAddTestsPage();
            addTestPage.AddThread(threadNumber, variationNumber)
                       .GoToTestListPage();
            int numberOfThreadsAfter = numberOfThreadsBefore + 1;
            Assert.AreEqual(numberOfThreadsAfter, testListPage.GetAllThreadsCount(), "The number of threads is not correct");
        }

        //[Test]
        //public void ValidateNewTestName()
        //{
        //    testListPage = new TestListPage(driver);

        //}
    }
}