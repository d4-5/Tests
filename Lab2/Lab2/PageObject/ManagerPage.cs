using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PageObject
{
    public class ManagerPage : BasePage
    {
        private static WebDriverWait wait;
        public ManagerPage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }
        private IWebElement CustomerName(string name) => driver.FindElement(By.XPath($"//option[text()=\"{name}\"]"));
        private IWebElement Currency(string currency) => driver.FindElement(By.XPath($"//option[text()=\"{currency}\"]"));

        public void ChoseCustomerName(string name) => CustomerName(name).Click();
        public void ChoseCurrency(string currency) => Currency(currency).Click();
        public void ClickButton(string button) => driver.FindElement(By.XPath($"//button[contains(text(), '{button}')]")).Click();
        public string AlertText()
        {
            try
            {
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                return alert.Text;
            }
            catch (NoAlertPresentException)
            {
                return string.Empty;
            }
        }
    }
}
