using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace liberis_3.Drivers
{
    class SeleniumWedriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public SeleniumWedriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        [SetUp]
        public IWebDriver Setup()
        {
            var chromeOption = new ChromeOptions();

            _scenarioContext.Set(driver, "WebDriver");
            driver.Manage().Window.Maximize();
            return driver;
        }

        internal object Navigate()
        {
            throw new NotImplementedException();
        }
    }
}
