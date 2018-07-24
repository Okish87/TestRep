namespace LiteCartTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    /// <summary> Selenium driver </summary>
    public class Driver
    {
        // ReSharper disable once StyleCop.SA1600
        private static IWebDriver driverInstance;

        private static WebDriverWait browserWait;

        public static void StartDriver()
        {
            driverInstance = new ChromeDriver();
            browserWait = new WebDriverWait(driverInstance, new TimeSpan(0, 0, 120));
        }

        public static void CloseDriver()
        {
            driverInstance.Quit();
        }
    }
}
