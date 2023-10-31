using OpenQA.Selenium;
using System;

namespace PageObject
{
    public class BasePage
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;


        }
    }
}
