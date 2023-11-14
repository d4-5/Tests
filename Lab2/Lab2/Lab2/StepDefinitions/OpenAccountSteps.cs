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
        [When(@"click (.*)")]
        public void WhenClick(string Button)
        {
            managerPage.ClickButton(Button);
        }
        [When(@"chose customer name: (.*)")]
        public void WhenChoseCustomerName(string CustomerName)
        {
            managerPage.ChoseCustomerName(CustomerName);
        }
        [When(@"chose currency: (.*)")]
        public void WhenChoseCurrency(string Currency)
        {
            managerPage.ChoseCurrency(Currency);
        }

        [Then(@"the result should be an alert that contains (.*)")]
        public void ThenTheResultShouldContain(string text)
        {
            IAlert alert = managerPage.Alert();
            string AlertMessage = alert.Text;
            alert.Accept();
            Assert.That(AlertMessage.Contains(text));
        }

        [Then(@"the result should be no alert")]
        public void ThenTheResultShouldBeNoAlert()
        {
            IAlert alert = managerPage.Alert();
            Assert.IsNull(alert);
        }
    }
}
