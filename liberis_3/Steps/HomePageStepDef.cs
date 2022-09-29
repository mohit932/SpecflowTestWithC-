using TechTalk.SpecFlow;
using liberis_3.Drivers;
using OpenQA.Selenium;
using liberis_3.Drivers;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace liberis_3.Steps
{
    [Binding]
    public sealed class HomePageStepDef
    {
        IWebDriver driver = new ChromeDriver();
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public HomePageStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Log into liberis website - Using Chrome browser")]
        public void GivenLogIntoLiberisWebsite_UsingChromeBrowser()
        {
            driver.Navigate().GoToUrl("https://www.liberis.com/");
            driver.Manage().Window.Maximize();
        }

        [Given(@"Open ‘Get a Demo’ page")]
        public void GivenOpenGetADemoPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement getaDemo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.LinkText("Get a demo")));
            getaDemo.Click();
            //IWebElement partnerText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//h2[normalize-space()='Partnering with']")));
            //Assert.That(partnerText.Displayed);
        }

        [When(@"User does not make a partner selection and click ‘Get a demo’")]
        public void WhenUserDoesNotMakeAPartnerSelectionAndClickGetADemo()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement demoButton = driver.FindElement(By.XPath("(//a[contains(text(),'Get a demo')])[5]"));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(demoButton));
            //Assert.That(demoButton.Displayed);
            demoButton.Click();
        }

        [Then(@"Verify the validation message")]
        public void ThenVerifyTheValidationMessage()
        {
            
            IWebElement warningMessage = driver.FindElement(By.XPath("//div[contains(text(),'Please select a type of partner')]"));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            System.Threading.Thread.Sleep(3000);
            string errorMessage = warningMessage.Text;
            Assert.AreEqual("Please select a type of partner", errorMessage);
        }

        [Given(@"Select type of partner (.*)")]
        public void ThenSelectTypeOfPartnerIMAnISO(string p0)
        {
            var xpath = String.Format("//label[text()=" + p0 + "]");
            IWebElement selectBrokerType = driver.FindElement(By.XPath(xpath));
            selectBrokerType.Click();
        }
        
        [Then(@"Verify application display broker-iso-form")]
        public void ThenVerifyApplicationDisplayBroker_Iso_Form()
        {
            IWebElement broketForm = driver.FindElement(By.XPath("//h1[normalize-space()='Partnership Opportunities']"));
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual("Partnership Opportunities", broketForm.Text);

        }




        [Then(@"Close the Bowser")]
        public void ThenCloseTheBowser()
        {
            driver.Quit();
        }


    }
}
