using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using GCSeleniumTests.Pages;

namespace GCSeleniumTests.Tests
{
    public class AddThread
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void AddNewThread()
        {
            string threadName = "7.11";
            driver.Navigate().GoToUrl("https://localhost:44351/AddNewTests");
            AddTestPage addTestPage = new AddTestPage(driver);
            addTestPage.PopulateThreadInput(threadName);
        }
    }
}