using NUnit.Framework;
using OpenQA.Selenium;
using PageObject;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowPageObjectWebDriver.Steps
{
    [Binding]
    public class OpenAccountSteps : BaseSteps
    {

        private ManagerPage managerPage;

        [Given(@"open Manager page")]
        public void GivenOpenManagerPage()
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/BankingProject/#/manager";
            managerPage = new ManagerPage(driver);
        }

        [When(@"click (.*), chose customer name: (.*), currency: (.*) and click (.*)")]
        public void WhenChoseCustomerCurrencyAndClickProcess(string Button1, string CustomerName, string Currency, string Button2)
        {
            managerPage.ClickButton(Button1);
            managerPage.ChoseCustomerName(CustomerName);
            managerPage.ChoseCurrency(Currency);
            managerPage.ClickButton(Button2);
        }

        [Then(@"the result should be an alert that contains (.*)")]
        public void ThenTheResultShouldContain(string text)
        {
            string AlertMessage = managerPage.AlertText();
            Assert.That(AlertMessage.Contains(text));
        }
    }
}
