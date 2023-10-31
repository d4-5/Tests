using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject
{
    public class LoginPage : BasePage
    {
        private static WebDriverWait wait;
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }
        private IWebElement BankMagerLogin => driver.FindElement(By.XPath("//button[@ng-click=\"manager()\"]"));
        public void ClickBankManagerLogin() => BankMagerLogin.Click();

        public bool ButtonExists(string buttonText)
        {
            try
            {
                IWebElement button = wait.Until(ExpectedConditions.ElementExists(By.XPath($"//button[contains(text(), '{buttonText}')]")));
                return true; 
            }
            catch (NoSuchElementException)
            {
                return false; 
            }
        }
       
    }
}
