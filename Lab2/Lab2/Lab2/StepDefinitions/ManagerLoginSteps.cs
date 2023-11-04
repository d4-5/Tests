using NUnit.Framework;
using OpenQA.Selenium;
using PageObject;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowPageObjectWebDriver.Steps
{
    [Binding]
    public class LoginSteps : BaseSteps
    {
        private LoginPage loginPage;

        [Given(@"open Login page")]
        public void GivenOpenManagerPage()
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login";
            loginPage = new LoginPage(driver);
        }

        [When(@"click Bank Manager Login")]
        public void WhenClickBankManagerLogin()
        {
            loginPage.ClickBankManagerLogin();
        }

        [Then(@"the result should be page that contains button (.*)")]
        public void ThenTheResultShouldBePageThatHasButton(string button)
        {
            Assert.IsTrue(loginPage.ButtonExists(button));
        }
    }
}
