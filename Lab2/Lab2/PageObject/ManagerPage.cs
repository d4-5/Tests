using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
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
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(2));
        }
        public void ChoseCustomerName(string name)
        {
            var dropDown = driver.FindElement(By.Id("userSelect"));
            var selectElement = new SelectElement(dropDown);
            selectElement.SelectByText(name);
        }
        public void ChoseCurrency(string currency)
        {
            var dropDown = driver.FindElement(By.Id("currency"));
            var selectElement = new SelectElement(dropDown);
            selectElement.SelectByText(currency);
        }
        public void ClickButton(string button) => driver.FindElement(By.XPath($"//button[contains(text(), '{button}')]")).Click();
        public IAlert Alert()
        {
            try
            {
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                return alert;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}
