using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowPageObjectWebDriver.Steps
{
    [Binding]
    public class BaseSteps
    {
        protected static WebDriverWait wait;
        protected static IWebDriver driver;
        [BeforeFeature]
        public static void BeforeFeauture()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            driver.Close();
        }
    }
}
