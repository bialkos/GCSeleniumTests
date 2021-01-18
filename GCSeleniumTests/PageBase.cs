using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GCSeleniumTests
{
    public class PageBase
    {
        public IWebDriver driver;

        public PageBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}