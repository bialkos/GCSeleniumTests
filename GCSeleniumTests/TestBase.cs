using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GCSeleniumTests
{
    public class TestBase
    {
        public IWebDriver driver;
        private string homePageUrl = "https://testcollaborator.azurewebsites.net/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(homePageUrl);
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}