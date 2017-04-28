using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumAssertTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:1248/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheSeleniumAssertTestTest()
        {

#pragma warning disable CS0618 // Type or member is obsolete
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(100));
#pragma warning restore CS0618 // Type or member is obsolete

            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.LinkText("Create New")).Click();
            //driver.FindElement(By.Id("StartDate")).Clear();
            driver.FindElement(By.Id("StartDate")).SendKeys("20/6/2017");
            Assert.AreEqual("", driver.FindElement(By.Id("StartDate")).Text);
            //driver.FindElement(By.Id("EndDate")).Clear();
            driver.FindElement(By.Id("EndDate")).SendKeys("25/6/2017");
            Assert.AreEqual("", driver.FindElement(By.Id("EndDate")).Text);
            Assert.AreEqual("John Smith Jane Doe", driver.FindElement(By.Id("CustomerId")).Text);
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
