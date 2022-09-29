using liberis_3.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace liberis_3.Hooks
{
    [Binding]
    public sealed class HooksInitialization
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ScenarioContext _scenarioContext;
        public HooksInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            SeleniumWedriver seleniumWedriver = new SeleniumWedriver(_scenarioContext);
            _scenarioContext.Set(seleniumWedriver, "SeleniumWebDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
