
namespace LiteCartTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    [TestClass]
    public class BrowserTest
    {
        private IWebDriver driverInstance;

        private WebDriverWait browserWait;

        [TestInitialize]
        public void StartDriver()
        {
            this.driverInstance = new ChromeDriver();
            this.browserWait = new WebDriverWait(this.driverInstance, TimeSpan.FromSeconds(60));
        }

        [TestMethod]
        public void OpenBrowser()
        {
            this.driverInstance.Url = "http://localhost:8080/litecart/admin";
            this.browserWait.Until(
                ExpectedConditions.ElementToBeClickable(this.driverInstance.FindElement(By.Name("username"))));

            var textbox = this.driverInstance.FindElement(By.Name("username"));

            textbox.Clear();
            textbox.SendKeys("admin");

            textbox = this.driverInstance.FindElement(By.Name("password"));

            textbox.Clear();
            textbox.SendKeys("admin");
            
            this.driverInstance.FindElement(By.XPath("//button[@name='login']")).Click();

            this.driverInstance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            this.driverInstance.Quit();
        }
    }
}
