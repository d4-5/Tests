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

        [When(@"press Bank Manager Login button")]
        public void WhenClickBankManagerLogin()
        {
            loginPage.ClickBankManagerLogin();
        }

        [Then(@"the result should be page that contains buttons: (.*), (.*), (.*)")]
        public void ThenTheResultShouldBePageThatHasButtons(string buttonName1, string buttonName2, string buttonName3)
        {
            string[] buttonNames = { buttonName1, buttonName2, buttonName3 };

            foreach (var buttonName in buttonNames)
            {
                Assert.IsTrue(loginPage.ButtonExists(buttonName));
            }
        }

    }
}
